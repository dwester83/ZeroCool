namespace Ping {
    partial class mainWindow {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.mainCanvas = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // mainCanvas
            // 
            this.mainCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainCanvas.Location = new System.Drawing.Point(0, 0);
            this.mainCanvas.Name = "mainCanvas";
            this.mainCanvas.Size = new System.Drawing.Size(1200, 700);
            this.mainCanvas.TabIndex = 0;
            this.mainCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.mainCanvas_Paint);
            // 
            // mainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.mainCanvas);
            this.MaximizeBox = false;
            this.Name = "mainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ping";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainCanvas;
    }
}

