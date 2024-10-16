namespace NyulakRokakLib
{
    public class Tile
    {
        public string GrassState { get; set; }
        public bool ContainsRabbit { get; set; }
        public bool ContainsFox { get; set; }
        public Tile() 
        {
            GrassState = "seedling";
            ContainsRabbit = false;
            ContainsFox = false;
        }
        public void Grow()
        {
            GrassState = (GrassState == "seedling") ? "young" : "mature";
        }
    }
}
