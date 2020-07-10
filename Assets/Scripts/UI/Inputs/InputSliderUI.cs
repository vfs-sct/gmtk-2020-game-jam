
/*
    Copyright (C) 2020 Team Triple Double, Sabastian Peters
*/

using UnityEngine;
using UnityEngine.UI;

using Afloat.Util;


namespace Afloat.UI
{
    /*
        Class: InputSliderUI
    */
    public class InputSliderUI : MonoBehaviour
    {
        
        // ## UNITY EDITOR ##
        
        [SerializeField] private PlayerPrefsFloatVariable _targetFloat;
        [SerializeField] private Slider _targetSlider;
     
        [SerializeField] private float _minValue = 0;
        [SerializeField] private float _maxValue = 1;



              
#region // ## MONOBEHAVIOUR METHODS ##

        private void OnEnable()
        {   
            _targetSlider.onValueChanged.AddListener(OnSliderChanged);
            _targetSlider.value = _targetFloat.Value.Map(_minValue, _maxValue, 0, 1); /// updates the slider UI on initialize
        }

        private void OnDisable()
        {
            _targetSlider.onValueChanged.RemoveListener(OnSliderChanged);
        }
        
#endregion      

#region // ## PUBLIC METHODS ##

        // Function: SetSliderValue
        // Sets the value of the slider (0 -> 1) directly
        // Updates the sliders value as well (remaps)
        public void SetSliderValue (float newValue)
        {
            _targetSlider.value = newValue;
            _targetFloat.Value = newValue.Map(0, 1, _minValue, _maxValue);
        }
        
        // Function: SetFloatValue
        // Sets the value of the target float directly (min -> max)
        // Updates the sliders value as well (remaps)
        public void SetFloatValue (float newValue)
        {
            _targetSlider.value = newValue.Map(_minValue, _maxValue, 0, 1);
            _targetFloat.Value = newValue;
        }

#endregion

#region // ## PRIVATE METHODS ##   
        
        private void OnSliderChanged (float newValue)
        {
            SetSliderValue(newValue);
        }
        
#endregion

#if UNITY_EDITOR

        [Header("Editor Feedback")]
        [SerializeField] private float _displayFloatValue;

        private void OnDrawGizmosSelected()
        {
            _displayFloatValue = _targetFloat.Value;
        }

#endif

    }
}