using System;
using UnityEngine;

namespace CrazyChaosSpring2024
{
    public enum ClipType
    {
        Menu,
        Level
    }
    [Serializable]
    public class M_AudioClip
    {
        public string name;
        public AudioClip clip;
        public ClipType type;
    }
}