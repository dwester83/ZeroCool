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
        private SolidBrush blueBrush = new SolidBrush(Color.Blue);
        private SolidBrush purpleBrush = new SolidBrush(Color.Purple);
        private SolidBrush color = new SolidBrush(Color.Purple);
        private int counter = 0;
        private bool madeGoal;
        public bool _isLeftGoal;
        public bool isLeftGoal { 
            get{
                return _isLeftGoal;
            }
            protected set{
                if (value) {
                    goal = new Rectangle(0,25,25,450);
                } else {
                    goal = new Rectangle(975, 25, 25, 450);
                }
                _isLeftGoal = value;
            }
        }

        public Player player {get; set;}

        public GoalBar(bool isLeftGoal, Player player) {
            this.isLeftGoal = isLeftGoal;

            this.player = player;
        }

        public void update(Ball ball) {
            if (goal.IntersectsWith(ball.getRect()) && !madeGoal) {
                ++player.score;
                madeGoal = true;
            }
            if (madeGoal) {
                if (counter % 2 == 0) { color = goldBrush;} else{ color = blueBrush;}
                counter++;
            }
        }

        public void render(Graphics g) {
            g.FillRectangle(color, goal);
        }
    }
}
