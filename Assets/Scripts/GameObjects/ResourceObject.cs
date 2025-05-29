using System;
using Unity.VisualScripting;
using UnityEngine;

namespace GlyphLegion {
    [Serializable]
    [CreateAssetMenu(fileName = "New Resource", menuName = "Scriptable Objects/Resource")]
    public class ResourceObject : ScriptableObject
    {
        [TextArea(1,1)]
        [Tooltip("Name")]
        public string ResourceName;
        public int ResourceAmount;
        public ResourceType ResourceType;
        
    }
}