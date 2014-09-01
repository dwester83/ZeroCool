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
        public void updatePaddle(double y) {
            paddle.Y = (int)y;
        }
        public void update(Ball ball) {
            if (paddle.IntersectsWith(ball.getRect())) {
                double tempAngle = locationPercentageOnPaddle(ball);
                if (ball.getAngle() >= Math.Abs(Math.PI / 2)) {//determinds if the ball is going left
                    ball.setX(paddle.X + paddle.Width);
                    Console.WriteLine("new Left tempAngle: " + tempAngle);
 
                } else {//determinds if the ball is going right
                    ball.setX(paddle.X - ball.getRect().Width);
                    tempAngle = Math.PI - tempAngle;
                    if (locationPercentageOnPaddle(ball) < .1 && locationPercentageOnPaddle(ball) > -.1) { tempAngle = Math.PI; }
                    Console.WriteLine("new Right tempAngle: " + tempAngle); 

                }
                
                ball.setAngle(tempAngle);
            }
        }
        private double locationPercentageOnPaddle(Ball ball){
            double percentage;
            double tempAngle = ball.getAngle();
            Console.WriteLine("ball's angle: " + tempAngle);
            if (!isOnTop(ball)) {
                percentage = (ball.getY() - paddle.Y) / paddle.Height;
                Console.WriteLine("Bottom percentage: " + percentage);
               // if (percentage > .50) {
               //     percentage -= .50;
               // }

                Console.WriteLine("new percentage: " + percentage);
                return Math.PI/2 * percentage;
            }else{
                percentage = (ball.getY()+ball.getRect().Height - paddle.Y) / paddle.Height;
                Console.WriteLine("Top percentage: " + percentage);
               // if (percentage > .50) {
               //     percentage -= .50;
               // }

                Console.WriteLine("new percentage: " + percentage);
                return -Math.PI/2 * percentage;
            }


        }

        private bool isOnTop(Ball ball) {
            double paddleHeight = paddle.Height;
            double halfBallHeight = ball.getRect().Height / 2;
            double ballCenter = (ball.getY() + halfBallHeight) - paddle.Y;
            bool isOnTop = ballCenter < (paddle.Height / 2);
            
            return isOnTop;
        }
        public void render(Graphics g) {
            g.FillRectangle(color, paddle);

        }

    }
}
