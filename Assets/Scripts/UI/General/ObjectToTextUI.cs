
/*
    Copyright (C) 2020 Team Triple Double, Sabastian Peters
*/

using TMPro;
using UnityEngine;

namespace Afloat.UI
{
    /*
        Class: ObjectToTextUI
    */
    public class ObjectToTextUI : MonoBehaviour
    {
        
        // ## UNITY EDITOR ##

        [SerializeField] private TextMeshProUGUI _targetText;
        [SerializeField] private Object[] _objectList;
        [SerializeField] private string _format = "{0}";
        
        
              
#region // ## MONOBEHAVIOUR METHODS ##
                
        // TODO: move this to an event based system
        private void Update()
        {
            UpdateText();
        }
        
#endregion      
        
              
#region // ## PUBLIC METHODS ##
        
        private void UpdateText()
        {
            _targetText.text = string.Format(_format, _objectList);
        }
        
#endregion      

    }
}