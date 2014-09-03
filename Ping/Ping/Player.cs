using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ping {
    class Player {
        private string name;
        private PaddleBar paddle;
        private int _score;
        public int score {
            get { return _score; }
            set { _score = value; }
        }

        public Player(string name, PaddleBar paddle) {
            this.name = name;
            this.paddle = paddle;
        }

    }
}
