using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace CozyChaosSpring2024
{
    public class UIAnimation : MonoBehaviour
    {
        private static float TweeningDuration = 0.6f;
        private RectTransform _rectTransform;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
        }

        public void Shrink()
        {
            _rectTransform.DOSizeDelta(new Vector2(0, 0), TweeningDuration).SetEase(Ease.InElastic);
        }
    }
}
