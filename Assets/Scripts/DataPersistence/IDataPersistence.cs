namespace GlyphLegion {
    public interface IDataPersistence {
        void LoadData(GameData thisData);
        void SaveData(ref GameData thisData);
    }
}