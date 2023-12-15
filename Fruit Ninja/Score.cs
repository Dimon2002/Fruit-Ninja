using System;

namespace Fruit_Ninja
{
    [Serializable]
    public class Score : IComparable<Score>
    {
        public int Points;
        public DateTime Date;
        public string Name;

        public Score(int points, DateTime date, string name)
        {
            Points = points;
            Date = date;
            Name = name;
        }

        public int CompareTo(Score other) => Points.CompareTo(other.Points);

        public void SettleScore(int score)
        {
            Points += score;
        }
    }
}
