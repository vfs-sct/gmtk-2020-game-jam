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
        [SerializeField] private Animator _playerAnimator = null;

        // ## PROPERTIES  ##
        // ## PUBLIC VARS ##
        // ## PROTECTED VARS ##
        // ## PRIVATE UTIL VARS ##
        private Vector2 _moveInput;
        private Vector2 _aimInput;
        private bool _usingMouseAim = false;

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
            
            // Moves the player
            if(moveInput.sqrMagnitude > 0.01f)
            {
                _targetPlayer.Move(_moveInput);
                _playerAnimator.SetBool("Moving", true);
            }
            else
            {
                _playerAnimator.SetBool("Moving", false);
            }

            // Moves player's aim
            if(Input.GetAxis("Mouse X") > 0f || Input.GetAxis("Mouse Y") > 0f)
            {
                _usingMouseAim = true;
            }

            if(aimInput != Vector2.zero)
            {
                _usingMouseAim = false;
            }

            if(_usingMouseAim == false)
            {
                if(aimInput.sqrMagnitude != 0)
                {
                    _targetPlayer.Aim(_aimInput);
                }
            }
            else
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if(new Plane(Vector3.up, Vector3.zero + (Vector3.up * transform.position.y)).Raycast(ray, out float distance) == false) return;
                Vector3 intersectPos = ray.GetPoint(distance);
                Vector2 aimVector = new Vector2((intersectPos - transform.position).x, (intersectPos - transform.position).z);
                _targetPlayer.Aim(aimVector); 
            }


        }

#endregion

#region // ## PUBLIC METHODS ##

        public void PlayShootAnimation()
        {
            _playerAnimator.SetTrigger("Throw");
        }

#endregion
        
#region // ## <SOME INTERFACE> METHODS ##   
#endregion

#region // ## PROTECTED METHODS ##   
#endregion
        
#region // ## PRIVATE METHODS ##   
#endregion

    }
}
