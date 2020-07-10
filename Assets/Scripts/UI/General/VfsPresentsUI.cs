
/*
    Copyright (C) Sabastian Peters 2020
*/

using UnityEngine;
using UnityEngine.Video;

namespace Afloat.UI
{
    public class VfsPresentsUI : MonoBehaviour
    {


        // ## UNITY EDITOR ##
        
        [SerializeField] private VideoPlayer _targetVideo;
        
        // ## PRIVATE UTIL VARS ##
        
        private CanvasGroup[] _parentCanvasGroupList;  

        
        
        
#region // ## MONOBEHAVIOUR METHODS ##
        
        private void Start()
        {
            _parentCanvasGroupList = GetComponentsInParent<CanvasGroup>();
        }

        private void Update()
        {
            float targetAlpha = 1;
            foreach(var canvasGroup in _parentCanvasGroupList)
            {
                targetAlpha *= canvasGroup.alpha;
            }

            _targetVideo.targetCameraAlpha = targetAlpha < 0.05f ? 0 : targetAlpha;
        }

#endregion


    }
}
