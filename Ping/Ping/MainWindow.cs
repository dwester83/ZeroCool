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




        private GameBoard gameBoard = new GameBoard();
        public mainWindow() {
            InitializeComponent();
        }

        private void mainCanvas_Paint(object sender, PaintEventArgs e) {
            Console.WriteLine("mainCanvas_Paint");
            bufferContext = BufferedGraphicsManager.Current;
            bufferGraphics = bufferContext.Allocate(this.CreateGraphics(), this.DisplayRectangle);
            init();
            
        }
        // this is for creating a console
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAsAttribute(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        private void mainWindow_Load(object sender, EventArgs e) {
            AllocConsole();
        }

        private void mainWindow_FormClosing(object sender, FormClosingEventArgs e) {
            stop();
            bufferContext.Dispose();
        }
        
        public void init() {
            thread = new Thread(new ThreadStart(loop));
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


            bufferGraphics.Graphics.FillRectangle(new SolidBrush(Color.Blue), 0, 0, this.Width, this.Height);
            gameBoard.render(bufferGraphics.Graphics);


            bufferGraphics.Render();
            // Renders the contents of the buffer to the specified drawing surface.
            bufferGraphics.Render(mainCanvas.CreateGraphics());


        }

    }
}
