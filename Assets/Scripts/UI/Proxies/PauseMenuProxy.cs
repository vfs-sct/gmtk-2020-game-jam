﻿
/*
    Copyright (C) 2020 Team Triple Double - Sabastian Peters, J. Vitor Brito
*/

using System.Collections;
using Afloat.Events;
using Afloat.UI.MenuSystem;
using Afloat.Util.SceneManagement;
using DG.Tweening;


using UnityEngine;
using UnityEngine.SceneManagement;

namespace Afloat.UI.Proxies
{
    /*
        Class: PauseMenuProxy
    */
    public class PauseMenuProxy : MonoBehaviour
    {

        // ## UNITY EDITOR ##

        [SerializeField] private MenuGroupController _pauseMenuController = null;

        [Header("Events")]
        [SerializeField] private GameEvent _onPauseEvent;
        [SerializeField] private GameEvent _onUnpauseEvent;

        // ## PRIVATE VARS ##

        


#region // ## MONOBEHAVIOUR METHODS ##

        public void OnEnable()
        {
            Debug.Log($"enable");
            _pauseMenuController.OnShow.AddListener(OnShowMenuGroup);
            _pauseMenuController.OnHide.AddListener(OnHideMenuGroup);
        }

        public void OnDisable()
        {
            _pauseMenuController.OnShow.RemoveListener(OnShowMenuGroup);
            _pauseMenuController.OnHide.RemoveListener(OnHideMenuGroup);
        }

#endregion

#region // ## PUBLIC METHODS ##

        public void ReturnToGame ()
        {
            _pauseMenuController.Hide();
        }

        public void Retry ()
        {
            StartCoroutine(LoadGame());
        }

        public void ExitToMainMenu ()
        {
            StartCoroutine(LoadMainMenu());   
        }

        public void ExitToDesktop ()
        {
            Application.Quit();
        }


#endregion 

#region // ## PRIVATE UTIL METHODS ##
        
        private void OnShowMenuGroup ()
        {
            Debug.Log($"AAA");
            _onPauseEvent.Raise();
            Time.timeScale = 0;
        }

        private void OnHideMenuGroup ()
        {
            Debug.Log($"BBB");
            _onUnpauseEvent.Raise();
            Time.timeScale = 1;
        }

        private IEnumerator LoadMainMenu ()
        {
            MusicController.GlobalStop();
            yield return TransitionController.TryTransitionOut();
            yield return new LoadSceneJob(0, LoadSceneMode.Single).LoadAndActivate();
        }

        private IEnumerator LoadGame ()
        {
            MusicController.GlobalStop();
            yield return TransitionController.TryTransitionOut();
            yield return new LoadSceneJob(1, LoadSceneMode.Single).LoadAndActivate();
        }

#endregion

    }
}