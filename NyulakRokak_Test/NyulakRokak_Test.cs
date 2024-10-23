using Microsoft.VisualStudio.TestTools.UnitTesting;
using NyulakRokakLib;

namespace NyulakRokak_Test
{
    [TestClass]
    public class NyulakRokak_Test
    {
        private Grid grid;

        [TestMethod]
        public void Initialize()
        {
            // Nyulak tulajdons�gai
            AnimalProperties rabbitProperties = new AnimalProperties
            {
                MaxFullness = 5,
                ReproductionFullness = 3,
                HungerRate = 1,
                FoodValue = 1
            };

            // R�k�k tulajdons�gai
            AnimalProperties foxProperties = new AnimalProperties
            {
                MaxFullness = 10,
                ReproductionFullness = 9,
                HungerRate = 2,
                FoodValue = 3
            };
        }
    }
}