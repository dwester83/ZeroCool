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
        private GoalBar player = new GoalBar(1);
        private GoalBar enemy = new GoalBar(2);
        private PaddleBar playerPaddle = new PaddleBar(1);
        private PaddleBar enemyPaddle = new PaddleBar(2);

        private Ball ball = new Ball();

        public GameBoard() {

        }

        public void update() {
            ball.update();
            top.update(ball);
            bottom.update(ball);
            player.update(ball);
            enemy.update(ball);
            playerPaddle.update(ball);
            enemyPaddle.update(ball);

        }

        public void render(Graphics g) {
            top.render(g);
            bottom.render(g);
            player.render(g);
            enemy.render(g);
            ball.render(g);
            playerPaddle.render(g);
            enemyPaddle.render(g);
        }

    }
}
