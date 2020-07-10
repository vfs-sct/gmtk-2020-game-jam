
/*
    Copyright (C) 2020 Team Triple Double, Sabastian Peters
*/

using Afloat.UI;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Afloat.Util.SceneManagement
{
    /* 
        Class: TransitionController
        
        A controller that handles the transition elements between scenes.
    */
    public class TransitionController : MonoBehaviour
    {
        private static TransitionController _instance = null;


        // ## UNTIY EDITOR ##

        [SerializeField] private SimpleBarUI _progressBarUI = null;
        [SerializeField] private TransitionUI _transitionUI = null;


#region // ## MONOBEHAVIOUR METHODS ##

        private void Start()
        {
            _instance = this;
        }

#endregion

#region // ## PUBLIC METHODS ##

        // Function: TransitionOut
        // Fades out of gameplay into the transition screen.
        // Think of it like a show method.
        public IEnumerator TransitionOut ()
        {
            yield return _transitionUI.TransitionOut();
        }

        // Function: TransitionIn
        // Fades into gameplay from the transition screen.
        // Think of it like a hide method.
        // If given a load scene job list, will
        public IEnumerator TransitionIn (List<LoadSceneJob> jobList = null)
        {

            if(jobList != null)
            {
                _progressBarUI.gameObject.SetActive(true);

                // while loading isn't done, update the progress bar
                while(LoadSceneJob.IsLoadingDoneAll(jobList) == false)
                {
                    _progressBarUI.SetValue(LoadSceneJob.ProgressAll(jobList));
                    yield return null;
                }

                _progressBarUI.gameObject.SetActive(false);
            }
            
            // shows the game
            yield return _transitionUI.TransitionIn();
        }

#endregion


#region // ## STATIC METHODS ##

        // Function: TryTransitionOut
        // Fades out of gameplay into the transition screen.
        // Think of it like a show method.
        public static IEnumerator TryTransitionOut ()
        {
            yield return _instance.TransitionOut();
        }

        // Function: TryTransitionIn
        // Fades into gameplay from the transition screen.
        // Think of it like a hide method.
        // If given a load scene job list, will
        public static IEnumerator TryTransitionIn (List<LoadSceneJob> jobList = null)
        {
            yield return _instance.TransitionIn();
        }

#endregion

    }
}