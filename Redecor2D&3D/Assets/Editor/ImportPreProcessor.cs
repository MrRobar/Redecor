using UnityEditor;

namespace Importer.Editor
{
    class ImportPreProcessor : AssetPostprocessor
    {
        void OnPreprocessTexture()
        {
            // получаем ссылку на встроенный TextureImporter
            TextureImporter importer = (TextureImporter)assetImporter;

            // создаём новый экземпляр настроек
            TextureImporterPlatformSettings textureImporterSettings = new TextureImporterPlatformSettings();

            // читаем текущие настройки дефолтные
            // заполняем ими наши недавно созданные настройки
            importer.GetDefaultPlatformTextureSettings();

            importer.textureType = TextureImporterType.Sprite;

            // меняем Max Size
            textureImporterSettings.maxTextureSize = 2048;
            // устанавливаем HQ качество
            textureImporterSettings.textureCompression = TextureImporterCompression.CompressedHQ;

            // применяем
            importer.SetPlatformTextureSettings(textureImporterSettings);
        }
    }
}