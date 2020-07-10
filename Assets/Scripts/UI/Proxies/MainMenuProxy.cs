
/*
    Copyright (C) 2020 Team Triple Double, Sabastian Peters
*/

using TMPro;
using System;
using System.Collections;
using UnityEngine;

using Afloat.Util.Coroutines;
using Afloat.UI.MenuSystem;

namespace Afloat.UI.Proxies
{
    /*
        Class: MainMenuProxy
    */
    public class MainMenuProxy : MonoBehaviour
    {
        
        // ## UNITY EDITOR ##

        [SerializeField] private MenuGroupController _menuGroupController = null;
        [SerializeField] private TextMeshProUGUI _timeInQueue = null;


        // ## PRIVATE UTIL VARS ##
        

#region // ## MONOBEHAVIOUR METHODS ##

#endregion
        
#region // ## PUBLIC METHODS ##


        public void LoadSingleplayer ()
        {

        }

        public void Quit ()
        {
            Application.Quit();
        }

#endregion


#region // ## PRIVATE UTIL METHODS ##


#endregion

    }
}

