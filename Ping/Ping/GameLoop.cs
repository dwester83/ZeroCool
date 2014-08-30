using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ping {
    class GameLoop {

        private bool running = true;
        private Graphics g;
        private Thread thread;

        public GameLoop() {
            thread = new Thread(new ThreadStart(loop));
        }

        public void init(Graphics g) {
            this.g = g;
            thread.Start();
        }

        public void stop() {
            thread.Abort();
        }

        private void loop() {

            int frames = 0;
            int updates = 0;
            long lastTime = Environment.TickCount;
            
            while (running) {

                if (updates < 60) {
                     update();
                     updates++;
                }


                render();
                frames++;
                if (Environment.TickCount >= lastTime + 1000) {
                    Console.WriteLine("UPS: " + updates + ", FPS: " + frames);
                    frames = 0;
                    updates = 0;
                    lastTime = Environment.TickCount;
                }

            }

        }

        private void update() {

        }

        private void render() {

        }
    }

    
}
