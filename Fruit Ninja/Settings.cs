using System;

namespace Fruit_Ninja
{
    public class Settings : IComparable<Settings>
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public string Difficulty { get; set; }
        
        public Settings(int width, int height, string difficulty)
        {
            Width = width;
            Height = height;
            Difficulty = difficulty;
        }

        public int CompareTo(Settings other)
        {
            return Width != other.Width || Height != other.Height || !Difficulty.Equals(other.Difficulty) 
                ? 1 
                : 0;
        }
    }
}
