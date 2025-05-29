using Unity.VisualScripting;
using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using System;

namespace GlyphLegion {
    public class DataPersistenceManager : MonoBehaviour {
        [HeaderAttribute("File Storage Config")]
        public int SaveSlot { get; private set; }
        [SerializeField] public string fileName;
        private IDataHandler _dataHandler;
        public static DataPersistenceManager Instance { get; private set; }
        private List<IDataPersistence> _dataPersistenceObjects;
        private GameData _gameData;
        private ConfigData _configData;
        private DataHandlerType _handlerType = DataHandlerType.File; // TODO : Implement cloud save/load

        public void Initialize(int saveSlot) {
            SaveSlot = saveSlot;

            InitializeSaveSlot();
            InitializeDataHandler();           

            Debug.Log($"DPM called {_dataHandler}.");
        }

        private void Awake() {
            if (null != Instance) {
                Debug.LogError("DataPersistenceManager duplicate found.");
            }
            Instance = this;
            
            Debug.Log($"Awake called on DPM. Handler is {_handlerType} type. Slot is {SaveSlot}. File name is {fileName}.");            
        }

        void OnEnable() {
            Debug.Log($"OnEnable called on DPM. Handler is {_handlerType} type. Slot is {SaveSlot}.  File name is {fileName}.");
        }

        private void Start() {            
            Debug.Log($"Start called on DPM. Handler is {_handlerType} type. Slot is {SaveSlot}. File name is {fileName}.");
            // do nothing if not initialized
            if (null == _dataHandler)
                Debug.LogWarning("DPM was not initialized before Start method.");


            this._dataPersistenceObjects = FindAllDataPersistenceObjects();
        }

        public void NewGame() {
            this._gameData = new GameData();
        }

        public void LoadGame() {
            // load any saved data from data source
            this._gameData = _dataHandler.Load();

            // if no data found, initialize and warn
            if (null == this._gameData) {
                Debug.LogError("Game data not found. Initializing game state.");
                NewGame();
            }
            
            // push loaded data where necessary
            foreach (IDataPersistence dpo in this._dataPersistenceObjects) {
                dpo.LoadData(this._gameData);
            }
        }

        public void SaveGame() {
            // pass data to necessary scripts for update
            foreach (IDataPersistence dpo in this._dataPersistenceObjects) {
                dpo.SaveData(ref this._gameData);
            }

            // save any appropriate data using data source
            _dataHandler.Save(_gameData);
        }

        public bool SaveFileExists() {
            if (null != _dataHandler)
                return _dataHandler.DoesFileExist();
            else {
                Debug.Log("DataHandler not found.");
                return false;
            }
        }

        public ConfigData LoadConfig() {
            // initialize a new config in case of inability to load
            ConfigData result = new ConfigData();

            // initialize data handler
            // TODO : make config path dynamic?
            FileDataHandler configHandler = new FileDataHandler(Application.persistentDataPath, "ConfigFile");
            try {
                // attempt to load previously saved config
                result = configHandler.LoadConfig();
            }
            catch (Exception ex) { Debug.LogError($"Unable to load config file. /n {ex.Message}"); }

            return result;
        }

        public void SaveConfig(ref ConfigData thisConfig) {
            FileDataHandler configHandler = new FileDataHandler(Application.persistentDataPath, "ConfigFile");
            configHandler.SaveConfig(thisConfig);
        }

        private void InitializeSaveSlot() {
            // handle limited save slot logic
            switch (SaveSlot) {
                case 1:
                    fileName = "saveslot1";
                    break;
                case 2:
                    fileName = "saveslot2";
                    break;
                case 3:
                    fileName = "saveslot3";
                    break;
                default:
                    fileName = "saveslot0";
                    break;
            }
        }

        private void InitializeDataHandler() {
            // setup file handler
            switch (_handlerType) {
                case DataHandlerType.File: {
                        Debug.Log($"switch .File reached");
                        _dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);

                        break;
                    }
                case DataHandlerType.Cloud:
                    throw new NotImplementedException(); // TODO : Implement cloud save/load
                    //break;
            }
        }

        private void OnApplicationQuit() {
            SaveGame();
        }

        private List<IDataPersistence> FindAllDataPersistenceObjects() {
            IEnumerable<IDataPersistence> dpo = FindObjectsByType<MonoBehaviour>(sortMode: FindObjectsSortMode.None)
                .OfType<IDataPersistence>();

                return new List<IDataPersistence>(dpo);
        }
    }
}