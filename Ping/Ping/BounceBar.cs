using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ping {
    class BounceBar {
        private Rectangle bar;
        private Rectangle partialBar;
        private LinearGradientBrush linearGradientA;
        private int gradientHeight = 1;
        private int count = 1;
        private SolidBrush color = new SolidBrush(Color.Red);
        private Rectangle gameBackground = new Rectangle(50, 65, 1000, 470);
        public BounceBar(int placement) {
            if (placement == 1) {
                bar = new Rectangle(50,65,1000,15);
                partialBar = new Rectangle(50,65,1000,gradientHeight);
            } else {
                bar = new Rectangle(50, 520, 1000, 15);
                partialBar = new Rectangle(50,65,1000,gradientHeight);
            }
            
           linearGradientA = new LinearGradientBrush(gameBackground,Color.Gold,Color.Black,LinearGradientMode.Vertical);
        }

        public void update(Ball ball) {
            if(count % 1 == 0){
                linearGradientA = new LinearGradientBrush(gameBackground, Color.Gold, Color.Black, gradientHeight,true);
                gradientHeight += 2;
                if (gradientHeight == 361) { gradientHeight = 0; }
            }
            count++;
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
            g.FillRectangle(linearGradientA, bar);
        }
    }
}
