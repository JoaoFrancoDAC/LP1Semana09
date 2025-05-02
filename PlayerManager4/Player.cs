using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayerManager4
{
    public class Player : IComparable<Player>
    {
        public string Name { get; }
        public int Score { get; set; }

        public Player(string name, int score)
        {
            Name = name;
            Score = score;
        }

        public int CompareTo(Player other)
        {
            return other.Score.CompareTo(this.Score);
        }
    }
}