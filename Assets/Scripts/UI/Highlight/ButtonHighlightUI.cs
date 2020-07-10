
/*
    Copyright (C) 2020 Team Triple Double, Sabastian Peters
*/

using TMPro;
using UnityEngine;
using DG.Tweening;

namespace Afloat
{
    /*
        Class: ButtonHighlightUI
    */
    public class ButtonHighlightUI : HighlightUI
    {
        
        // ## UNITY EDITOR ##
        
        [SerializeField] private TextMeshProUGUI _text;

        [Header("Colors")]
        [SerializeField] private ColorVariable _defaultColor;
        [SerializeField] private ColorVariable _highlightColor;
        


#region // ## PUBLIC METHODS ##
                
        public override void Show (float fadeTime)
        {
            base.Show(fadeTime);
            _text.DOColor(_highlightColor, fadeTime);
        }

        public override void Hide (float fadeTime)
        {
            base.Hide(fadeTime);
            _text.DOColor(_defaultColor, fadeTime);
        }
        
#endregion       

    }
}