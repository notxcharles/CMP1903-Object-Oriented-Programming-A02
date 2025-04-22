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
        //public GameState LoadFromFile();
        //{

        //}

        public static void SaveToFile(GameState gameState)
        {

            // Create a filePath directory to C://My Documents/saveFile.txt
            string path = null;
            path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filePath = Path.Combine(path, "saveFile.txt");

            using (StreamWriter sw = new StreamWriter(filePath))
            {
                sw.Write("Test");
            }
            //var serialisedObject = Newtonsoft.Json.JsonConvert.SerializeObject(gameState);
        }
    }
}
