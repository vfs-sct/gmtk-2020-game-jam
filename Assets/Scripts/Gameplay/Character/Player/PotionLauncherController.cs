/*
    Copyright (C) 2020 Team Triple Double, Diego Castagne
*/
using UnityEngine;

namespace Afloat
{
    public class PotionLauncherController : MonoBehaviour
    {
        // ## UNITY EDITOR ##
        [SerializeField] private PotionType _potionTypeToShoot = null; // this is for now, but we'll get this from the "pouch"
        [SerializeField] private float _launchSpeed = 8f;
        // ## PROPERTIES  ##
        // ## PUBLIC VARS ##
        // ## PROTECTED VARS ##
        // ## PRIVATE UTIL VARS ##

#region // ## MONOBEHAVIOUR METHODS ##
#endregion

#region // ## PUBLIC METHODS ##

        public void ShootNextPotion()
        {
            Debug.Log($"I just shot a {_potionTypeToShoot.Name}");
            
            var potion = Instantiate(_potionTypeToShoot.PotionPrefab, transform.position, transform.rotation);
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
