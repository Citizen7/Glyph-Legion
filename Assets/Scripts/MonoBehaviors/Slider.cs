using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GlyphLegion {
    public class Slider : MonoBehaviour
    {
        public float SliderValue = 0;

        void Start() {
            Debug.Log($"Slider started.");
        }
    }
}