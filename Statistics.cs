using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    class Statistics
    {
        private static List<int> _dealtDamage = new List<int>();
        private static List<int> _receivedDamage = new List<int>();
        private static int _numberOfCompletedRooms;

        public Statistics()
        {
            _numberOfCompletedRooms = 0;
        }

        public static void PlayerDealtDamage(int damage)
        {
            _dealtDamage.Add(damage);
            return;
        }
        public static void PlayerReceivedDamage(int damage)
        {
            _receivedDamage.Add(damage);
            return;
        }
        public static void PlayerCompletedARoom()
        {
            _numberOfCompletedRooms += 1;
            return;
        }
        private static int GetListTotal(List<int> list)
        {
            return list.Sum();
        }
        private static int GetListCount(List<int> list)
        {
            return list.Count;
        }
        private static float GetAverage(List<int> list)
        {
            int sum = GetListTotal(list);
            int count = GetListCount(list);
            return sum / count;
        }
        public static string GetEndGameStatisticsString()
        {
            string stats = $"You dealt {GetListTotal(_dealtDamage)} damage in {GetListCount(_dealtDamage)} attacks, at an average of {GetAverage(_dealtDamage)} per attack.\n" +
                $"You received {GetListTotal(_receivedDamage)} damage in {GetListCount(_receivedDamage)} attacks, at an average of {GetAverage(_receivedDamage)} per attack.\n" +
                $"You completed {_numberOfCompletedRooms} rooms.\n";
            return stats;
        }
    }
}
