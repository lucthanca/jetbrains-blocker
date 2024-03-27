namespace Vadu
{
    partial class JetBrainsBlockerFrm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JetBrainsBlockerFrm));
            btn_run = new Button();
            openFleDialog = new OpenFileDialog();
            openFile_btn = new Button();
            blockedPaths_listBox = new ListBox();
            panel1 = new Panel();
            delete_btn = new Button();
            label1 = new Label();
            panel2 = new Panel();
            panel3 = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // btn_run
            // 
            btn_run.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btn_run.Location = new Point(3, 180);
            btn_run.Name = "btn_run";
            btn_run.Size = new Size(75, 23);
            btn_run.TabIndex = 0;
            btn_run.Text = "Run";
            btn_run.UseVisualStyleBackColor = true;
            btn_run.Click += btn_run_Click;
            // 
            // openFleDialog
            // 
            openFleDialog.FileName = "openFileDialog1";
            // 
            // openFile_btn
            // 
            openFile_btn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            openFile_btn.Location = new Point(3, 155);
            openFile_btn.Name = "openFile_btn";
            openFile_btn.Size = new Size(75, 23);
            openFile_btn.TabIndex = 3;
            openFile_btn.Text = "select file";
            openFile_btn.UseVisualStyleBackColor = true;
            openFile_btn.Click += openFile_btn_Click;
            // 
            // blockedPaths_listBox
            // 
            blockedPaths_listBox.Dock = DockStyle.Fill;
            blockedPaths_listBox.FormattingEnabled = true;
            blockedPaths_listBox.ItemHeight = 15;
            blockedPaths_listBox.Location = new Point(0, 25);
            blockedPaths_listBox.Name = "blockedPaths_listBox";
            blockedPaths_listBox.Size = new Size(299, 181);
            blockedPaths_listBox.TabIndex = 4;
            // 
            // panel1
            // 
            panel1.Controls.Add(delete_btn);
            panel1.Controls.Add(btn_run);
            panel1.Controls.Add(openFile_btn);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(304, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(80, 206);
            panel1.TabIndex = 5;
            // 
            // delete_btn
            // 
            delete_btn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            delete_btn.Location = new Point(3, 130);
            delete_btn.Name = "delete_btn";
            delete_btn.Size = new Size(75, 23);
            delete_btn.TabIndex = 4;
            delete_btn.Text = "delete";
            delete_btn.UseVisualStyleBackColor = true;
            delete_btn.Click += delete_btn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(5, 5);
            label1.Name = "label1";
            label1.Size = new Size(68, 15);
            label1.TabIndex = 6;
            label1.Text = "Block Paths";
            // 
            // panel2
            // 
            panel2.Controls.Add(blockedPaths_listBox);
            panel2.Controls.Add(panel3);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(5, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(299, 206);
            panel2.TabIndex = 7;
            // 
            // panel3
            // 
            panel3.Controls.Add(label1);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(299, 25);
            panel3.TabIndex = 7;
            // 
            // JetBrainsBlockerFrm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 211);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "JetBrainsBlockerFrm";
            Padding = new Padding(5, 0, 0, 5);
            Text = "JetBrains Blocker";
            Load += JetBrainsBlockerFrm_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btn_run;
        private OpenFileDialog openFleDialog;
        private Button openFile_btn;
        private ListBox blockedPaths_listBox;
        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private Panel panel3;
        private Button delete_btn;
    }
}