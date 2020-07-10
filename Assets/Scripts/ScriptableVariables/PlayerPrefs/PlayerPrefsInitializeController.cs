
/*
    Copyright (C) 2020 Team Triple Double, Sabastian Peters
*/

using UnityEngine;
using System.Collections.Generic;

namespace Afloat
{
    /*
        Class: PlayerPrefsInitializeController

        A controller to initialize a list of player pref scriptable variables
    */
    public class PlayerPrefsInitializeController : MonoBehaviour
    {
        
        // ## UNITY EDITOR ##
        
        [SerializeField] private List<ScriptableVariable> _variableList = null;


        
              
#region // ## MONOBEHAVIOUR METHODS ##
                
        private void Awake()
        {
            // tries to load each variable
            foreach (var genericVariable in _variableList)
            {
                // tries to cast variable, skips if failed
                IPlayerPrefsVariable variable = genericVariable as IPlayerPrefsVariable;
                if(variable == null)
                {
                    Debug.LogError($"{gameObject.name} in {gameObject.scene.name} tried loading {genericVariable.name} which does not implement {typeof(IPlayerPrefsVariable).Name}");
                    continue;
                }

                variable.Load();
            }
        }        
        
#endregion      

    }
}