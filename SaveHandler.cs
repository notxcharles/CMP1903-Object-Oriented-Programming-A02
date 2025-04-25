using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{

    /// <summary>
    /// Handles saving and loading game state to and from a file.
    /// </summary
    internal class SaveHandler
    {
        private static string _fileName = "DungeonExplorerSave.json";
        private static string _path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        private static string _filePath = Path.Combine(_path, _fileName);
        /// <summary>
        /// Initializes a new instance of the <see cref="SaveHandler"/> class.
        /// </summary>
        public SaveHandler()
        {
            
        }
        /// <summary>
        /// Gets the JSON serializer settings for serializing and deserializing game state.
        /// </summary>
        /// <returns>A <see cref="JsonSerializerSettings"/> object configured for game state serialization.</returns>
        public static JsonSerializerSettings GetJsonSerializerSettings()
        {
            JsonSerializerSettings jsonSettings = new JsonSerializerSettings();
            jsonSettings.TypeNameHandling = TypeNameHandling.All;
            jsonSettings.Formatting = Formatting.Indented;
            return jsonSettings;
        }
        /// <summary>
        /// Loads the game state from a file.
        /// </summary>
        /// <returns>The loaded <see cref="GameState"/> object, or null if the file does not exist.</returns>
        /// <remarks>
        public static GameState GetGameStateFromFile()
        {
            // Check if file exists before attempting to read it
            if (!File.Exists(_filePath))
            {
                return null;
            }

            string fileContents = null;
            using (StreamReader sr = new StreamReader(_filePath))
            {
                fileContents = sr.ReadToEnd();
            }
            JsonSerializerSettings jsonSettings = GetJsonSerializerSettings();
            var loadedGameState = Newtonsoft.Json.JsonConvert.DeserializeObject<GameState>(fileContents, jsonSettings);
            return loadedGameState;
        }
        /// <summary>
        /// Saves the game state to a file.
        /// </summary>
        /// <param name="gameState">The <see cref="GameState"/> object to be saved.</param>
        public static void SaveGameStateToFile(GameState gameState)
        {
            JsonSerializerSettings jsonSettings = GetJsonSerializerSettings();
            // Convert gameState object to string
            var serialisedObject = Newtonsoft.Json.JsonConvert.SerializeObject(gameState, jsonSettings);
            //Write to filePath
            using (StreamWriter sw = new StreamWriter(_filePath))
            {
                sw.Write(serialisedObject);
            }
            return;
        }
    }
}
