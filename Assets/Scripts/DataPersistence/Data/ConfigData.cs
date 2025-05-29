using System.Collections.Generic;

namespace GlyphLegion {
    
    [System.Serializable]
    public class ConfigData {
        public bool HasPlayedTutorial;
        public string PlayerName;
        public int SaveSlot;

        public ConfigData() {
            PlayerName = "Commander";
            HasPlayedTutorial = false;
            SaveSlot = 0;
        }
    }
}