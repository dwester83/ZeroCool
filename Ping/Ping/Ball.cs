using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ping {

    class Ball {

        private Rectangle ball = new Rectangle(200, 200, 25, 25);
        private SolidBrush color = new SolidBrush(Color.RosyBrown);

        public Ball() {

        }

        public void update(){

        }

        public void render(Graphics g) {
            g.FillRectangle(color, ball);
        }

    }
}
