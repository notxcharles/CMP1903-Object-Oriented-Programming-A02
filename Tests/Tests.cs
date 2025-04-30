using System.Diagnostics;

namespace DungeonExplorer
{
    /// <summary>
    /// Contains runtime tests for the game functionality.
    /// </summary>
    class Tests
    {
        public Tests()
        {

        } 
        /// <summary>
        /// Tests if <c>value</c> is positive
        /// </summary>
        /// <param name="value"></param>
        public static void TestForPositiveInteger(int value)
        {
            Debug.Assert(value > 0, "Error: Value wasn't a positive integer");
        }
        /// <summary>
        /// Tests if <c>value</c> is 0 or greater
        /// </summary>
        /// <param name="value"></param>
        public static void TestForZeroOrAbove(int value)
        {
            Debug.Assert(value >= 0, "Error: Value wasn't a positive integer or 0");
        }

    }
}
 