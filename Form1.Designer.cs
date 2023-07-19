namespace UsenetFileProcessor
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label1 = new Label();
            txtPathname = new TextBox();
            btnPastePathname = new Button();
            btnCopyFind = new Button();
            txtFind = new TextBox();
            label2 = new Label();
            btnCopyReplace = new Button();
            txtReplace = new TextBox();
            label3 = new Label();
            btnFix = new Button();
            groupBox1 = new GroupBox();
            btnAddToLibrary = new Button();
            btnExtract = new Button();
            groupBox2 = new GroupBox();
            btnRename = new Button();
            btnClearReplace = new Button();
            listBox1 = new ListBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 33);
            label1.Name = "label1";
            label1.Size = new Size(94, 25);
            label1.TabIndex = 0;
            label1.Text = "Pathname:";
            // 
            // txtPathname
            // 
            txtPathname.Location = new Point(142, 30);
            txtPathname.Name = "txtPathname";
            txtPathname.Size = new Size(444, 31);
            txtPathname.TabIndex = 0;
            txtPathname.Text = "e:\\#done";
            // 
            // btnPastePathname
            // 
            btnPastePathname.Image = (Image)resources.GetObject("btnPastePathname.Image");
            btnPastePathname.Location = new Point(601, 29);
            btnPastePathname.Name = "btnPastePathname";
            btnPastePathname.Size = new Size(45, 33);
            btnPastePathname.TabIndex = 2;
            btnPastePathname.UseVisualStyleBackColor = true;
            btnPastePathname.Click += btnPastePathname_Click;
            // 
            // btnCopyFind
            // 
            btnCopyFind.Image = (Image)resources.GetObject("btnCopyFind.Image");
            btnCopyFind.Location = new Point(601, 38);
            btnCopyFind.Name = "btnCopyFind";
            btnCopyFind.Size = new Size(45, 33);
            btnCopyFind.TabIndex = 5;
            btnCopyFind.UseVisualStyleBackColor = true;
            btnCopyFind.Click += btnCopyFind_Click;
            // 
            // txtFind
            // 
            txtFind.Location = new Point(142, 39);
            txtFind.Name = "txtFind";
            txtFind.Size = new Size(453, 31);
            txtFind.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 42);
            label2.Name = "label2";
            label2.Size = new Size(46, 25);
            label2.TabIndex = 3;
            label2.Text = "Find";
            // 
            // btnCopyReplace
            // 
            btnCopyReplace.Image = (Image)resources.GetObject("btnCopyReplace.Image");
            btnCopyReplace.Location = new Point(601, 75);
            btnCopyReplace.Name = "btnCopyReplace";
            btnCopyReplace.Size = new Size(45, 33);
            btnCopyReplace.TabIndex = 8;
            btnCopyReplace.UseVisualStyleBackColor = true;
            btnCopyReplace.Click += btnCopyReplace_Click;
            // 
            // txtReplace
            // 
            txtReplace.Location = new Point(142, 76);
            txtReplace.Name = "txtReplace";
            txtReplace.Size = new Size(453, 31);
            txtReplace.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(26, 79);
            label3.Name = "label3";
            label3.Size = new Size(72, 25);
            label3.TabIndex = 6;
            label3.Text = "Replace";
            // 
            // btnFix
            // 
            btnFix.Location = new Point(142, 85);
            btnFix.Name = "btnFix";
            btnFix.Size = new Size(157, 34);
            btnFix.TabIndex = 1;
            btnFix.Text = "Fix Filenames";
            btnFix.UseVisualStyleBackColor = true;
            btnFix.Click += btnFix_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnAddToLibrary);
            groupBox1.Controls.Add(btnExtract);
            groupBox1.Controls.Add(txtPathname);
            groupBox1.Controls.Add(btnFix);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(btnPastePathname);
            groupBox1.Location = new Point(24, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(730, 144);
            groupBox1.TabIndex = 10;
            groupBox1.TabStop = false;
            // 
            // btnAddToLibrary
            // 
            btnAddToLibrary.Location = new Point(489, 85);
            btnAddToLibrary.Name = "btnAddToLibrary";
            btnAddToLibrary.Size = new Size(157, 34);
            btnAddToLibrary.TabIndex = 3;
            btnAddToLibrary.Text = "Add to Library";
            btnAddToLibrary.UseVisualStyleBackColor = true;
            // 
            // btnExtract
            // 
            btnExtract.Location = new Point(317, 85);
            btnExtract.Name = "btnExtract";
            btnExtract.Size = new Size(157, 34);
            btnExtract.TabIndex = 2;
            btnExtract.Text = "Extract";
            btnExtract.UseVisualStyleBackColor = true;
            btnExtract.Click += btnExtract_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnRename);
            groupBox2.Controls.Add(btnClearReplace);
            groupBox2.Controls.Add(txtFind);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(btnCopyReplace);
            groupBox2.Controls.Add(btnCopyFind);
            groupBox2.Controls.Add(txtReplace);
            groupBox2.Controls.Add(label3);
            groupBox2.Location = new Point(24, 176);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(730, 167);
            groupBox2.TabIndex = 11;
            groupBox2.TabStop = false;
            // 
            // btnRename
            // 
            btnRename.Location = new Point(142, 113);
            btnRename.Name = "btnRename";
            btnRename.Size = new Size(157, 34);
            btnRename.TabIndex = 6;
            btnRename.Text = "Rename";
            btnRename.UseVisualStyleBackColor = true;
            btnRename.Click += btnRename_Click;
            // 
            // btnClearReplace
            // 
            btnClearReplace.Image = (Image)resources.GetObject("btnClearReplace.Image");
            btnClearReplace.Location = new Point(651, 74);
            btnClearReplace.Name = "btnClearReplace";
            btnClearReplace.Size = new Size(45, 33);
            btnClearReplace.TabIndex = 9;
            btnClearReplace.UseVisualStyleBackColor = true;
            btnClearReplace.Click += btnClearReplace_Click;
            // 
            // listBox1
            // 
            listBox1.Dock = DockStyle.Bottom;
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 25;
            listBox1.Location = new Point(0, 387);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(1196, 404);
            listBox1.TabIndex = 12;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1196, 791);
            Controls.Add(listBox1);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Usenet File Processor";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private TextBox txtPathname;
        private Button btnPastePathname;
        private Button btnCopyFind;
        private TextBox txtFind;
        private Label label2;
        private Button btnCopyReplace;
        private TextBox txtReplace;
        private Label label3;
        private Button btnFix;
        private GroupBox groupBox1;
        private Button btnAddToLibrary;
        private Button btnExtract;
        private GroupBox groupBox2;
        private Button btnRename;
        private Button btnClearReplace;
        private ListBox listBox1;
    }
}