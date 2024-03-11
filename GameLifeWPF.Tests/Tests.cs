using Game_Life_WPF.MVVM.Models.GameObjects;

namespace GameLifeWPF.Tests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        [DataRow(false, false, false, false, false, false, false, false, false, 0)]
        [DataRow(true, true, true, true, true, true, false, false, false, 5)]
        [DataRow(true, true, true, true, true, true, true, true, true, 8)]
        public void CountNeighbors_WithValidInput_ShouldReturnExpectedValue
            (bool cell_1, bool cell_2, bool cell_3, 
            bool cell_4, bool cell_5, bool cell_6, 
            bool cell_7, bool cell_8, bool cell_9, 
            int expectedValue)
        {
            var cells = new Cell[,] { 
                { new Cell(cell_1), new Cell(cell_2), new Cell(cell_3) },
                { new Cell(cell_4), new Cell(cell_5), new Cell(cell_6) },
                { new Cell(cell_7), new Cell(cell_8), new Cell(cell_9) }, };

            var cellField = new CellField(3) { Field = cells };

            var actual = cellField.CountNeighbors(0, 0);

            Assert.AreEqual(actual, expectedValue);
        }
        [TestMethod]
        [DataRow(false, false, false, false, false, false, false, false, false, 0)]
        [DataRow(true, true, true, true, true, true, false, false, false, 6)]
        [DataRow(true, true, true, true, true, true, true, true, true, 9)]
        public void CountCellAlive_WithValidInput_ShouldReturnExpectedValue
            (bool cell_1, bool cell_2, bool cell_3,
            bool cell_4, bool cell_5, bool cell_6,
            bool cell_7, bool cell_8, bool cell_9,
            int expectedValue)
        {
            var cells = new Cell[,] {
                { new Cell(cell_1), new Cell(cell_2), new Cell(cell_3) },
                { new Cell(cell_4), new Cell(cell_5), new Cell(cell_6) },
                { new Cell(cell_7), new Cell(cell_8), new Cell(cell_9) }, };

            var cellField = new CellField(3) { Field = cells };

            var actual = cellField.CountCellAlive();

            Assert.AreEqual(actual, expectedValue);
        }
    }
}