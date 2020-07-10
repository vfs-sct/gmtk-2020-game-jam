
/*
    Copyright (C) 2020 Team Triple Double, Sabastian Peters
*/

using Afloat.UI.MenuSystem;
using UnityEngine;

namespace Afloat
{
    /*
        Class: OptionsMenuController
    */
    public class OptionsMenuController : MonoBehaviour
    {
        
        // ## UNITY EDITOR ##

        [SerializeField] private MenuUI _targetMenu;
        
        
              
#region // ## MONOBEHAVIOUR METHODS ##
                
        private void Awake()
        {
            _targetMenu.OnClosed.AddListener(PlayerPrefs.Save); // save player prefs on close
        }
        
#endregion

    }
}