
/*
    Copyright (C) 2020 Team Triple Double, Sabastian Peters
*/


using UnityEngine;
using UnityEngine.Events;

using DG.Tweening;
using System.Collections;

namespace Afloat.UI.MenuSystem
{
    /*
        Class: MenuUI

        A UI behaviour that handles the fading in and out of a menu.
    */
    [RequireComponent(typeof(CanvasGroup))]
    public class MenuUI : MonoBehaviour
    {

        // ## UNITY EDITOR ##
        
        [SerializeField] private MenuData _menuData = null;

        [Header("References")]
        [SerializeField] private CanvasGroup _targetCanvasGroup = null;
        [SerializeField] private MenuGroupController _targetController = null;

        [Header("Events")]
        public UnityEvent OnOpened = null;
        public UnityEvent OnClosed = null;
        
        
#region // ## PUBLIC METHODS ##
        
        public void Open ()
        {
            _targetController.OpenMenu(this);
        }

        public IEnumerator SetVisible (bool isVisible)
        {
            bool wasVisible = gameObject.activeSelf; /// were we visible before change?


            // event based on status change

            if(isVisible == true && wasVisible == false) /// became visible
            {
                OnOpened.Invoke();
                yield return OpenRoutine();
            }
            else if(isVisible == false && wasVisible == true)  /// became non-visible
            {
                OnClosed.Invoke();
                yield return CloseRoutine();
            }

        }

#endregion 
        

#region // ## PRIVATE UITL METHODS ##

        private IEnumerator OpenRoutine ()
        {
            gameObject.SetActive(true); /// sets new visibility
            _targetCanvasGroup.alpha = 0;

            yield return new WaitForEndOfFrame(); /// waits untill Unity has the position

            // fades the y axis in parallel
            _targetCanvasGroup.transform
                .DOMoveY(transform.position.y + _menuData.FadeOffsetY, _menuData.FadeTime)
                .From();

            // fades in graphic
            yield return _targetCanvasGroup
                .DOFade(1f, _menuData.FadeTime)
                .WaitForCompletion();
        }

        private IEnumerator CloseRoutine ()
        {
            _targetCanvasGroup.alpha = 1;
            

            // fades the y axis in parallel
            _targetCanvasGroup.transform
                .DOMoveY(transform.position.y + _menuData.FadeOffsetY, _menuData.FadeTime);
            
            // fades out graphic
            yield return _targetCanvasGroup
                .DOFade(0f, _menuData.FadeTime)
                .WaitForCompletion();

            _targetCanvasGroup.transform.position -= Vector3.up * _menuData.FadeOffsetY; /// resets the position


            gameObject.SetActive(false); /// sets new visibility
        }

#endregion


        

        #if UNITY_EDITOR
        
        private void OnValidate()
        {
            if(_targetCanvasGroup == null) _targetCanvasGroup = GetComponent<CanvasGroup>();
        }

        #endif

    }
}