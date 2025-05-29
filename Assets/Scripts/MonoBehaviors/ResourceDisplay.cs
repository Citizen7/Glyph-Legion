using System.Collections;
using TMPro;
using UnityEngine;

namespace GlyphLegion {
    public class ResourceDisplay : MonoBehaviour
    {
        public ResourceObject thisResource;
        [SerializeField] private GameObject _label;
        [SerializeField] private GameObject _value;
        TMP_Text labelText;
        TMP_Text valueText;

        void Awake()
        {
            labelText = _label.GetComponent<TMP_Text>();
            valueText = _value.GetComponent<TMP_Text>();
            Debug.Assert(null != labelText, $"No label found for {thisResource.name}.");
            Debug.Assert(null != valueText, $"No value found for {thisResource.name}.");
        }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start() {
            labelText.text = thisResource.ResourceName + ":";
            valueText.text = thisResource.ResourceAmount.ToString();
        }        

        public void UpdateDisplay(int value) {
            valueText.text = value.ToString();
        }
    }
}