
/*
    Copyright (C) 2020 Team Triple Double, Sabastian Peters
*/

using UnityEngine;
using UnityEngine.Audio;

namespace Afloat
{
    /*
        Class: AudioFloatVariable
    */
    [CreateAssetMenu(menuName="Custom/PlayerPrefs/Audio")] 
    public class AudioFloatVariable : PlayerPrefsFloatVariable
    {
        
        // ## UNITY EDITOR ##
        
        [SerializeField] private AudioMixer _targetMixerGroup = null;
        [SerializeField] private string _exposedPropertyName = "Volume Master";
        

#region // ## PUBLIC METHODS ##
                
        public override void Load()
        {
            base.Load();
            UpdateAudioMixer();
        }
        
#endregion       

#region // ## <SOME INTERFACE> METHODS ##   
                
        
        
#endregion
        
#region // ## PROTECTED METHODS ##   
        
        protected override void SetValue (string playerPrefName, float value)
        {
            base.SetValue(playerPrefName, value);
            UpdateAudioMixer();
        }
        
#endregion
        
#region // ## PRIVATE METHODS ##   
        
        private void UpdateAudioMixer ()
        {
            _targetMixerGroup.SetFloat(
                _exposedPropertyName, 
                LinearToDecibels(Value)
            );
        }

        private float LinearToDecibels (float linear)
        {
            if(Mathf.Approximately(0, linear) || linear < 0)
            {
                return -144.0f;
            }

            return 20.0f * Mathf.Log10(linear);
        }
        
#endregion

    }
}