/*
    Copyright (C) 2020 Team Triple Double, Diego Castagne
*/
using System.Collections;
using UnityEngine;

namespace Afloat
{
    public class GoblinController : MonoBehaviour
    {
        // ## UNITY EDITOR ##
        [SerializeField] private PotionType _potionToKill = null;
        [SerializeField] private float _timeToDie = 0.3f;
        // ## PROPERTIES  ##
        public PotionType PotionToKill => _potionToKill;
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

        public void Die()
        {
            _rbd.constraints = RigidbodyConstraints.None;
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
