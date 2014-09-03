using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ping {

    class Ball {

        private Rectangle ball = new Rectangle(100, 200, 25, 25);
        private SolidBrush color = new SolidBrush(Color.RosyBrown);
        private RectangleF rect = new RectangleF(450, 200, 100, 100);
        private Font font = new Font("Arial", 50);
        private double speed = 10;
        private double angle = 3.14;
        public double x = 200;
        private double y = 200;
        private int counter = 0;
        private int time = 3;
        private bool isReset = false;

        public Ball() {

        }

        public Rectangle getRect() {
            return ball;
        }

        public void setAngle(double newAngle) {
            this.angle = newAngle;
        }
        public double getAngle() {
            return angle;
        }
        public double getX() {
            return x;
        }
        public double getY() {
            return y;
        }
        public void setX(double x) {
            this.x = x;
        }
        public void setY(double y) {
            this.y = y;
        }

        public void resetBall() {
            time = 3;
            isReset = true;

        }

        public void update(){
            if (isReset) {
                if (counter % 60 == 0) {
                    if (time == 0) {
                        x = 500;
                        y = 250;
                        isReset = false;
                    }
                    time--;
                }
                counter++;

            } else {
                double nx = speed * Math.Cos(angle);
                double ny = speed * Math.Sin(angle);
                x = x + nx;
                y = y + ny;
                ball = new Rectangle((int)x, (int)y, ball.Width, ball.Height);
            }
        }

        public void render(Graphics g) {
            if (isReset) {
                g.DrawString(time.ToString(), font, color, rect);
            } else {
                g.FillRectangle(color, ball);
            }
        }

    }
}
