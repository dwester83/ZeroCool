using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ping {
    class BounceBar {
        private Rectangle bar;
        private SolidBrush color = new SolidBrush(Color.Red);
        public BounceBar(int placement) {
            if (placement == 1) {
                bar = new Rectangle(0,0,1000,30);
            } else {
                bar = new Rectangle(0, 475, 1000, 30);
            }
        }

        public void update(Ball ball) {
            if (bar.IntersectsWith(ball.getRect())) {
                double tempAngle = ball.getAngle();
                tempAngle = -tempAngle;
                ball.setAngle(tempAngle);
            }
            if(bar.Contains(ball.getRect())){
                ball.resetBall();

            }
        }

        public void render(Graphics g) {
            g.FillRectangle(color, bar);
        }
    }
}
