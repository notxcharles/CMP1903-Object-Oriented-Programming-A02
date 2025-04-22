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
        private JsonSerializerSettings _jsonSettings;
        public SaveHandler()
        {
            _jsonSettings = new Newtonsoft.Json.JsonSerializerSettings();
            _jsonSettings.TypeNameHandling = TypeNameHandling.All;
        }

        //public GameState LoadFromFile()
        //{

        //}

        public static void SaveToFile(GameState gameState)
        {
            // Create a filePath directory to C://My Documents/saveFile.txt
            string path = null;
            path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filePath = Path.Combine(path, "saveFile.txt");

            // Convert gameState object to string
            var serialisedObject = Newtonsoft.Json.JsonConvert.SerializeObject(gameState, Formatting.Indented);
            //Write to filePath
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                sw.Write(serialisedObject);
            }
            
        }
    }
}
