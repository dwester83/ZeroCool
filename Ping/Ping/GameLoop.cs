using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ping {
    class GameLoop {
        private int windowWidth;
        private int windowHeight;
        private bool running = true;
        private Graphics windowGraphics;
        private Graphics bufferGraphics;//used to draw all renders to bufferBitmap 
        private Bitmap bufferBitmap;//the image that will be drawn to the windowGraphics
        private Thread thread;

        private GameBoard gameBoard = new GameBoard();

        public GameLoop() {
            thread = new Thread(new ThreadStart(loop));
        }

        public void init(Graphics g, int width, int height) {
            this.windowGraphics = g;
            windowWidth = width;
            windowHeight = height;
            bufferBitmap = new Bitmap(windowWidth, windowHeight);
            bufferGraphics = Graphics.FromImage(bufferBitmap);
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

        public void render() {

            gameBoard.render(bufferGraphics);

            windowGraphics.DrawImage(bufferBitmap,0,0);
            
        }
    }

    
}
