
/*
    Copyright (C) 2020 Team Triple Double, Sabastian Peters
*/

using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

namespace Afloat.Util
{
    /*
        Class: GammaController
    */
    public class GammaController : MonoBehaviour
    {
        
        // ## UNITY EDITOR ##

        [SerializeField] private Volume _targetVolume;
        [SerializeField] private PlayerPrefsFloatVariable _amount;
        

        // ## PRIVATE UTIL VARS ##
        
        private LiftGammaGain _lgg;
        
        
              
#region // ## MONOBEHAVIOUR METHODS ##
                
        private void Awake()
        {
            _lgg = _targetVolume.profile.Add<LiftGammaGain>();
        }

        private void Update()
        {
            // if(_targetVolume.sharedProfile.TryGet<LiftGammaGain>(out var comp) == false) return;
            // comp.gamma = new Vector4Parameter(new Vector4(1,1,1,_amount), true);
            // comp.gamma.value = new Vector4(1,1,1,_amount);
            _lgg.gain.Override(new Vector4(1f,1f,1f,_amount.Value));
        }
        
#endregion

    }
}