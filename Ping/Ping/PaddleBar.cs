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
                paddle = new Rectangle(50, 100, 25, 100);
            } else {
                paddle = new Rectangle(925, 100, 25, 100);
            }
        }
        public void updatePaddle(double y) {
            if (y+ paddle.Height >= 475){
                paddle.Y = 475 - paddle.Height - 1;
            }else if(y <= 25) {
                paddle.Y = 26;
            } else { paddle.Y = (int)y; }
        }
        public void update(Ball ball) {
            bounceBall(ball);
        }

        private void bounceBall(Ball ball) {
            if (paddle.IntersectsWith(ball.getRect())) {
                double newAngle = locationPercentageOnPaddle(ball);
                if (Math.Abs(ball.getAngle()) >= Math.PI / 2) {//determinds if the ball is going left
                    ball.setX(paddle.X + paddle.Width);//sets the ball to the paddles edge
                } else {//determinds if the ball is going right
                    ball.setX(paddle.X - ball.getRect().Width);//sets the ball to the paddles edge
                    //creates the correct reflection angle for positive or negetive angles
                    if (newAngle > 0) { newAngle = Math.PI - newAngle; 
                    } else { newAngle = -Math.PI - newAngle; }
                }
                ball.setAngle(newAngle);
            }
        }

        private double locationPercentageOnPaddle(Ball ball){
            double percentage = paddlePercentage(ball);
            if (percentage >= .55) {
                if (percentage > .90) { percentage = .90; } //makes sure the edge case of the paddle still works fine
                percentage = .45 - (1.00 - percentage);
                percentage /= .45;
                return Math.PI/2 * percentage;
            }else if(percentage <= .45){
                if (percentage < .10) { percentage = .10; } //makes sure the edge case of the paddle still works fine
                percentage = .45 - percentage;
                percentage /= .45;
                return -Math.PI/2 * percentage;
            } else {
                return 0;
            }
        }

        private double paddlePercentage(Ball ball) {
            double paddleHeight = paddle.Height;
            double halfBallHeight = ball.getRect().Height / 2;
            double ballCenter = (ball.getY() + halfBallHeight) - paddle.Y;
            double locationPercentage = ballCenter / paddle.Height;
            Console.WriteLine("paddlePercentage: " + locationPercentage);
            return locationPercentage;
        }

        public void render(Graphics g) {
            g.FillRectangle(color, paddle);

        }

    }
}
