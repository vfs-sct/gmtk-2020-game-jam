
/*
    Copyright (C) 2020 Team Triple Double, Sabastian Peters
*/

using UnityEngine;
using UnityEngine.UI;

namespace Afloat.UI
{
    /*
        Class: BaseBarUI

        Abstract class that handles updating a UI Bar for a float.
        Use the <GenericBarUI> if looking to show a plain <FloatVariable>.
        This one is for custom data types (can override <Min>, <Max>, and <Value>)
    */
    public abstract class BaseBarUI : MonoBehaviour
    {
        
        // ## UNITY EDITOR ##
        
        [SerializeField] private Image _fillImage;
        
        // ## PROPERTIES  ##
        
        public virtual float Min => 0;
        public virtual float Max => 1;
        public abstract float Value { get; }
 

#region // ## PUBLIC METHODS ##
                
        public void UpdateFill()
        {
            _fillImage.fillAmount = Mathf.InverseLerp(Min, Max, Value);
        }
        
#endregion     

    }
}