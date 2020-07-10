
/*
    Copyright (C) 2020 Team Triple Double, Sabastian Peters
*/

using UnityEngine;

namespace Afloat
{
    /*
        Class: PlayerPrefsStringVariable
    */
    [CreateAssetMenu(menuName="Custom/PlayerPrefs/String")] 
    public class PlayerPrefsStringVariable : PlayerPrefsScriptableVariable<string>
    {
    
#region // ## PROTECTED METHODS ##   
        
        protected override string GetValue (string playerPrefName)
        {
            return PlayerPrefs.GetString(playerPrefName);
        }   

        protected override void SetValue (string playerPrefName, string value)
        {
            PlayerPrefs.SetString(playerPrefName, value);
        }   
        
#endregion

    }
}