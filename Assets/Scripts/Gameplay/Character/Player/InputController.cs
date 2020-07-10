/*
    Copyright (C) 2020 Team Triple Double, Diego Castagne
*/
using UnityEngine;

namespace Afloat
{
    public class InputController : MonoBehaviour
    {
        // ## UNITY EDITOR ##
        [SerializeField] private string _xMoveInput = "";
        [SerializeField] private string _yMoveInput = "";
        [SerializeField] private string _xAimInput = "";
        [SerializeField] private string _yAimInput = "";

        // ## PROPERTIES  ##
        // ## PUBLIC VARS ##
        // ## PROTECTED VARS ##
        // ## PRIVATE UTIL VARS ##
        public Vector2 _moveInput;
        public Vector2 _aimInput;

#region // ## MONOBEHAVIOUR METHODS ##

        private void Update()
        {
            _moveInput = new Vector2(Input.GetAxis(_xMoveInput), Input.GetAxis(_yMoveInput));

            _aimInput = new Vector2(Input.GetAxis(_xAimInput), Input.GetAxis(_yAimInput));
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
