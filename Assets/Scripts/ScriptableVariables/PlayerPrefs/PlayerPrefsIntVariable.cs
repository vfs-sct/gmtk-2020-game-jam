
/*
    Copyright (C) 2020 Team Triple Double, Sabastian Peters
*/

using UnityEngine;

namespace Afloat
{
    /*
        Class: PlayerPrefsIntVariable
    */
    [CreateAssetMenu(menuName="Custom/PlayerPrefs/Int")] 
    public class PlayerPrefsIntVariable : PlayerPrefsScriptableVariable<int>
    {
    
#region // ## PROTECTED METHODS ##   
        
        protected override int GetValue (string playerPrefName)
        {
            return PlayerPrefs.GetInt(playerPrefName);
        }   

        protected override void SetValue (string playerPrefName, int value)
        {
            PlayerPrefs.SetInt(playerPrefName, value);
        }   
        
#endregion

    }
}