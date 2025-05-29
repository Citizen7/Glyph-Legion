using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;
using Unity.VisualScripting;
using System;


namespace GlyphLegion {
    public class MasterGameController : MonoBehaviour, IDataPersistence {
        // Scene Items
        public GameObject GameMenu;
        public Button StartButton;
        public Button LoadButton;
        public Button EndButton;
        public Button ConfigButton;
        public Button ExitConfigButton;
        public GameObject LoadingInterface;
        public GameObject ConfigMenu;
        public Image LoadingProgressBar;
        public int SaveSlot;
        public string PlayerName;

        // Controller Items
        private MasterGameController _instance;
        private List<AsyncOperation> _scenesToLoad = new List<AsyncOperation>();
        private DataPersistenceManager _dpm;
        private bool _hasPlayedTutorial;
        private string _thisScene;
        private ConfigData _thisConfig;
        void Awake() {
            Debug.Log($"Awake called on MasterGameController. SaveSlot is {SaveSlot}.");

            // there should only be one of this controller and it should persist
            if (_instance != null && _instance != this) {
                Destroy(this.gameObject);
                return;
            }
            _instance = this;
            DontDestroyOnLoad(this.gameObject);

            // add configuration to master game controller
            _dpm = _instance.AddComponent<DataPersistenceManager>();

            // load configuration for system level settings
            _thisConfig = _dpm.LoadConfig();
            SaveSlot = _thisConfig.SaveSlot;
            Debug.Log($"Config is loaded. SaveSlot is now {SaveSlot}.");

            // initialize data persistence manager
            _dpm.Initialize(SaveSlot);
            Debug.Assert(null != _dpm, "Data Persistence Manager failed to load.");
        }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start() {
            GameMenu.GetComponent<Canvas>();
            LoadingInterface.GetComponent<Canvas>();
            StartButton.GetComponent<Button>();
            StartButton.onClick.AddListener(StartNewGame);
            LoadButton.GetComponent<Button>();
            LoadButton.onClick.AddListener(LoadGame);
            EndButton.GetComponent<Button>();
            EndButton.onClick.AddListener(ExitGame);
            LoadingProgressBar.GetComponent<Image>();
            ConfigMenu.GetComponent<Canvas>();
            ConfigButton.GetComponent<Button>();
            ConfigButton.onClick.AddListener(ShowSettingsMenu);
            ExitConfigButton.GetComponent<Button>();
            ExitConfigButton.onClick.AddListener(CloseSettingsMenu);            
        }

        // Update is called once per frame
        void Update() {

        }

        public void StartNewGame() {
            Debug.Log("Game begun.");
            _dpm.NewGame();
            if (!_hasPlayedTutorial) {
                _thisScene = "Tutorial";
            }
            else {
                int r = UnityEngine.Random.Range(0, 5);
                switch (r) {
                    case 0: _thisScene = "Start_Void"; break;
                    case 1: _thisScene = "Start_Earth"; break;
                    case 2: _thisScene = "Start_Air"; break;
                    case 3: _thisScene = "Start_Fire"; break;
                    case 4: _thisScene = "Start_Water"; break;
                }
            }

            HideMenu();
            SceneLoadingProtocol();
        }

        public void LoadGame() {
            Debug.Log("Game loaded.");
            _dpm.LoadGame();
        }

        public void ExitGame() {
            Debug.Log("Game ended.");
            Application.Quit();
        }

        private void HideMenu() {
            GameMenu.SetActive(false);
        }

        private void ShowLoadingScreen() {
            LoadingInterface.SetActive(true);
        }

        private void ShowSettingsMenu() {
            ConfigMenu.SetActive(true);
        }

        private void CloseSettingsMenu() {
            ConfigMenu.SetActive(false);
        }

        private void SceneLoadingProtocol() {
            ShowLoadingScreen();
            _scenesToLoad.Add(SceneManager.LoadSceneAsync("PlayerScene", LoadSceneMode.Additive));
            _scenesToLoad.Add(SceneManager.LoadSceneAsync(_thisScene, LoadSceneMode.Additive));
            StartCoroutine(LoadingScreen());
        }

        IEnumerator LoadingScreen() {
            float totalProgress = 0;
            for (int i = 0; i < _scenesToLoad.Count; i++) {
                while (!_scenesToLoad[i].isDone) {
                    totalProgress += _scenesToLoad[i].progress;
                    LoadingProgressBar.fillAmount = totalProgress/_scenesToLoad.Count;
                    yield return null;
                }
            }
        }

        public void ChangeSaveSlot(Toggle saveSlotSelector) {
            int thisSaveSlot = 0;
            if (saveSlotSelector.isOn) {
                switch (saveSlotSelector.name) {
                    case "SaveSlot1":
                        thisSaveSlot = 1;
                        break;
                    case "SaveSlot2":
                        thisSaveSlot = 2;
                        break;
                    case "SaveSlot3":
                        thisSaveSlot = 3;
                        break;
                    default:
                        Debug.LogWarning("Save slot not found");
                        break;
                }
            }
            else {
                Debug.Log($"This {saveSlotSelector} untoggled.");
                return;
            }
            if (thisSaveSlot == SaveSlot) {
                Debug.Log($"SaveSlot unchanged.");
            }
            else {
                SaveSlot = thisSaveSlot;
                // delete old data manager                
                _dpm.Initialize(SaveSlot);
                Debug.Log($"SaveSlot now {_dpm.SaveSlot}.");
            }
        }

        public void LoadConfig(ConfigData thisData) {
            _hasPlayedTutorial = thisData.HasPlayedTutorial;
            SaveSlot = thisData.SaveSlot;
            PlayerName = thisData.PlayerName;
        }

        public void SaveConfig(ref ConfigData thisData) {
            thisData.HasPlayedTutorial = _hasPlayedTutorial;
            thisData.SaveSlot = SaveSlot;
            thisData.PlayerName = PlayerName;
        }

        public void LoadData(GameData thisData) {
            
            _thisScene = thisData.CurrentScene;
            HideMenu();
            SceneLoadingProtocol();
        }

        public void SaveData(ref GameData thisData) {
            if (null != _thisScene)
                thisData.CurrentScene = _thisScene;
        }
    }
}