using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DungeonExplorer.Rooms
{
    public class RoomConverter : JsonConverter
    {


        public override bool CanConvert(Type objectType)
        {
            return typeof(Room).IsAssignableFrom(objectType);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            JObject obj = new JObject
            {
                 { "Type", value.GetType().Name }
            };
            foreach (var prop in value.GetType().GetProperties())
            {
                obj.Add(prop.Name, JToken.FromObject(prop.GetValue(value)));
            }
            obj.WriteTo(writer);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject obj = JObject.Load(reader);
            string type = obj["Type"].ToString();
            Room room;

            if (type == nameof(MonsterRoom))
            {
                room = new MonsterRoom();
            }
            else if (type == nameof(PuzzleRoom))
            {
                room = new PuzzleRoom();
            }
            else
            {
                room = new Room();
            }

            serializer.Populate(obj.CreateReader(), room);
            return room;
        }


    }
}
