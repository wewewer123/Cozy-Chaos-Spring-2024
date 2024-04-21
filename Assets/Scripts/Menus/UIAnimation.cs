using System;
using System.Collections;
using System.Collections.Generic;
using CrazyChaosSpring2024;
using DG.Tweening;
using UnityEngine;

namespace CozyChaosSpring2024
{
    public class UIAnimation : MonoBehaviour
    {
        private RectTransform _rectTransform;

        private Vector2 _defaultSizeDelta;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            _defaultSizeDelta = _rectTransform.sizeDelta;
        }

        public void Shrink()
        {
            // var scale = 1;
            // DOTween.To(() => scale, x => scale = x, 0, MainMenuManager.UIElemAnimDuration)
                // .OnUpdate(() => _rectTransform.localScale = new Vector3(scale, scale, 0));
            _rectTransform.DOSizeDelta(new Vector2(0, 0), MainMenuManager.UIElemAnimDuration).SetEase(Ease.InElastic);
        }

        public void Grow() => _rectTransform.DOSizeDelta(_defaultSizeDelta, MainMenuManager.UIElemAnimDuration).SetEase(Ease.OutElastic);
    }
}
