
/*
    Copyright (C) 2020 Team Triple Double, Sabastian Peters
*/

using Afloat.Util;

using UnityEngine;

namespace Afloat
{
    /*
        Class: KeyFlashUI
    */
    public class KeyFlashUI : MonoBehaviour
    {
        
        // ## UNITY EDITOR ##

        [Header("Styling")]
        [SerializeField] private float _alphaLow = 0.7f;
        [SerializeField] private float _alphaHigh = 0.9f;
        [SerializeField] private Vector3 _lowScale = Vector3.zero;
        [SerializeField] private Vector3 _highScale = Vector3.one;
        [SerializeField] private float _loopTime = 0.5f;

        [Header("References")]
        [SerializeField] private CanvasGroup _targetGroup;
        
        
              
#region // ## MONOBEHAVIOUR METHODS ##
                
        private void Update()
        {
            SetValue(OscilateFunction(Time.timeSinceLevelLoad));
        }
        
#endregion      

#region // ## PRIVATE METHODS ##
            
        // sets the lerp value for each target
        private void SetValue (float t)
        {
            _targetGroup.alpha = Mathf.Lerp(_alphaLow, _alphaHigh, t);
            _targetGroup.transform.localScale = Vector3.Lerp(_lowScale, _highScale, t);
        }

        // The function used to oscilate the values based on time
        // Returns a float from 0 to 1
        private float OscilateFunction (float time)
        {
            return Mathf.Sin((2 * Mathf.PI * time) / _loopTime).Map(-1, 1, 0, 1);
        }
        
#endregion

    }
}