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
        public bool player {get; set;}

        public PaddleBar(bool player) {
            if (player) {
                paddle = new Rectangle(124, 200, 2, 100);
            } else {
                paddle = new Rectangle(976, 200, 2, 100);
            }
            this.player = player;
        }

        public void updatePaddle(double y) {
            if (y + paddle.Height >= 520) {
                paddle.Y = 520 - paddle.Height - 1;
            } else if (y <= 80) {
                paddle.Y = 81;
            } else { paddle.Y = (int)y; }
        }

        public void update(Ball ball) {
            bounceBall(ball);
        }

        private void bounceBall(Ball ball) {
            if (paddle.IntersectsWith(ball.getRect())) {
                double newAngle = locationPercentageOnPaddle(ball);
                double locationOnPaddle = paddlePercentage(ball);
                if (Math.Abs(ball.getAngle()) >= Math.PI / 2) {//determinds if the ball is going left
                    if (locationOnPaddle < 1.02 && locationOnPaddle > -.02) { ball.setX(paddle.X + paddle.Width+1); }
                } else {//determinds if the ball is going right
                    if (locationOnPaddle < 1.02 && locationOnPaddle > -.02) { ball.setX(paddle.X - ball.getRect().Width-1); }
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
