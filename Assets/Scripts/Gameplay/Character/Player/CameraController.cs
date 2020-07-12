/*
    Copyright (C) 2020 Team Triple Double, Diego Castagne
*/
using System.Collections;
using Afloat.Util.Coroutines;
using Cinemachine;
using DG.Tweening;
using UnityEngine;

namespace Afloat
{
    public class CameraController : MonoBehaviour
    {
        // ## UNITY EDITOR ##
        [SerializeField] private CinemachineVirtualCamera _camera = null;
        [SerializeField] private float _shakeIntensity = 5f;
        [SerializeField] private float _shakeDuration = 0.5f;
        // ## PROPERTIES  ##
        // ## PUBLIC VARS ##
        // ## PROTECTED VARS ##
        // ## PRIVATE UTIL VARS ##
        private CinemachineBasicMultiChannelPerlin _noise;
        private CoroutineHandler _shakeRoutine;

#region // ## MONOBEHAVIOUR METHODS ##

        private void Awake()
        {
            _noise = _camera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            _shakeRoutine = new CoroutineHandler(this);
        }

#endregion

#region // ## PUBLIC METHODS ##

        public void ShakeCameraPotion()
        {
            //if(_shakeRoutine.IsRunning) return;

            _shakeRoutine.Start(ShakeRoutine());
        }

#endregion
        
#region // ## <SOME INTERFACE> METHODS ##   
#endregion

#region // ## PROTECTED METHODS ##   
#endregion
        
#region // ## PRIVATE METHODS ##   

        private IEnumerator ShakeRoutine()
        {
            _noise.m_AmplitudeGain = _shakeIntensity;

            float start = _shakeIntensity;
            float end = 0;
            float duration = _shakeDuration;

            DOTween.To(() => _noise.m_AmplitudeGain, x => _noise.m_AmplitudeGain = x, end, duration);

            yield return new WaitForSecondsRealtime(duration);
        }


#endregion

    }
}
