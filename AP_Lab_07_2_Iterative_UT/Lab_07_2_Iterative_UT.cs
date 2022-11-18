/* Lab_07_2_Iterative_UT.cs
 * якубовський ¬ладислав
 * Unit-test до програми Lab_07_2_Iterative.cs */
namespace AP_Lab_07_2_Iterative_UT
{
    [TestClass]
    public class Lab_07_2_Iterative_UT
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

            Lab_07_2_Iterative.GetIndexOfMaxFromMinInEvenCols(matrix, 1, out int expectedFirstIndex, out int expectedSecondIndex, out int expectedMaxFromMinsInEvenCols);

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

            Lab_07_2_Iterative.GetIndexOfMinFromMaxInOddCols(matrix, 8, out int expectedFirstIndex, out int expectedSecondIndex, out int expectedMinFromMaxInOddCols);

            Assert.AreEqual(2, expectedFirstIndex);
            Assert.AreEqual(1, expectedSecondIndex);
            Assert.AreEqual(6, expectedMinFromMaxInOddCols);
        }
    }
}
