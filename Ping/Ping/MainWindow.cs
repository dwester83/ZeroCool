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

namespace Ping {

    public partial class mainWindow : Form {

        private GameLoop gl = new GameLoop();
        private int windowWidth = 1000;
        private int windowHeight = 500;
        public mainWindow() {
            InitializeComponent();
        }


        private void mainCanvas_Paint(object sender, PaintEventArgs e) {
            Graphics g = mainCanvas.CreateGraphics();
            gl.init(g, windowHeight, windowWidth);
        }

        private void mainWindow_Load(object sender, EventArgs e) {
            AllocConsole();
        }

        private void mainWindow_FormClosing(object sender, FormClosingEventArgs e) {
            gl.stop();
        }


        // this is for creating a console
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAsAttribute(UnmanagedType.Bool)]
        static extern bool AllocConsole();


    }
}
