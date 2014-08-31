using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ping {

    class GoalBar {

        private Rectangle goal;
        private SolidBrush color = new SolidBrush(Color.Purple);

        public GoalBar(int player) {
            if (player == 1) {
                goal = new Rectangle(0,25,25,450);
            } else {
                goal = new Rectangle(975, 25, 25, 450);
            }
        }

        public void update() {

        }

        public void render(Graphics g) {
            g.FillRectangle(color, goal);
        }
    }
}
