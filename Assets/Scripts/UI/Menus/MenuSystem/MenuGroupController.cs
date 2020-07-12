
/*
    Copyright (C) 2020 Team Triple Double, Sabastian Peters
*/

using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

using Afloat.Util.Coroutines;
using Afloat.Util;
using DG.Tweening;

namespace Afloat.UI.MenuSystem
{
    /*
        Class: MenuGroupController

        A controller for showing, hiding and transitioning between a group of menus.
    */
    public class MenuGroupController : MonoBehaviour
    {

        // ## UNITY EDITOR ##

        [SerializeField] private MenuGroupData _data = null;
        [SerializeField] private MenuUI _startMenu = null;
        [SerializeField] private GraphicRaycaster _canvasInput = null;
        [SerializeField] private CanvasGroup _parentCanvasGroup = null;

        [Header("Events")]
        public UnityEvent OnShow = null;
        public UnityEvent OnHide = null;
        public UnityEvent OnOpenMenu = null;


        // ## PROPERTIES ##

        public bool IsActive => 0 < _menuStack.Count;
        public bool IsTransitioning => _transitionRoutine.IsRunning;
        public MenuUI CurrentMenu => _menuStack.Count <= 0 ? null : _menuStack.Peek();


        // ## PRIVATE UTIL VARS ##
        
        private Stack<MenuUI> _menuStack = new Stack<MenuUI>();
        private CoroutineHandler _transitionRoutine = null;
        
        



#region // ## MONOBEHAVIOUR METHODS ##

        private IEnumerator Start()
        {
            _transitionRoutine = new CoroutineHandler(this);
            
            if(_data.ShowOnStart)
            {
                yield return null;
                Show();
            }
            else
            {
                _parentCanvasGroup.alpha = 0;
            }
        }

#endregion




#region // ## PUBLIC METHODS ##

        public void OpenMenu(MenuUI menu)
        {
            if(IsTransitioning) return; /// exits if transitioning

            // switch menues and add menu to stack
            SwitchMenu(CurrentMenu, menu);
            _menuStack.Push(menu);

            OnOpenMenu.Invoke();
        }

        public void GoBack ()
        {
            if(IsTransitioning) return; /// exits if transitioning
            if(_menuStack.Count <= 0) return; /// exits if no menus to close

            // hides current menu and tries to show new one
            SwitchMenu(_menuStack.Pop(), CurrentMenu);
        }
        

        public void Show ()
        {
            if(_data.UnlockCursorOnShow) MouseLock.TryUnlock(); /// frees up cursor on open

            OpenMenu(_startMenu);
            OnShow.Invoke();
        }

        public void Hide ()
        {
            if(_data.UnlockCursorOnShow) MouseLock.TryLock(); /// locks down cursor on close

            ClearStack();
            OnHide.Invoke();
        }

        public void Toggle ()
        {
            if(IsActive)
            {
                Hide();
                return;
            }

            Show();
        }

        // Function: ClearStack
        // Hides last open menu and clears stack
        public void ClearStack ()
        {
            SwitchMenu(CurrentMenu, null); /// hides last shown menu
            
            _menuStack.Clear();
        }

#endregion




#region // ## PRIVATE UITL METHODS ##

        private IEnumerator SetOpacityRoutine (float amount)
        {
            yield return _parentCanvasGroup
                .DOFade(amount, _data.FadeTime)
                .SetUpdate(true)
                .WaitForCompletion();
        }

        private void SwitchMenu (MenuUI menuToHide, MenuUI menuToShow)
        {
            if(menuToShow == menuToHide) return; /// don't reshow the same menu

            // stops old routine, creates and starts new routine
            _transitionRoutine.Stop();
            _transitionRoutine.Start(SwitchMenuRoutine(menuToHide, menuToShow));
        }

        
        private IEnumerator SwitchMenuRoutine (MenuUI menuToHide, MenuUI menuToShow)
        {
            _canvasInput.enabled = false; // disable input
            
            // hides currently shown menu if exists
            if(menuToHide != null)
            {
                yield return menuToHide.SetVisible(false);

                if(menuToShow == null) /// hides parent if we wont open a new menu
                {
                    yield return SetOpacityRoutine(0); 
                }
            }


            yield return new WaitForSecondsRealtime(_data.DelayBetweenMenus);


            // shows new menu if it exists
            if(menuToShow != null)
            {
                if(menuToHide == null) /// shows parent if we were hidden
                {
                    yield return SetOpacityRoutine(1); 
                }

                yield return menuToShow.SetVisible(true);
            }

            _canvasInput.enabled = true; // re-enable input
        }

#endregion

    }
}