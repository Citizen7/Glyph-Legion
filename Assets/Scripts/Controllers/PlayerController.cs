using System.Collections;
using System.IO;
using NUnit.Framework.Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GlyphLegion {
    public class PlayerController : MonoBehaviour, IDataPersistence
    {
        public string PlayerName;
        public float PlayerMasterGenerationSpeed;
        public float PlayerMasterGenerationCooldown;
        public GameData thisGameData; // TODO: impliment this

        public void LoadData(GameData thisData) {
            throw new System.NotImplementedException();
        }

        public void SaveData(ref GameData thisData) {
            thisData.PlayerMasterGenerationCooldown = PlayerMasterGenerationCooldown;
        }

        void Awake() {
            Debug.Log("Awake called on PlayerController.");
        }
                
        void Start()
        {
            Debug.Log("Start called on PlayerController.");            
        }

        
        
    }
}