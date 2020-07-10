
/*
    Copyright (C) 2020 Team Triple Double, Sabastian Peters
*/

using UnityEngine;

namespace Afloat.UI.MenuSystem
{
    /*
        Class: MenuData
    */
    [CreateAssetMenu(menuName="Custom/UI/MenuData")] 
    public class MenuData : ScriptableObject
    {
        
        // ## UNITY EDITOR ##
        
        public float FadeTime = 0.5f;
        public float FadeOffsetY = -3f;

    }
}