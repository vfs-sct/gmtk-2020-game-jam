/*
    Copyright (C) 2020 Team Triple Double, Diego Castagne
*/
using UnityEngine;
using Afloat.Util;

namespace Afloat
{
    public class InputController : MonoBehaviour
    {
        // ## UNITY EDITOR ##
        [SerializeField] private PlayerController _targetPlayer = null;
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
            Vector2 moveInput = new Vector2(Input.GetAxis(_xMoveInput), Input.GetAxis(_yMoveInput));
            Vector2 aimInput = new Vector2(Input.GetAxis(_xAimInput), Input.GetAxis(_yAimInput));

            _moveInput = moveInput;

            _aimInput = aimInput;

            if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                _moveInput = MathFunctions.MapToCircle(moveInput.x, moveInput.y);
            }

            if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
            {
                _aimInput = MathFunctions.MapToCircle(aimInput.x, aimInput.y);
            }

            if(moveInput.sqrMagnitude > 0.01f)
            {
                _targetPlayer.Move(_moveInput);
            }
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
