using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    /// <summary>
    /// Represents the player's game statistics, including damage dealt, damage received, and number of completed rooms.
    /// Provides methods for updating and retrieving these statistics throughout the game.
    /// </summary>

    public class Statistics
    {
        private List<int> _dealtDamage = new List<int>();
        private List<int> _receivedDamage = new List<int>();
        private int _numberOfCompletedRooms;
        /// <summary>
        /// Initializes a new instance of the <see cref="Statistics"/> class.
        /// This constructor initializes the number of completed rooms to 0.
        /// </summary>
        public Statistics()
        {
            _numberOfCompletedRooms = 0;
        }
        public int GetTotalDamageDealt
        {
            get { return GetListTotal(_dealtDamage); }
        }
        // TODO: Documentation comments
        public List<int> DealtDamage
        {
            get { return _dealtDamage; }
        }
        public List<int> ReceivedDamage
        {
            get { return _receivedDamage; }
        }
        public int NumberOfCompletedRooms
        {
            get { return _numberOfCompletedRooms; }
        }
        /// <summary>
        /// Adds the given damage value to the list of damage dealt by the player.
        /// </summary>
        /// <param name="damage">The amount of damage dealt by the player.</param>
        public void PlayerDealtDamage(int damage)
        {
            _dealtDamage.Add(damage);
            return;
        }
        /// <summary>
        /// Adds the given damage value to the list of damage received by the player.
        /// </summary>
        /// <param name="damage">The amount of damage received by the player.</param>
        public void PlayerReceivedDamage(int damage)
        {
            _receivedDamage.Add(damage);
            return;
        }
        /// <summary>
        /// Increments the number of rooms completed by the player.
        /// </summary>
        public void PlayerCompletedARoom()
        {
            _numberOfCompletedRooms += 1;
            return;
        }
        /// <summary>
        /// Calculates and returns the total sum of all values in the specified list.
        /// </summary>
        /// <param name="list">The list of integers to sum.</param>
        /// <returns>The total sum of the integers in the list.</returns>
        private int GetListTotal(List<int> list)
        {
            return list.Sum();
        }
        /// <summary>
        /// Returns the count of elements in the specified list.
        /// </summary>
        /// <param name="list">The list whose count is to be returned.</param>
        /// <returns>The number of elements in the list.</returns>
        private int GetListCount(List<int> list)
        {
            return list.Count;
        }
        /// <summary>
        /// Calculates and returns the average value of the integers in the specified list.
        /// </summary>
        /// <param name="list">The list of integers for which to calculate the average.</param>
        /// <returns>The average value of the integers in the list.</returns>
        private float GetAverage(List<int> list)
        {
            int sum = GetListTotal(list);
            int count = GetListCount(list);
            return sum / count;
        }
        /// <summary>
        /// Generates a formatted string containing the player's end-game statistics, including the damage dealt, damage received, and number of completed rooms.
        /// </summary>
        /// <returns>A string summarizing the player's end-game statistics.</returns>
        public string GetEndGameStatisticsString()
        {
            string stats = $"You dealt {GetListTotal(_dealtDamage)} damage in {GetListCount(_dealtDamage)} attacks, at an average of {GetAverage(_dealtDamage)} per attack.\n" +
                $"You received {GetListTotal(_receivedDamage)} damage in {GetListCount(_receivedDamage)} attacks, at an average of {GetAverage(_receivedDamage)} per attack.\n" +
                $"You completed {_numberOfCompletedRooms} rooms.\n";
            return stats;
        }
    }
}
