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
        // ## PROPERTIES  ##
        // ## PUBLIC VARS ##
        // ## PROTECTED VARS ##
        // ## PRIVATE UTIL VARS ##

#region // ## MONOBEHAVIOUR METHODS ##

        private void OnCollisionEnter(Collision other)
        {
            if(other.gameObject.TryGetComponent<GoblinController>(out GoblinController goblin))
            {
                if(_potionType == goblin.PotionToKill)
                {
                    goblin.Die();
                    // Raise a kill goblin event for score purposes
                }
            }

            // Play potion breaking sound here

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
