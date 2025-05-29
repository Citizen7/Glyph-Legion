namespace GlyphLegion {
    public interface IDataHandler {
        GameData Load();
        void Save(GameData data);
        bool DoesFileExist();
    }

    public enum DataHandlerType {
        File,
        Cloud
    }
}