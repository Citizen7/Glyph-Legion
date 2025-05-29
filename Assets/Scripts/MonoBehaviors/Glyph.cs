using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GlyphLegion {
    public class Glyph : MonoBehaviour
    {
        public string GlyphName { get; private set; }
        

        void Awake()
        {
            Debug.Log($"Awake called on {this.name}.");

        }

        void Start() {
            Debug.Log($"Start called on {this.name}.");
        }
    }
}