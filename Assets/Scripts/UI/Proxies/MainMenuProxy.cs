
/*
    Copyright (C) 2020 Team Triple Double, Sabastian Peters
*/

using TMPro;
using System;
using System.Collections;
using UnityEngine;

using Afloat.Util.Coroutines;
using Afloat.UI.MenuSystem;
using Afloat.Util.SceneManagement;
using UnityEngine.SceneManagement;

namespace Afloat.UI.Proxies
{
    /*
        Class: MainMenuProxy
    */
    public class MainMenuProxy : MonoBehaviour
    {
        
        // ## UNITY EDITOR ##

        [SerializeField] private MenuGroupController _menuGroupController = null;


        // ## PRIVATE UTIL VARS ##

        CoroutineHandler _actionRoutine = null;
        

#region // ## MONOBEHAVIOUR METHODS ##

        private void Start()
        {
            _actionRoutine = new CoroutineHandler(this);
        }

#endregion
        
#region // ## PUBLIC METHODS ##


        public void LoadSingleplayer ()
        {
            if(_actionRoutine.IsRunning) return;

            _actionRoutine.Start(LoadSingleplayerRoutine());
        }

        public void Quit ()
        {
            Application.Quit();
        }

#endregion


#region // ## PRIVATE UTIL METHODS ##

        private IEnumerator LoadSingleplayerRoutine()
        {
            yield return TransitionController.TryTransitionOut();
            yield return new LoadSceneJob(1, LoadSceneMode.Single).LoadAndActivate();
        }

#endregion

    }
}

