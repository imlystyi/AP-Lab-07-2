/* Lab_07_2_Recursive_UT.cs
 * якубовський ¬ладислав
 * Unit-test до програми Lab_07_2_Recursive.cs */
namespace AP_Lab_07_2_Recursive_UT
{
    [TestClass]
    public class Lab_07_2_Recursive_UT
    {
        [TestMethod]
        public void TestGetIndexOfMaxFromMinInEvenCols()
        {
            /*      1 3 5 6
             *      2 4 5 2
             *      1 6 7 3
             *      3 4 8 8
             * 
             * mm: 1, 5 -> 5 [1, 2] */

            int[,] matrix = { { 1, 3, 5, 6 }, { 2, 4, 5, 2 }, { 1, 6, 7, 3 }, { 3, 4, 8, 8 } };

            int expectedMaxFromMinsInEvenCols = -1, minInEvenCol = 0, expectedFirstIndex = 0, expectedSecondIndex = 0;

            Lab_07_2_Recursive.GetIndexOfMaxFromMinInEvenCols(matrix, 4, 4, ref expectedMaxFromMinsInEvenCols, ref minInEvenCol, ref expectedFirstIndex, ref expectedSecondIndex);

            Assert.AreEqual(1, expectedFirstIndex);
            Assert.AreEqual(2, expectedSecondIndex);
            Assert.AreEqual(5, expectedMaxFromMinsInEvenCols);
        }

        [TestMethod]
        public void TestGetIndexOfMinFromMaxInOddCols()
        {
            /*      1 3 5 6
             *      2 4 5 2
             *      1 6 7 3
             *      3 4 8 8
             * 
             * mm: 6, 8 -> 6 [2, 1] */

            int[,] matrix = { { 1, 3, 5, 6 }, { 2, 4, 5, 2 }, { 1, 6, 7, 3 }, { 3, 4, 8, 8 } };

            int expectedMinFromMaxInOddCols = 10, maxInOddCol = 0, expectedFirstIndex = 0, expectedSecondIndex = 0;

            Lab_07_2_Recursive.GetIndexOfMinFromMaxInOddCols(matrix, 4, 4, ref expectedMinFromMaxInOddCols, ref maxInOddCol, ref expectedFirstIndex, ref expectedSecondIndex);

            Assert.AreEqual(2, expectedFirstIndex);
            Assert.AreEqual(1, expectedSecondIndex);
            Assert.AreEqual(6, expectedMinFromMaxInOddCols);
        }
    }
}
