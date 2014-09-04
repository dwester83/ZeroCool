using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;


namespace Ping {

    public partial class mainWindow : Form {

        private bool running = true;
        private Thread thread;
        private BufferedGraphics bufferGraphics;
        private BufferedGraphicsContext bufferContext;
        private bool windowLoaded = false;




        private GameBoard gameBoard;
        public mainWindow() {
            InitializeComponent();
        }

        private void mainCanvas_Paint(object sender, PaintEventArgs e) {
            bufferContext = BufferedGraphicsManager.Current;
            bufferGraphics = bufferContext.Allocate(this.CreateGraphics(), this.DisplayRectangle);
            init();
            
        }

        private void mainWindow_Load(object sender, EventArgs e) {
            AllocConsole();
        }

        private void mainWindow_FormClosing(object sender, FormClosingEventArgs e) {
            stop();
            bufferContext.Dispose();//cleans up the bufferContext
        }

        /*
         * this is for creating a console
         */
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAsAttribute(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        /// <summary>
        /// Initalizes the thread
        /// </summary>
        private void init() {
            Player you = new Player("You");
            Player guest = new Player("Guest");
            gameBoard = new GameBoard(you, guest);
            thread = new Thread(new ThreadStart(loop));
            windowLoaded = true;
            thread.Start();
        }

        private void stop() {
            thread.Abort();
        }

        private void loop() {

            int frames = 0;
            int updates = 0;
            long lastTime = Environment.TickCount;
            long timer = Environment.TickCount;
           // Console.WriteLine("lastTime: " + lastTime + ", timer: " + timer);
            double ns = 1000 / 60;
            double delta = 0;


            while (running) {

                long now = Environment.TickCount;

                delta += (now - lastTime) / ns;
                lastTime = now;

                while(delta >= 1) {
                    update();
                    updates++;
                    delta--;
                   // render();
                   // frames++;
                }
                    render();
                    frames++;
                
                if (Environment.TickCount - timer > 1000) {
                    Console.WriteLine("UPS: " + updates + ", FPS: " + frames);
                    timer += 1000;
                    frames = 0;
                    updates = 0;
                    
                }

            }

        }

        private void update() {
            gameBoard.update();
        }

        private void render() {


            
            
            bufferGraphics.Graphics.FillRectangle(new SolidBrush(Color.Blue), 0, 0, this.Width, this.Height);
            gameBoard.render(bufferGraphics.Graphics);


            bufferGraphics.Render();
            // Renders the contents of the buffer to the specified drawing surface.
            bufferGraphics.Render(mainCanvas.CreateGraphics());


        }

        private void mainCanvas_MouseMove(object sender, MouseEventArgs e) {
            if (windowLoaded) {gameBoard.updatePlayersPaddle(e.Y);}
        }

        private void mainCanvas_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e) {

        }

        private void mainWindow_KeyDown(object sender, KeyEventArgs e) {
            //Console.WriteLine("calling method keyDown");
            //gameBoard.updatePaddleKeyStroke(e.KeyValue);
        }

    }
}
