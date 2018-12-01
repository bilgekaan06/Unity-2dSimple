using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    class HighScore
    {
        public int Score  { get; set; }

        public string Nick { get; set; }

        public DateTime Date { get; set; }

        //public int ScoreId { get; set; }

        public HighScore(/*int id,*/string nick, int score, DateTime date)
        {
            //this.ScoreId = id;
            this.Nick = nick;
            this.Score = score;
            this.Date = date;
        }
    }
}
