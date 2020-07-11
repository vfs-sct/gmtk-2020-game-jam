﻿/*
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

        public void Aim(Vector2 input)
        {
            Vector3 aimInput = new Vector3(input.x, 0f, input.y);
            

            Quaternion lookDir = Quaternion.LookRotation(aimInput, Vector3.up);

            transform.rotation = Quaternion.Slerp(transform.rotation, lookDir, _turnSpeedSeconds);
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
