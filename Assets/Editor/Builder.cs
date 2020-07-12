
/*
    Copyright (C) 2020 Team Triple Double, Sabastian Peters
*/

using System;
using System.IO;
using System.Linq;

using UnityEngine;
using UnityEditor;
using UnityEditor.Build.Reporting;

namespace Afloat.Util
{
    // TODO: extend BuildPlayerOptions (Afloat.Util.BuildConfig) and make this public so instances can vary & be edited
    /*
        Class: BuilderBase

        Base class for doing builds.
    */
    public class Builder
    {

        // ## UNITY EDITOR ##
        
        
        // ## PROPERTIES  ##

        
        // ## PUBLIC VARS ##

        public string DeliverableName = "Club Goblin.exe";



#region // ## PUBLIC METHODS ##
        
        public virtual BuildReport Build (BuildTarget target)
        {
            ClearBuild(target);
            return HandleBuild(GetConfig(target));
        }

        public BuildReport RebuildScripts (BuildTarget target)
        {
            BuildPlayerOptions config = GetConfig(target);
            config.options |= BuildOptions.BuildScriptsOnly;

            return HandleBuild(config);
        }
        
        // Deletes target build directory if it exists
        public void ClearBuild (BuildTarget target)
        {
            string path = GetBuildFolderPath(target);
            if(Directory.Exists(path))
            {
                Directory.Delete(path, true);
            }
        }

#endregion

#region // ## PROTECTED METHODS ##



        // Returns the path to the folder where the build will be
        protected virtual string GetBuildFolderPath (BuildTarget target)
        {
            // check if we use a provided path from CLI
            if(Application.isBatchMode)
            {
                string[] arguments = Environment.GetCommandLineArgs();
                int baseIndex = Array.IndexOf<String>(arguments, "-executeMethod"); 

                // only use provided path if executeMethod was found
                if(0 < baseIndex)
                {
                    return arguments[baseIndex+2]; /// if formated correctly, this should be the path to the folder
                }
            }

            // by default, assume it's an in-editor build
            return Path.Combine(
                Directory.GetCurrentDirectory(), 
                "Builds", 
                target.ToString()
            );
        }

        // Gets the path of the build file that runs the game
        protected virtual string GetBuildDeliverablePath (BuildTarget target)
        {
            return Path.Combine(
                GetBuildFolderPath(target),
                DeliverableName
            );
        }

        // Gets the config file used the build the game for the target
        protected virtual BuildPlayerOptions GetConfig (BuildTarget target)
        {
            
            // setup for target platform
            BuildPlayerOptions config = new BuildPlayerOptions();
            config.targetGroup = BuildTargetGroup.Standalone;
            config.target = target;
            
            // loads scenes provided in build settings
            config.scenes = 
                UnityEditor.EditorBuildSettings.scenes
                .Where(scene => scene.enabled)
                .Select(scene => scene.path)
                .ToArray();

            // determine build path
            config.locationPathName = GetBuildDeliverablePath(target);

            return config;
        }

#endregion

#region // ## PRIVATE UITL METHODS ##

        // Handles building the game given the config
        private BuildReport HandleBuild (BuildPlayerOptions config)
        {

            // If controlled by a person, show built player when done
            if(Application.isBatchMode == false)
            {
                config.options |= BuildOptions.ShowBuiltPlayer;
            }

            // Gets the Report and Summary
            BuildReport report = BuildPipeline.BuildPlayer(config);
            BuildSummary summary = report.summary;


            // Logs info

            if (summary.result == BuildResult.Succeeded)
            {
                Debug.Log("Build succeeded: " + summary.totalSize + " bytes");
            }

            if (summary.result == BuildResult.Failed)
            {
                Debug.Log("Build failed");
            }

            return report;
        }
    
#endregion

    }
}