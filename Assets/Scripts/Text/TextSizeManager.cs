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
            regular,
            large,
            extraLarge
        }
        public static TextSizes size = TextSizes.regular;
        TextMeshProUGUI text;
        [SerializeField] HorizontalSelector selector;

        private void Awake()
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
                    text.fontSize = 30;
                    break;
                case TextSizes.large:
                    text.fontSize = 34;
                    break;
                case TextSizes.extraLarge:
                    text.fontSize = 42;
                    break;
            }
            
        }
    }
}
