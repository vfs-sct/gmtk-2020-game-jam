
/*
    Copyright (C) 2020 Team Triple Double, Sabastian Peters
*/

using System.Linq;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

namespace Afloat.Util.SceneManagement 
{

    /* 
        Class: LoadSceneJob

        A class to store a job for loading a single scene.
    */
    public class LoadSceneJob
    {

        // ## PROPERTIES  ##
        
        // The progress of loading the scene in the background
        public float Progress => Mathf.Clamp01((_asyncOperation?.progress ?? 0) / 0.9f) ; /// Unity stops loading async scenes at 0.9f

        // Is the scene loading in the background?
        public bool IsLoading => _hasStartedLoading && IsLoadingDone == false;

        // Is the scene done loading in the background?
        public bool IsLoadingDone => 0.9f <= (_asyncOperation?.progress ?? 0);
        
        // Is an instance of the target scene currently active in the game?
        public bool IsActiveInGame => SceneManager.GetSceneByBuildIndex(_buildIndex).isLoaded;

        

        // ## PRIVATE UTIL VARS ##

        private bool _hasStartedLoading = false;
        private LoadSceneMode _loadSceneMode = LoadSceneMode.Additive;
        private AsyncOperation _asyncOperation = null;
        private int _buildIndex = -1;
        private int v;




        // ## CONSTRUCTORS ##

        // base constructor
        public LoadSceneJob (int buildIndex, LoadSceneMode loadSceneMode)
        {
            _loadSceneMode = loadSceneMode;
            _buildIndex = buildIndex;
        }
        
        public LoadSceneJob (string path, LoadSceneMode loadSceneMode) : this(SceneUtility.GetBuildIndexByScenePath(path), loadSceneMode) 
        {
            if(SceneUtility.GetBuildIndexByScenePath(path) < 0)
            {
                Debug.LogError($"The scene path \"{path}\" used does not exist in build settings");
            }
        }

        public LoadSceneJob(int v)
        {
            this.v = v;
        }



        #region // ## PUBLIC METHODS ##

        // Function: StartLoad
        // Starts loading the scene in the background
        public void StartLoad ()
        {
            // _asyncOperation.
            _hasStartedLoading = true;

            _asyncOperation = SceneManager.LoadSceneAsync(_buildIndex, _loadSceneMode);
            _asyncOperation.allowSceneActivation = false;
        }

        // Function: Activate
        // Activates the scene for use.
        // Only use this once the scene is load
        public void Activate ()
        {
            _asyncOperation.allowSceneActivation = true;
        }
        
        // Function: LoadAndActivate
        // Activates the scene for use.
        // Only use this once the scene is load
        public IEnumerator LoadAndActivate ()
        {
            StartLoad();
            yield return new WaitUntil(() => IsLoadingDone);
            Activate();
        }

        // Function: ImmediateLoad
        // Loads the scene syncronously into the game.
        // This will hurt performance for larger scenes.
        public void ImmediateLoad ()
        {   
            SceneManager.LoadScene(_buildIndex, _loadSceneMode);
        }

#endregion       
        
#region // ## STATIC METHODS ##   
    
        // Function: All
        // Loads the provided jobs list. Waits until all scenes 
        // are loaded and then activates them in the game.
        public static IEnumerator All (List<LoadSceneJob> jobList, bool loadOnlyNewScenes)
        {
            if(loadOnlyNewScenes) EnsureOnlyNewScenes(ref jobList);


            // starting loading all of the jobs
            foreach (var job in jobList)
            {
                job.StartLoad();
            }

            // waits until all of them are loaded
            yield return new WaitUntil(() => {

                // keep waiting if any one of the scenes aren't ready
                foreach (var job in jobList)
                {
                    if(job.IsLoadingDone == false) return false;
                }

                return true;
            });

            // activates all of the scenes
            foreach (var job in jobList)
            {
                job.Activate();
            }
        }

        // Function: All
        // Creates a job list based on the provided scene paths
        // and loads the list. Waits until all scenes are loaded
        // and then activates them in the game.
        public static IEnumerator All (out List<LoadSceneJob> jobList, string[] scenePathList, bool loadOnlyNewScenes)
        {
            jobList = scenePathList
                .Select(path => new LoadSceneJob(path, LoadSceneMode.Additive))
                .ToList();

            return All(jobList, loadOnlyNewScenes);
        }

        // Function: ProgressAll
        // Returns the average progress of all scenes loading
        public static float ProgressAll (List<LoadSceneJob> jobList)
        {
            return jobList
                .Select(job => job.Progress)
                .Average();
        }

        // Function: IsLoadingDoneAll
        // Returns true if all jobs are done loading
        public static bool IsLoadingDoneAll (List<LoadSceneJob> jobList)
        {
            foreach (var job in jobList)
            {
                if(job.IsLoadingDone == false) return false;
            }

            return true;
        }

        // Function: ActivateAll
        // Tries to activate all of the given scenes
        public static void ActivateAll (List<LoadSceneJob> jobList)
        {
            foreach (var job in jobList)
            {
                job.Activate();
            }
        }
        
        

        public static void EnsureOnlyNewScenes (ref List<LoadSceneJob> jobList)
        {
            jobList = jobList
                .Where(job => job.IsActiveInGame == false) /// removed any scenes that are currently active in the game
                .ToList();
        }

#endregion

    }
}