/*
    Copyright (C) 2020 Team Triple Double, Diego Castagne
*/
using UnityEngine;

namespace Afloat
{
    public class PotionLauncherController : MonoBehaviour
    {
        // ## UNITY EDITOR ##
        [SerializeField] private PotionPouchController _potionPouch = null;
        [SerializeField] private float _launchSpeed = 8f;
        [SerializeField] private Rigidbody _playerRigidbody = null;
        [Header("Audio")]
        [SerializeField] private AudioSourceController _throwSFX;
        // ## PROPERTIES  ##
        // ## PUBLIC VARS ##
        // ## PROTECTED VARS ##
        // ## PRIVATE UTIL VARS ##

#region // ## MONOBEHAVIOUR METHODS ##
#endregion

#region // ## PUBLIC METHODS ##

        public void ShootNextPotion()
        {
            PotionType potionToShoot = _potionPouch.GetNextPotionType();

            Debug.Log($"I just shot a {potionToShoot.Name}");

            _throwSFX.PlayImmediately();
            
            var potion = Instantiate(potionToShoot.PotionPrefab, transform.position, transform.rotation);
            if(potion.TryGetComponent<Rigidbody>(out Rigidbody potionRBD))
            {
                potionRBD.velocity = (transform.forward * _launchSpeed) + _playerRigidbody.velocity;
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
