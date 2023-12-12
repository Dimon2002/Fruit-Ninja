using System;

namespace Fruit_Ninja
{
    [Serializable]
    public class Score : IComparable<Score>
    {
        public int points;
        public DateTime date;
        public string name;

        public Score(int points, DateTime date, string name)
        {
            this.points = points;
            this.date = date;
            this.name = name;
        }

        public int CompareTo(Score other) => points.CompareTo(other.points);

        public void SettleScore(int score)
        {
            points += score;
        }
    }
}
