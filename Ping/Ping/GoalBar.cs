using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ping {

    class GoalBar {

        private Rectangle goal;
        private SolidBrush goldBrush = new SolidBrush(Color.Gold);
        private SolidBrush redBrush = new SolidBrush(Color.Red);
        private SolidBrush purpleBrush = new SolidBrush(Color.Purple);
        private SolidBrush color = new SolidBrush(Color.Purple);
        private bool madeGoal = false;
        private int counter = 0;
        public GoalBar(int player) {
            if (player == 1) {
                goal = new Rectangle(0,25,25,450);
            } else {
                goal = new Rectangle(975, 25, 25, 450);
            }
        }

        public void update(Ball ball) {
            if (goal.IntersectsWith(ball.getRect()) && !madeGoal) {
                madeGoal = true;
            }
            if (madeGoal) {
                if (counter % 2 == 0) { color = goldBrush;} else{ color = redBrush;}
                counter++;
            }
        }

        public void render(Graphics g) {
            g.FillRectangle(color, goal);
        }
    }
}
