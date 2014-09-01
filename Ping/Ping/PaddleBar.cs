using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ping {
    class PaddleBar {

        private Rectangle paddle;
        private SolidBrush color = new SolidBrush(Color.SeaGreen);
        public PaddleBar(int player) {
            if (player == 1) {
                paddle = new Rectangle(50, 100, 25, 200);
            } else {
                paddle = new Rectangle(925, 100, 25, 200);
            }
        }

        public void update(Ball ball) {
            if (paddle.IntersectsWith(ball.getRect())) {
                
                double tempAngle = ball.getAngle();
                
                tempAngle = tempAngle/Math.PI/.5;

                ball.setAngle(tempAngle);
            }
        }

        public void render(Graphics g) {
            g.FillRectangle(color, paddle);

        }

    }
}
