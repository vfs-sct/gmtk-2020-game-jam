/*
    Copyright (C) 2020 Team Triple Double, Diego Castagne
*/
using Afloat.Events;
using UnityEngine;

namespace Afloat
{
    public class PlayerController : MonoBehaviour
    {
        // ## UNITY EDITOR ##
        [SerializeField] private float _moveSpeed = 0f;
        [SerializeField] private float _turnSpeedSeconds = 0f;
        [SerializeField] private PotionLauncherController _potionLauncher = null;
        [SerializeField] private Transform _respawnPosition = null;
        [SerializeField] private GameEvent _deathEvent = null;
        [SerializeField] private float _killZ = 5f;


        // ## PROPERTIES  ##
        // ## PUBLIC VARS ##
        // ## PROTECTED VARS ##
        // ## PRIVATE UTIL VARS ##
        private Rigidbody _rbd;
        private bool _gameOver = false;

#region // ## MONOBEHAVIOUR METHODS ##

        private void Start()
        {
            _rbd = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            if(transform.position.y < _killZ)
            {
                Respawn();
            }
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
            if(_gameOver) return;

            _potionLauncher.ShootNextPotion();
        }

        public void Respawn()
        {
            _rbd.velocity = Vector3.zero;
            transform.position = _respawnPosition.position;
        }

        public void Die()
        {
            _deathEvent.Raise();

            // Maybe respawn?
        }

        public void GameOver()
        {
            _gameOver = true;
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
