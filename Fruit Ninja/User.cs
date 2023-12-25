using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Fruit_Ninja
{
    [Serializable]
    public class User
    {
        public string Name { get; set; }

        [JsonProperty("Scores")]

        public List<Score> Scores = new List<Score>();
        
        public override string ToString() => Name;

        public void AddScore(Score score)
        {
            Scores.Add(score);
        }
    }
}
