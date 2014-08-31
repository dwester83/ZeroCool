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
        private Graphics windowGraphics;
        private Thread thread;

        private GameBoard gameBoard = new GameBoard();

        public mainWindow() {
            InitializeComponent();

            init();
        }

        private void mainCanvas_Paint(object sender, PaintEventArgs e) {
                
            
        }


        private void mainWindow_Load(object sender, EventArgs e) {
            AllocConsole();
        }

        private void mainWindow_FormClosing(object sender, FormClosingEventArgs e) {
            stop();
        }
                // this is for creating a console
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAsAttribute(UnmanagedType.Bool)]
        static extern bool AllocConsole();

 

        public void init() {
            thread = new Thread(new ThreadStart(loop));
            windowGraphics = mainCanvas.CreateGraphics();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
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

            gameBoard.render(windowGraphics);
            
        }
    }
}
