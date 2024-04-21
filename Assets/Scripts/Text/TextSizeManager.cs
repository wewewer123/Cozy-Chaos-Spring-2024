using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace CozyChaosSpring2024
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class TextSizeManager : MonoBehaviour
    {
        public enum TextSizes
        {
            regular = 20,
            large = 24,
            extraLarge = 32
        }
        public static TextSizes size = TextSizes.regular;
        TextMeshProUGUI text;
        [SerializeField] HorizontalSelector selector;

        private void Start()
        {
            text = GetComponent<TextMeshProUGUI>();
            OnSizeChange();

            if (selector != null)
                selector.onOptionsChange += OnSizeChange;
        }

        public void OnSizeChange()
        {
            switch (size)
            {
                case TextSizes.regular:
                    text.fontSize = 20;
                    break;
                case TextSizes.large:
                    text.fontSize = 24;
                    break;
                case TextSizes.extraLarge:
                    text.fontSize = 32;
                    break;
            }
            
        }
    }
}
