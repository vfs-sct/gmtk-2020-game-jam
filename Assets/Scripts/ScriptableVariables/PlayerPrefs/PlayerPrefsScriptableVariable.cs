
/*
    Copyright (C) 2020 Team Triple Double, Sabastian Peters
*/

using GameSavvy.OpenUnityAttributes;
using UnityEngine;

namespace Afloat
{
    /*
        Class: PlayerPrefsScriptableVariable

        An abstact class for a scriptable variable that stores data in a player pref.
    */
    public abstract class PlayerPrefsScriptableVariable<T> : ScriptableVariable<T>, IPlayerPrefsVariable
    {

        // ## UNITY EDITOR ##

        [InfoBox("\"Value\" is the default value used by settings. \nIf it exists in player prefs, the game will use that instead.")]
        [SerializeField] private string _playerPrefName = "";


        // ## PROPERTIES ##

        public sealed override T Value
        {
            get
            {
                return GetValue(_playerPrefName);
            }
            set
            {
                SetValue(_playerPrefName, value);
            }
        }


        // ## ABSTRACT MEMBERS ##

        protected abstract T GetValue (string playerPrefName);
        protected abstract void SetValue (string playerPrefName, T value);


        // ## PUBLIC METHODS ##
        
        public virtual void Load()
        {
            // loads the player pref if exists. otherwise uses inspector value
            if(PlayerPrefs.HasKey(_playerPrefName))
            {
                GetValue(_playerPrefName);
            }
            else
            {
                SetValue(_playerPrefName, GetInspectorValue());
            }
        }

        // Close these off since it breaks with player prefs
        public sealed override void OnAfterDeserialize () {}
        public sealed override void OnBeforeSerialize() {}

    }
}