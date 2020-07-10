
/*
    Copyright (C) 2020 Team Triple Double, Sabastian Peters
*/

using UnityEngine;

namespace Afloat.UI.MenuSystem
{
    /*
        Class: MenuData
    */
    [CreateAssetMenu(menuName="Custom/UI/MenuGroupData")] 
    public class MenuGroupData : ScriptableObject
    {
        
        // ## UNITY EDITOR ##
        
        public bool ShowOnStart = false;
        public bool UnlockCursorOnShow = true;
        public float FadeTime = 0.1f;
        public float DelayBetweenMenus = 0.2f;

    }
}