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
        private double speed = 10;
        private double angle = 3.14;
        public double x = 200;
        private double y = 200;

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

        public void update(){

            double nx = speed * Math.Cos(angle);
            double ny = speed * Math.Sin(angle);
            x = x + nx;
            y = y + ny;
            ball = new Rectangle((int)x, (int)y, ball.Width, ball.Height);
            
        }

        public void render(Graphics g) {
            g.FillRectangle(color, ball);
        }

    }
}
