/*
    Copyright (C) 2020 Team Triple Double, Diego Castagne
*/
using System.Collections;
using Cinemachine;
using UnityEngine;

namespace Afloat
{
    public class ShowObjectCameraController : MonoBehaviour
    {
        // ## UNITY EDITOR ##
        [SerializeField] private CinemachineVirtualCameraBase _camera = null;
        [SerializeField] private float _duration = 0f;
        // ## PROPERTIES  ##
        // ## PUBLIC VARS ##
        // ## PROTECTED VARS ##
        // ## PRIVATE UTIL VARS ##
        private bool triggered = false;

#region // ## MONOBEHAVIOUR METHODS ##

        private void OnTriggerEnter(Collider other)
        {
            if(triggered) return;

            if(other.TryGetComponent<PlayerController>(out PlayerController player))
            {
                StartCoroutine(LookRoutine());
                triggered = true;
            }
        }

#endregion

#region // ## PUBLIC METHODS ##
#endregion
        
#region // ## <SOME INTERFACE> METHODS ##   
#endregion

#region // ## PROTECTED METHODS ##   
#endregion
        
#region // ## PRIVATE METHODS ##   

        private IEnumerator LookRoutine()
        {
            _camera.Priority = 15;
            yield return new WaitForSeconds(_duration);
            _camera.Priority = 0;
            gameObject.SetActive(false);
        }

#endregion

    }
}
