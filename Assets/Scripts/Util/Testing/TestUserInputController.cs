
/*
    Copyright (C) 2020 Team Triple Double, Sabastian Peters

    Gets input from the User for doing mechanic tests.
*/

using System.Collections.Generic;
using UnityEngine;

namespace Afloat.Util.Testing
{
    public class TestUserInputController : MonoBehaviour
    {

        // ## UNITY EDITOR ##
        
        [SerializeField] private List<TestUserInputKey> _userInputKeyList;


              
#region // ## MONOBEHAVIOUR METHODS ##
        
        private void Update()
        {
            // triggers key down, held & up events for each provided key
            foreach (var key in _userInputKeyList)
            {
                if(Input.GetKeyDown(key.KeyCode))
                {
                    key.OnKeyDown.Invoke();
                }
                if(Input.GetKey(key.KeyCode))
                {
                    key.OnKeyHeld.Invoke();
                }
                if(Input.GetKeyUp(key.KeyCode))
                {
                    key.OnKeyUp.Invoke();
                }
            }
        }
        
#endregion      

    }
}