
/*
    Copyright (C) 2020 Team Triple Double, Sabastian Peters
*/

using UnityEngine;

namespace Afloat.UI
{
    /*
        Class: GenericBarUI

        A bar that displays the value of a <FloatVariable>.
    */
    public class GenericBarUI : BaseBarUI
    {
        
        // ## UNITY EDITOR ##
        
        [SerializeField] private FloatVariable _variable;
        [SerializeField] private float _min = 0;
        [SerializeField] private float _max = 1;
        

        // ## PROPERTIES  ##
        
        public override float Min => _min;
        public override float Max => _max;
        public override float Value => _variable.Value;
        
        
              
#region // ## MONOBEHAVIOUR METHODS ##
                
        
        // TODO: move this to an event based system
        private void Update()
        {
            base.UpdateFill();
        }
        
#endregion      

    }
}