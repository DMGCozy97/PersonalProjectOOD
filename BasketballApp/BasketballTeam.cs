using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballApp
{
    public enum Conference { Western , Eastern }

    class BasketballTeam : IComparable<BasketballTeam>
    {



        //prop
        public string TeamName { get; set; }
        public string Players { get; set; }
        public int Standing { get; set; }
        public Conference Conference { get; set; }

        public DateTime GameDay { get; set; }

        public string TeamImage { get; set; }

        //constructors
        public BasketballTeam(string teamName, string players, int standing, Conference conference , string teamImage)
        {
            TeamName = teamName;
            Players = players;
            Standing = standing;
            Conference = conference;
            TeamImage = teamImage;
        }


        //METHODS
        public override string ToString()
        {
            return string.Format(TeamName + " " + Players );
        }

        public int CompareTo(BasketballTeam other)
        {
            return this.Standing.CompareTo(other.Standing);
        }

    }
}
