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
                bar = new Rectangle(50,50,1000,30);
            } else {
                bar = new Rectangle(50, 520, 1000, 30);
            }
        }

        public void update(Ball ball) {
            if (bar.IntersectsWith(ball.getRect())) {
                if(bar.Contains(ball.getRect())){
                ball.resetBall();
                }

                double tempAngle = ball.getAngle();
                tempAngle = -tempAngle;
                ball.setAngle(tempAngle);

            }

        }

        public void render(Graphics g) {
            g.FillRectangle(color, bar);
        }
    }
}
