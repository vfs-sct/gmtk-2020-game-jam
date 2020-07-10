
/*
    Copyright (C) 2020 Team Triple Double, Sabastian Peters
*/

using UnityEngine;
using System.Collections;

namespace Afloat.UI
{
    public class UIFollowWorldTargetController : MonoBehaviour
    {

        
        // ## UNITY EDITOR ##
        
        [SerializeField] private Transform _target = null;
        [SerializeField] private Vector3Variable _followTarget = null;
        [SerializeField] private BoolVariable _shouldShow = null;
        [SerializeField] private float _lerpFactor = 10;

        
        // ## PRIVATE UTIL VARS ##
        
        Camera _targetCamera = null;
        Vector3 _targetPosition = Vector3.zero;

        
        
        
#region // ## MONOBEHAVIOUR METHODS ##

        private IEnumerator Start()
        {
            yield return null; /// we need to wait a frame for all scenes to load
            // TODO: in production this should be a scriptable object (ie. CameraReference) that we can null check by using "onValueChanged" in case the play is loaded in after this scene already exists (ie Camera doesnt exist at start)
            _targetCamera = Camera.main;
        }

        private void Update()
        {
            UpdateTargetPosition();

            _target.transform.position = Vector3.Lerp(_target.transform.position, _targetPosition, _lerpFactor * Time.deltaTime);
        }

        private void OnEnable()
        {
            UpdateTargetPosition();
        }

#endregion

#region // ## PRIVATE UITL METHODS ##   
        
        private void UpdateTargetPosition ()
        {
            
            // exit if we shouldn't show or not facing target
            if(_shouldShow == false || IsFacingTarget() == false)
            {
                _target.gameObject.SetActive(false);
                return;
            }


            // determines the new target position and moves the icon there immedately if we're just showing it
            _targetPosition = _targetCamera.WorldToScreenPoint(_followTarget.Value);
            if(_target.gameObject.activeSelf == false)
            {
                _target.transform.position = _targetPosition;
            }

            // ensure we're displaying the graphic
            _target.gameObject.SetActive(true);
        }
        
        private bool IsFacingTarget ()
        {
            if(_targetCamera == null || _followTarget == null) return false;
            // if the dot product between 
                // camera forward and 
                // direction to target from camera 
                // is positive, 
                    // the camera is looking in direction of target
            return 0 < Vector3.Dot(_targetCamera.transform.forward, _followTarget.Value - _targetCamera.transform.position);
        }

#endregion

    }
}
