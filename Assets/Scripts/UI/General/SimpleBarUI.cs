
/*
    Copyright (C) 2020 Team Triple Double, Sabastian Peters
*/

using UnityEngine;

namespace Afloat.UI
{
    /*
        Class: SimpleBarUI

        A simple bar that displays the value of a float.
    */
    public class SimpleBarUI : BaseBarUI
    {
        
        // ## UNITY EDITOR ##

        [Range(0, 1)][SerializeField] private float _value;
        

        // ## PROPERTIES  ##
        
        public override float Value => _value;
        
        
              
#region // ## MONOBEHAVIOUR METHODS ##
                
        
        // TODO: move this to an event based system
        private void Update()
        {
            base.UpdateFill();
        }
        
#endregion            
        
              
#region // ## PUBLIC METHODS ##
                
        public void SetValue(float value)
        {
            _value = Mathf.Clamp(value, Min, Max);
        }
        
#endregion    


#if UNITY_EDITOR

        private void OnValidate()
        {
            base.UpdateFill();
        }

#endif

    }
}