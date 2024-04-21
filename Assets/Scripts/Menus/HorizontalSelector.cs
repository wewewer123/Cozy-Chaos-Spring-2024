using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CozyChaosSpring2024
{
    public class HorizontalSelector : MonoBehaviour
    {
        [SerializeField] private string[] options;
        private TextMeshProUGUI _text;
        private int _index;

        private void Start()
        {
            _text = transform.Find("Value").GetComponent<TextMeshProUGUI>();
            transform.Find("Left").GetComponent<Button>().onClick.AddListener(OnLeftClicked);
            transform.Find("Right").GetComponent<Button>().onClick.AddListener(OnRightClick);
        }

        private void OnLeftClicked()
        {
            if (_index == 0)
            {
                _index = options.Length;
            }
            _index--;
            ApplyChanges();
        }

        private void OnRightClick()
        {
            if (_index == options.Length - 1)
            {
                _index = -1;
            }
            _index++;
            ApplyChanges();
        }

        private void ApplyChanges()
        {
            _text.text = options[_index];
        }
    }
}
