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

            while (running) {

                Console.WriteLine("running");
                


            }

        }

        private void update() {

        }

        private void render() {

        }
    }

    
}
