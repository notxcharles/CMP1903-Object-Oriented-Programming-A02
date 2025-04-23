using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    internal class SaveHandler
    {
        private string _fileName;
        public SaveHandler()
        {
            
        }
        public static JsonSerializerSettings GetSettings()
        {
            JsonSerializerSettings jsonSettings = new JsonSerializerSettings();
            jsonSettings.TypeNameHandling = TypeNameHandling.All;
            jsonSettings.Formatting = Formatting.Indented;
            return jsonSettings;
        }
        public static GameState LoadFromFile()
        {
            string path = null;
            path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filePath = Path.Combine(path, "DungeonExplorerSave.json");

            // Check if file exists before attempting to read it
            if (File.Exists(filePath))
            {
                Console.WriteLine("EXISTS");
            }
            else
            {
                Console.WriteLine("DOES NOT EXIST");
                return null;
            }

            string fileContents = null;
            using (StreamReader sr = new StreamReader(filePath))
            {
                fileContents = sr.ReadToEnd();
            }
            JsonSerializerSettings jsonSettings = GetSettings();
            var loadedGameState = Newtonsoft.Json.JsonConvert.DeserializeObject<GameState>(fileContents, jsonSettings);
            return loadedGameState;
        }

        public static void SaveToFile(GameState gameState)
        {
            JsonSerializerSettings jsonSettings = GetSettings();

            // Create a filePath directory to C://My Documents/saveFile.txt
            string path = null;
            path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filePath = Path.Combine(path, "DungeonExplorerSave.json");

            // Convert gameState object to string
            var serialisedObject = Newtonsoft.Json.JsonConvert.SerializeObject(gameState, jsonSettings);
            //Write to filePath
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                sw.Write(serialisedObject);
            }
            
        }
    }
}
