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

        public GameBoard() {
            playerPaddle = new PaddleBar(true);
            enemyPaddle = new PaddleBar(false);
            you = new Player("You", playerPaddle);
            guest = new Player("Guest", enemyPaddle);
            player = new GoalBar(true, you);
            enemy = new GoalBar(false, guest);
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
