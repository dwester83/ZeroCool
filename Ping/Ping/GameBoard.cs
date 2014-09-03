using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Ping {
    class GameBoard {

        private BounceBar top = new BounceBar(1);
        private BounceBar bottom = new BounceBar(2);
        private GoalBar player;
        private GoalBar enemy;
        private PaddleBar playerPaddle;
        private PaddleBar enemyPaddle;
        private Player you;
        private Player guest;
        private Ball ball1 = new Ball();

        private SolidBrush brush = new SolidBrush(Color.Black);
        private Font font = new Font("Arial", 20);
        private RectangleF yourRectangle = new RectangleF(250, 100, 100, 100);
        private RectangleF guestRectangle = new RectangleF(750, 100, 100, 100);


        public GameBoard(Player you, Player guest) {
            playerPaddle = new PaddleBar(true);
            enemyPaddle = new PaddleBar(false);
            this.you = you;
            this.you.paddle = playerPaddle;
            this.guest = guest;
            this.guest.paddle = enemyPaddle;
            player = new GoalBar(true);
            player.player = guest;
            enemy = new GoalBar(false);
            enemy.player = you;
        }

        public void updatePlayersPaddle(double y) {
            playerPaddle.updatePaddle(y);
            enemyPaddle.updatePaddle(y);
        }

        public void updatePaddleKeyStroke(int key) {

        }

        public void update() {
            ball1.update();
            top.update(ball1);
            bottom.update(ball1);
            player.update(ball1);
            enemy.update(ball1);
            playerPaddle.update(ball1);
            enemyPaddle.update(ball1);
        }

        public void render(Graphics g) {
            g.DrawString(you.toString(),font,brush,yourRectangle);
            g.DrawString(guest.toString(), font, brush, guestRectangle);
            top.render(g);
            bottom.render(g);
            player.render(g);
            enemy.render(g);
            ball1.render(g);
            playerPaddle.render(g);
            enemyPaddle.render(g);

        }



    }
}
