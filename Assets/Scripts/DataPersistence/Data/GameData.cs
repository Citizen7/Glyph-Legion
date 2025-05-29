using System.Collections.Generic;

namespace GlyphLegion {
    
    [System.Serializable]
    public class GameData {
        public bool HasPlayedTutorial;
        public string PlayerName;
        public float PlayerMasterGenerationSpeed;
        public float PlayerMasterGenerationCooldown;
        public Dictionary<ResourceType, int> PlayerInventory;
        public string CurrentScene;

        public GameData() {
            PlayerMasterGenerationSpeed = 1.0f;
            PlayerName = "Commander";
            PlayerInventory = new Dictionary<ResourceType,int>();
            HasPlayedTutorial = false;
        }
    }
}