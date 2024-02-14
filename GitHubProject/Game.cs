using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GitHubProject
{
    internal class Game
    {

        private string title;
        private string type;
        private int releaseYear;

        public Game()
        {
        }

        public Game(string title, string type, int releaseYear)
        {
            this.title = title;
            this.type = type;
            this.releaseYear = releaseYear;
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public int ReleaseYear
        {
            get { return releaseYear; }
            set { releaseYear = value; }
        }
    }
}
