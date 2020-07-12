
/*
    Copyright (C) 2020 Team Triple Double, Sabastian Peters
*/

using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Afloat
{
    /*
        Class: SliderHighlightUI
    */
    public class SliderHighlightUI : HighlightUI
    {
        
        // ## UNITY EDITOR ##
        
        [SerializeField] private Image _fill;
        [SerializeField] private TextMeshProUGUI _text;
        
        [Header("Colors")]
        [SerializeField] private ColorVariable _defaultColor;
        [SerializeField] private ColorVariable _highlightColor;

#region // ## PUBLIC METHODS ##
        
        public override void Show (float fadeTime)
        {
            base.Show(fadeTime);
            _text.DOColor(_highlightColor, fadeTime)
                .SetUpdate(true);
            _fill.DOColor(_highlightColor, fadeTime)
                .SetUpdate(true);
        }

        public override void Hide (float fadeTime)
        {
            base.Hide(fadeTime);
            _text.DOColor(_defaultColor, fadeTime)
                .SetUpdate(true);
            _fill.DOColor(_defaultColor, fadeTime)
                .SetUpdate(true);
        }
        
#endregion       

    }
}