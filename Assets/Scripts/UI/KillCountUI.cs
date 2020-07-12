
/*
    Copyright (C) 2020 Team Triple Double, Sabastian Peters
*/

using TMPro;
using UnityEngine;

namespace Afloat
{
    /*
        Class: KillCountUI
    */
    public class KillCountUI : MonoBehaviour
    {
        
        // ## UNITY EDITOR ##
        
        [SerializeField] private TextMeshProUGUI _redKill;
        [SerializeField] private TextMeshProUGUI _blueKill;
        [SerializeField] private TextMeshProUGUI _greenKill;
        [SerializeField] private GameData _gameData;

        
        // ## PROPERTIES  ##
        
        
        // ## PUBLIC VARS ##
        
        
        // ## PROTECTED VARS ##
        
        
        // ## PRIVATE UTIL VARS ##
        
        
        
              
#region // ## MONOBEHAVIOUR METHODS ##
                
        private void Update()
        {
            _redKill.text = _gameData.RedGoblinsKilled.ToString();
            _blueKill.text = _gameData.BlueGoblinsKilled.ToString();
            _greenKill.text = _gameData.GreenGoblinsKilled.ToString();
        }
        
#endregion      

#region // ## PUBLIC METHODS ##
                
        
        
#endregion       

#region // ## <SOME INTERFACE> METHODS ##   
                
        
        
#endregion
        
#region // ## PROTECTED METHODS ##   
        
        
        
#endregion
        
#region // ## PRIVATE METHODS ##   
        

        
#endregion

    }
}