using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Ping {
    class GameBoard {


        public GameBoard() {

        }

        public void update() {

        }

        public void render(Graphics g) {
           // Console.WriteLine("render");
            g.FillRectangle(new SolidBrush(Color.Black), 100, 100, 25, 25);

        }

    }
}
