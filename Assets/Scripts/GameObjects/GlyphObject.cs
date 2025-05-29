using UnityEngine;

namespace GlyphLegion {
    [CreateAssetMenu(fileName = "GlyphObject", menuName = "Scriptable Objects/GlyphObject")]
    public class GlyphObject : ScriptableObject
    {
        [TextArea(1,1)]
        [Tooltip("Name")]
        public string GlyphName;

        [SerializeField] private ResourceObject thisResourceType;
    }
}