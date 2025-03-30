using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    class Statistics
    {
        private List<int> _dealtDamage = new List<int>();
        private List<int> _receivedDamage = new List<int>();
        private int _numberOfCompletedRooms;

        public Statistics()
        {
            _numberOfCompletedRooms = 0;
        }

        public void PlayerDealtDamage(int damage)
        {
            _dealtDamage.Add(damage);
            return;
        }
        public void PlayerReceivedDamage(int damage)
        {
            _receivedDamage.Add(damage);
            return;
        }
        public void PlayerCompletedARoom()
        {
            _numberOfCompletedRooms += 1;
            return;
        }
        private int GetListTotal(List<int> list)
        {
            return list.Sum();
        }
        private int GetListCount(List<int> list)
        {
            return list.Count;
        }
        private float GetAverage(List<int> list)
        {
            int sum = GetListTotal(list);
            int count = GetListCount(list);
            return sum / count;
        }
        public string GetEndGameStatisticsString()
        {
            string stats = $"You dealt {GetListTotal(_dealtDamage)} damage in {GetListCount(_dealtDamage)} attacks, at an average of {GetAverage(_dealtDamage)} per attack.\n" +
                $"You received {GetListTotal(_receivedDamage)} damage in {GetListCount(_receivedDamage)} attacks, at an average of {GetAverage(_receivedDamage)} per attack.\n" +
                $"You completed {_numberOfCompletedRooms} rooms.\n";
            return stats;
        }
    }
}
