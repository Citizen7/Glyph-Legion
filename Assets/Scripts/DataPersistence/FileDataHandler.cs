using UnityEngine;
using System.IO;
using System;
using GlyphLegion.OdinSerializer;

namespace GlyphLegion {
    public class FileDataHandler : IDataHandler {
        private string _dataDirectoryPath = "";
        private string _dataFileName = "";
        public string fullPath { get; private set; }

        public FileDataHandler(string dataDirectoryPath, string dataFileName) {
            this._dataDirectoryPath = dataDirectoryPath;
            this._dataFileName = dataFileName;
            // use Path.Combine accounts for system differences
            this.fullPath = Path.Combine(_dataDirectoryPath, _dataFileName);
            Debug.Log($"From {this}, fullPath is {this.fullPath}");
        }

        public bool DoesFileExist() {
            return File.Exists(fullPath);
        }

        public GameData Load() {
            GameData ld = null;

            if (DoesFileExist()) {
                try {
                    // load serialized data from file
                    byte[] dtl = File.ReadAllBytes(fullPath);

                    // deserialize the data from Json
                    ld = SerializationUtility.DeserializeValue<GameData>(dtl, DataFormat.JSON);
                }
                catch (Exception ex) {
                    Debug.LogError($"Error occured when trying to load data from file: {fullPath} \n {ex.Message}");
                }
            }

            return ld;
        }

        public void Save(GameData data) {
            try {
                // create directory if not already existing
                Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

                // serialize the game data to Json
                byte[] dts = SerializationUtility.SerializeValue(data, DataFormat.JSON);
                File.WriteAllBytes(fullPath, dts);
            }
            catch (Exception ex) {
                Debug.LogError($"Error occured when trying to save data to file: {fullPath} \n {ex.Message}");
            }
        }
        
        public ConfigData LoadConfig() {
            ConfigData ld = null;
            
            if (DoesFileExist()) {
                try {
                    // load serialized data from file
                    byte[] dtl = File.ReadAllBytes(fullPath);

                    // deserialize the data from Json
                    ld = SerializationUtility.DeserializeValue<ConfigData>(dtl, DataFormat.JSON);
                }
                catch (Exception ex) {
                    Debug.LogError($"Error occured when trying to load data from file: {fullPath} \n {ex.Message}");
                }
            }

            return ld;
        }

        public void SaveConfig(ConfigData data) {
            try {
                // create directory if not already existing
                Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

                // serialize the game data to Json
                byte[] dts = SerializationUtility.SerializeValue(data, DataFormat.JSON);
                File.WriteAllBytes(fullPath, dts);                
            }
            catch (Exception ex) {
                Debug.LogError($"Error occured when trying to save data to file: {fullPath} \n {ex.Message}");
            }
        }
    }
}