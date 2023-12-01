namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void CheckSumOfPositives()
        {
            var array = new[] { 0, -5, 3, 2, 1 };

            var actualSum = Program.SumOfPositive(array);

            var expectedSum = array.Where(i => i > 0).Sum();
            Assert.Equal(expectedSum, actualSum);
        }

        [Fact]

        public void IsResBetweenAbsValid()
        {
            var array = new[] { -4, 3, 2, 1 };
            var expectedRes = 6;
            var actualRes = Program.ResBetweenMaxAndMin2(array);
            Assert.Equal(expectedRes, actualRes);
        }

        [Fact]

        public void IsResBetweenAbsValidIfZero()
        {
            var array = new[] { -4, -1, 2, 2 };
            var expectedRes = 0;
            var actualRes = Program.ResBetweenMaxAndMin2(array);
            Assert.Equal(expectedRes, actualRes);
        }

        [Fact]

        public void CheckAmountOfNonZeroCols()
        {
            var matrix = new[,] { { 1, 2, 3, 4 }, { 5, 0, 6, 7 }, { 0, 8, 9, 10 } };
            var expectedRes = 2;
            var actualRes = Program.NonZeroCols(matrix, matrix.GetLength(0), matrix.GetLength(1));
            Assert.Equal(expectedRes, actualRes);
        }

    }
}