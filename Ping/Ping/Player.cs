using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ping {
    class Player {
        private string name;
        public PaddleBar paddle { get; set;}
        private int _score;
        public int score {
            get { return _score; }
            set { _score = value; }
        }

        public Player(string name) {
            this.name = name;
        }

        public string toString() {
            return name + "\n" + score;
        }
    }
}
