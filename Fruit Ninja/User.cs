using System;
using System.Collections.Generic;

namespace Fruit_Ninja
{
    [Serializable]
    public class User
    {
        public string Name { get; set; }

        public List<Score> scores = new List<Score>();

        public override string ToString() => Name;

        public void AddScore(Score score)
        {
            scores.Add(score);
        }
    }
}
