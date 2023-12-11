using System;
using System.Collections.Generic;

namespace Fruit_Ninja
{
    [Serializable]
    public class User
    {
        public string name;
        public List<Score> scores;

        public User(string name)
        {
            scores = new List<Score>();
            this.name = name;
        }
        
        public override string ToString()
        {
            return name;
        }

        public void AddScore(Score score)
        {
            scores.Add(score);
        }
    }
}
