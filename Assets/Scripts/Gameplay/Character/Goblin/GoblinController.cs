﻿/*
    Copyright (C) 2020 Team Triple Double, Diego Castagne
*/
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Afloat
{
    public class GoblinController : MonoBehaviour
    {
        // ## UNITY EDITOR ##
        [SerializeField] private PotionType _potionToKill = null;
        [SerializeField] private float _timeToDie = 0.3f;
        [SerializeField] private NavMeshAgent _agent = null;
        [SerializeField] private float _sightRange = 5f;
        [SerializeField] private LayerMask _playerLayerMask = default;
        // ## PROPERTIES  ##
        public PotionType PotionToKill => _potionToKill;
        // ## PUBLIC VARS ##
        // ## PROTECTED VARS ##
        // ## PRIVATE UTIL VARS ##
        private Rigidbody _rbd;
        private PlayerController _target;
        private bool _dead = false;

#region // ## MONOBEHAVIOUR METHODS ##

        private void Start()
        {
            _rbd = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            if(_dead) return;

            if(_target != null) 
            {
                _agent.destination = _target.transform.position;
                return;
            }
            

            var colliders = Physics.OverlapSphere(transform.position, _sightRange, _playerLayerMask, QueryTriggerInteraction.Ignore);

            if(colliders != null)
            {
                foreach(Collider col in colliders)
                {
                    if(col.TryGetComponent<PlayerController>(out PlayerController player))
                    {
                        _target = player;
                        break;
                    }
                }
            }

        }

#endregion

#region // ## PUBLIC METHODS ##

        public void Die()
        {
            Destroy(_agent);
            _rbd.constraints = RigidbodyConstraints.None;
            _rbd.isKinematic = false;
            _dead = true;
            // You can play the sound here
            StartCoroutine(DyingRoutine());
        }

#endregion
        
#region // ## <SOME INTERFACE> METHODS ##   
#endregion

#region // ## PROTECTED METHODS ##   
#endregion
        
#region // ## PRIVATE METHODS ##  

        private IEnumerator DyingRoutine()
        {
            yield return new WaitForSeconds(_timeToDie);
            Destroy(gameObject);
        }


#endregion

    }
}
