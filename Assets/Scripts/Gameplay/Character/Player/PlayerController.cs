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
        [SerializeField] private PotionType _potionTypeToShoot = null;
        [SerializeField] private float _launchSpeed = 0f;
        [SerializeField] private Transform _potionLaunchOrigin = null;


        // ## PROPERTIES  ##
        // ## PUBLIC VARS ##
        // ## PROTECTED VARS ##
        // ## PRIVATE UTIL VARS ##
        private Rigidbody _rbd;
        private float _timeOfVerticalTravel;

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

        public void Shoot()
        {
            Debug.Log($"I just shot a {_potionTypeToShoot.Name}");
            var potion = Instantiate(_potionTypeToShoot.PotionPrefab, _potionLaunchOrigin.position, _potionLaunchOrigin.rotation);
            if(potion.TryGetComponent<Rigidbody>(out Rigidbody potionRBD))
            {
                potionRBD.velocity = transform.forward * _launchSpeed;
            }
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
