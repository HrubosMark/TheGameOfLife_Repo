using Microsoft.VisualStudio.TestTools.UnitTesting;
using NyulakRokakLib;

namespace NyulakRokak_Test
{
    [TestClass]
    public class NyulakRokak_Test
    {
        [TestMethod]
        public void Test_Tile_Grow_ChangeGrassState()
        {
            Tile tile = new Tile();

            tile.Grow(); // els� n�veked�s
            string afterFirstGrow = tile.GrassState;

            tile.Grow(); // m�sodik n�veked�s
            string afterSecondGrow = tile.GrassState;

            // Assert
            Assert.AreEqual("young", afterFirstGrow);
            Assert.AreEqual("mature", afterSecondGrow);
        }

        [TestMethod]
        public void Test_Grid_InitializeCorrectly()
        {
            int expectedHeight = 5;
            int expectedWidth = 5;

            Grid grid = new Grid(expectedHeight, expectedWidth);

            Assert.AreEqual(expectedHeight, grid.Height);
            Assert.AreEqual(expectedWidth, grid.Width);
        }

        [TestMethod]
        public void Test_FoxDefaultConstructor_InitializeCorrectly()
        {
            Fox fox = new Fox(1, 1);

            Assert.AreEqual(5, fox.MaxFullnes); // Alap�rtelmezett MaxFullnes �rt�k
            Assert.AreEqual(0, fox.Fullness);   // Alap�rtelmezett Fullness �rt�k
            Assert.AreEqual(3, fox.Reprodoction); // Alap�rtelmezett Reprodoction �rt�k
        }

        [TestMethod]
        public void Test_RabbitDefaultConstructor_ShouldInitializeCorrectly()
        {
            Rabbit rabbit = new Rabbit(1, 1);

            Assert.AreEqual(5, rabbit.MaxFullnes);  // Alap�rtelmezett MaxFullnes �rt�k
            Assert.AreEqual(0, rabbit.Fullness);    // Alap�rtelmezett Fullness �rt�k
            Assert.AreEqual(3, rabbit.Reprodoction); // Alap�rtelmezett Reprodoction �rt�k
        }

        [TestMethod]
        public void Test_TileDefaultConstructor_InitializeCorrectly()
        {
            Tile tile = new Tile();

            Assert.AreEqual("seedling", tile.GrassState);  // Alap�rtelmezett f� �llapota
            Assert.IsFalse(tile.ContainsRabbit);
            Assert.IsFalse(tile.ContainsFox); 
        }
    }
}