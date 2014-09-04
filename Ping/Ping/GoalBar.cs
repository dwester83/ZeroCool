using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ping {

    class GoalBar {

        private Rectangle goal;
        private SolidBrush goldBrush = new SolidBrush(Color.Gold);
        private SolidBrush blueBrush = new SolidBrush(Color.Blue);
        private SolidBrush purpleBrush = new SolidBrush(Color.Green);
        private SolidBrush color = new SolidBrush(Color.Green);
        private LinearGradientBrush linearGradientA;
        private int gradientHeight = 1;
        private int count = 1;
        private Rectangle gameBackground = new Rectangle(50, 65, 1000, 470);
        private int counter = 0;
        private bool madeGoal;
        public bool _isLeftGoal;
        public bool isLeftGoal { 
            get{
                return _isLeftGoal;
            }
            protected set{
                if (value) {
                    goal = new Rectangle(50,80,15,440);
                } else {
                    goal = new Rectangle(1035, 80, 15, 440);
                }
                _isLeftGoal = value;
            }
        }

        public Player player {get; set;}

        public GoalBar(bool isLeftGoal) {
            this.isLeftGoal = isLeftGoal;
            linearGradientA = new LinearGradientBrush(gameBackground, Color.Gold, Color.Black, LinearGradientMode.Vertical);
        }

        public void update(Ball ball) {
            if (goal.IntersectsWith(ball.getRect()) && !madeGoal) {
                ++player.score;
                madeGoal = true;
                ball.resetBall();
            }
            if (count % 1 == 0) {
                linearGradientA = new LinearGradientBrush(gameBackground, Color.Gold, Color.Black, gradientHeight, true);
                gradientHeight += 2;
                if (gradientHeight == 361) { gradientHeight = 0; }
            }
            count++;

            if (madeGoal) {
                if (counter % 2 == 0) { color = goldBrush;} else{ color = blueBrush;}
                counter++;
            }

            if (counter == 10) {
                madeGoal = false;
                counter = 0;
                color = purpleBrush;
                
            }

        }

        public void render(Graphics g) {
            if (madeGoal) {
                g.FillRectangle(color, goal);
            } else {
                g.FillRectangle(linearGradientA, goal);
            }
        }
    }
}
