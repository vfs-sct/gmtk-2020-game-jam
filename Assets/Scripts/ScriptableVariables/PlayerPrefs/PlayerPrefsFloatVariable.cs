
/*
    Copyright (C) 2020 Team Triple Double, Sabastian Peters
*/

using UnityEngine;

namespace Afloat
{
    /*
        Class: PlayerPrefsFloatVariable
    */
    [CreateAssetMenu(menuName="Custom/PlayerPrefs/Float")] 
    public class PlayerPrefsFloatVariable : PlayerPrefsScriptableVariable<float>
    {
    
#region // ## PROTECTED METHODS ##   
        
        protected override float GetValue (string playerPrefName)
        {
            return PlayerPrefs.GetFloat(playerPrefName);
        }   

        protected override void SetValue (string playerPrefName, float value)
        {
            PlayerPrefs.SetFloat(playerPrefName, value);
        }   
        
#endregion

    }
}