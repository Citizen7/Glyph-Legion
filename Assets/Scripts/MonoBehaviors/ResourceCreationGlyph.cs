using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GlyphLegion {
    public class ResourceCreationGlyph : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
        public event Action OnGlyphActivate;
        public event Action OnGlyphDeactivate;
        public void OnPointerDown(PointerEventData data) {
            //Do the thing when button pressed
            Debug.Log($"{this.name} button pressed!");
            OnGlyphActivate?.Invoke();
        }

        public void OnPointerUp(PointerEventData data) {
            //Do the thing when button released
            Debug.Log($"{this.name} button released!");
            OnGlyphDeactivate?.Invoke();
        }        
    }
}