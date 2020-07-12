/*
    Copyright (C) 2020 Team Triple Double, Diego Castagne
*/
using System.Collections;
using Afloat.Events;
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
        [SerializeField] private GameEvent _deathEvent = null;
        [SerializeField] private GameEvent _registerEvent = null;
        [SerializeField] private float _timeToKillPlayer = 0.5f;
        [SerializeField] private float _durationSlowedDown = 3f;
        [SerializeField] private float _durationStopped = 0.5f;
        [Header("Audio")] 
        [SerializeField] private AudioSourceController _dyingSFX;
        // ## PROPERTIES  ##
        public PotionType PotionToKill => _potionToKill;
        public bool Dead => _dead;
        // ## PUBLIC VARS ##
        // ## PROTECTED VARS ##
        // ## PRIVATE UTIL VARS ##
        private Rigidbody _rbd;
        private PlayerController _target;
        private bool _dead = false;
        private float _killingTimer = 0f;

#region // ## MONOBEHAVIOUR METHODS ##

        private void Awake()
        {
            _registerEvent.Raise();
        }

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

        private void OnCollisionStay(Collision other)
        {
            if(other.gameObject.TryGetComponent<PlayerController>(out PlayerController player))
            {
                _killingTimer += Time.fixedDeltaTime;

                if(_killingTimer > _timeToKillPlayer)
                {
                    player.Die();
                }
            }
        }

        private void OnCollisionExit(Collision other)
        {
            if(other.gameObject.TryGetComponent<PlayerController>(out PlayerController player))
            {
                _killingTimer = 0f;
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

            _dyingSFX.PlayImmediately();
            _dyingSFX.transform.parent = null;
            Destroy(_dyingSFX.gameObject, _dyingSFX.GetComponent<AudioSource>().clip.length);

            StartCoroutine(DyingRoutine());
        }

        public void SlowDown(float factor)
        {
            StartCoroutine(SlowedDownRoutine(_durationSlowedDown, _agent.speed));

            _agent.speed *= factor;
            _agent.isStopped = true;
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
            _deathEvent.Raise();
            Destroy(gameObject);
        }

        private IEnumerator SlowedDownRoutine(float duration, float originalSpeed)
        {
            yield return new WaitForSeconds(_durationStopped);
            _agent.isStopped = false;

            yield return new WaitForSeconds(duration);
            
            _agent.speed = originalSpeed;
        }


#endregion

    }
}
