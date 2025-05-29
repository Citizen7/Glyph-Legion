using System;
using UnityEngine;

namespace GlyphLegion {
    public class ResourceController : MonoBehaviour, IResourceController, IDataPersistence {
        public event Action ResourceIncreased;
        public event Action ResourceDescreased;
        public event Action<int> OnResourceChanged;

        [SerializeField] public float CharacterGenerationSpeed = 1.0f;
        
        [SerializeField] public float CharacterGenerationCooldown = 1.0f;        
        [SerializeField] public ResourceType thisResourceType;
        int resourceAmount;
        

        void Awake()
        {
            Debug.Log($"Awake called on {this.name}.");
            Debug.Log($"Unit Type is {thisResourceType.ToString()}");
        }
                
        void Start() {
            Debug.Log($"Start called on {this.name}.");
        }

        // Update is called once per frame
        void Update() {

        }

        void FixedUpdate() {

        }

        private void OnEnable() {
            
        }

        private void OnDisable() {

        }

        public void GenerateResource() {
            //resourceAmount += (int)(CharacterGenerationSpeed * Time.deltaTime);
            resourceAmount++;
            OnResourceChanged?.Invoke(resourceAmount);
            ResourceIncreased?.Invoke();
        }

        public void SpendResource() { SpendResource(0); }
        public void SpendResource(int cost) {
            if (cost > 0) 
                resourceAmount -= cost;
            else
                resourceAmount--;
            OnResourceChanged?.Invoke(resourceAmount);
            ResourceDescreased?.Invoke();
        }

        public void LoadData(GameData thisData) {
            if (thisData.PlayerInventory.ContainsKey(thisResourceType)) {
                resourceAmount = thisData.PlayerInventory[thisResourceType];
            }
        }
        
        public void SaveData(ref GameData thisData) {
            if (!thisData.PlayerInventory.ContainsKey(thisResourceType)) {
                thisData.PlayerInventory.Add(thisResourceType, resourceAmount);
            }
            else {
                thisData.PlayerInventory[thisResourceType] = resourceAmount;
            }
        }
    }
}