/*
    Copyright (C) 2020 Team Triple Double, Diego Castagne
*/
using UnityEngine;

namespace Afloat
{
    public class PlayerController : MonoBehaviour
    {
        // ## UNITY EDITOR ##
        [SerializeField] private float _moveSpeed = 0f;
        [SerializeField] private float _turnSpeedSeconds = 0f;

        // ## PROPERTIES  ##
        // ## PUBLIC VARS ##
        // ## PROTECTED VARS ##
        // ## PRIVATE UTIL VARS ##
        private Rigidbody _rbd;

#region // ## MONOBEHAVIOUR METHODS ##

        private void Start()
        {
            _rbd = GetComponent<Rigidbody>();
        }

#endregion

#region // ## PUBLIC METHODS ##

        public void Move(Vector2 input)
        {
            _rbd.velocity = new Vector3(input.x * _moveSpeed, _rbd.velocity.y, input.y * _moveSpeed);
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
