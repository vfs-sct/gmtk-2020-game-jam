/*
    Copyright (C) 2020 Team Triple Double, Diego Castagne
*/
using UnityEngine;

namespace Afloat
{
    public class ThrownPotionController : MonoBehaviour
    {
        // ## UNITY EDITOR ##
        [SerializeField] private PotionType _potionType = null;
        [SerializeField] private float _splashRange = 0.5f;
        [SerializeField] private LayerMask _goblinsLayerMask = default;
        [Header("Audio")]
        [SerializeField] private AudioSourceController _explosionSFX;
        // ## PROPERTIES  ##
        // ## PUBLIC VARS ##
        // ## PROTECTED VARS ##
        // ## PRIVATE UTIL VARS ##

#region // ## MONOBEHAVIOUR METHODS ##

        private void OnCollisionEnter(Collision other)
        {
            var colliders = Physics.OverlapSphere(transform.position, _splashRange, _goblinsLayerMask, QueryTriggerInteraction.Ignore);
            
            foreach (Collider col in colliders)
            {
                if(col.gameObject.TryGetComponent<GoblinController>(out GoblinController goblin))
                {
                    if(_potionType == goblin.PotionToKill)
                    {
                        goblin.Die();
                        // Raise a kill goblin event for score purposes
                    }
                }
            }

            _explosionSFX.PlayImmediately();
            _explosionSFX.transform.parent = null;
            Destroy(_explosionSFX.gameObject, _explosionSFX.GetComponent<AudioSource>().clip.length);

            var vfx = Instantiate(_potionType.VFXPrefab, transform.position, Quaternion.identity);
            
            Destroy(vfx, 5f);
            Destroy(gameObject);
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
