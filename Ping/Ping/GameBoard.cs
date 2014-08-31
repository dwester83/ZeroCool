using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Ping {
    class GameBoard {

        int x = 100;
        int y = 100;
        public GameBoard() {

        }

        public void update() {
            x += 1;
            if (x > 1000) {
                x = 0;
            }
        }

        public void render(Graphics g) {
           // Console.WriteLine("render");
            g.FillRectangle(new SolidBrush(Color.Black), x, y, 25, 25);

        }

    }
}
