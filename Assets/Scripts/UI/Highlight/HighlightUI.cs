
/*
    Copyright (C) 2020 Team Triple Double, Sabastian Peters
*/

using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

namespace Afloat
{
    /*
        Class: HighlightUI

        The red + orange UI that surrounds the current button or input
    */
    [RequireComponent(typeof(CanvasGroup))]
    [RequireComponent(typeof(RectTransform))]
    public class HighlightUI : MonoBehaviour
    {
        
        // ## UNITY EDITOR ##

        [SerializeField] private EventTrigger _targetTrigger;


        // ## PUBLIC MEMBERS ##
        
        [System.NonSerialized] public RectTransform Transform;
        [System.NonSerialized] public CanvasGroup CanvasGroup;
        
        
              
#region // ## MONOBEHAVIOUR METHODS ##

        private void Awake()
        {
            CanvasGroup = GetComponent<CanvasGroup>();
            Transform = GetComponent<RectTransform>();
            
            Hide(0);


            float fadeTime = 0.25f;
            

            // Hover Start

            var hoverStartEvent = new EventTrigger.Entry()
            {
                eventID = EventTriggerType.PointerEnter
            };
            hoverStartEvent.callback.AddListener(data => Show(fadeTime));
            _targetTrigger.triggers.Add(hoverStartEvent);
            

            // Hover Stop

            var hoverStopEvent = new EventTrigger.Entry()
            {
                eventID = EventTriggerType.PointerExit
            };
            hoverStopEvent.callback.AddListener(data => Hide(fadeTime));
            _targetTrigger.triggers.Add(hoverStopEvent);
        }
        
#endregion     
              
#region // ## PUBLIC METHODS ##

        public virtual void Show(float fadeTime)
        {
            CanvasGroup.DOFade(1, fadeTime / 3f);
            
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).DOScaleX(1, fadeTime);
            }
        }

        public virtual void Hide(float fadeTime)
        {
            CanvasGroup.DOFade(0, fadeTime / 3f);

            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).DOScaleX(0, fadeTime);
            }
        }
        
#endregion     


#if UNITY_EDITOR

        private void OnValidate()
        {
            Hide(0f);
        }

#endif

    }
}