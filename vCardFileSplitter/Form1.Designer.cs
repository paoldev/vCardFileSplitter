namespace vCardFileSplitter
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
            buttonBrowse = new Button();
            textBoxSourceVcf = new TextBox();
            buttonRefresh = new Button();
            listView1 = new ListView();
            buttonExport = new Button();
            openFileDialog1 = new OpenFileDialog();
            folderBrowserDialog1 = new FolderBrowserDialog();
            comboBoxSplitOrMerge = new ComboBox();
            saveFileDialog1 = new SaveFileDialog();
            label1 = new Label();
            splitContainer1 = new SplitContainer();
            groupBox1 = new GroupBox();
            textBoxPreview = new TextBox();
            label2 = new Label();
            textBoxFilter = new TextBox();
            buttonClearFilter = new Button();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            exitToolStripMenuItem = new ToolStripMenuItem();
            labelItemsNumber = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            groupBox1.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // buttonBrowse
            // 
            buttonBrowse.Location = new Point(217, 99);
            buttonBrowse.Name = "buttonBrowse";
            buttonBrowse.Size = new Size(125, 34);
            buttonBrowse.TabIndex = 0;
            buttonBrowse.Text = "Select file";
            buttonBrowse.UseVisualStyleBackColor = true;
            buttonBrowse.Click += OnButtonBrowse_Click;
            // 
            // textBoxSourceVcf
            // 
            textBoxSourceVcf.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxSourceVcf.Location = new Point(365, 101);
            textBoxSourceVcf.Name = "textBoxSourceVcf";
            textBoxSourceVcf.Size = new Size(996, 31);
            textBoxSourceVcf.TabIndex = 1;
            // 
            // buttonRefresh
            // 
            buttonRefresh.Location = new Point(12, 167);
            buttonRefresh.Name = "buttonRefresh";
            buttonRefresh.Size = new Size(112, 34);
            buttonRefresh.TabIndex = 2;
            buttonRefresh.Text = "Refresh";
            buttonRefresh.UseVisualStyleBackColor = true;
            buttonRefresh.Click += OnButtonRefresh_Click;
            // 
            // listView1
            // 
            listView1.Dock = DockStyle.Fill;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.Location = new Point(0, 0);
            listView1.Name = "listView1";
            listView1.ShowItemToolTips = true;
            listView1.Size = new Size(1349, 413);
            listView1.TabIndex = 3;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.ItemSelectionChanged += OnListView1_ItemSelectionChanged;
            // 
            // buttonExport
            // 
            buttonExport.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonExport.Location = new Point(1249, 167);
            buttonExport.Name = "buttonExport";
            buttonExport.Size = new Size(112, 34);
            buttonExport.TabIndex = 4;
            buttonExport.Text = "Export";
            buttonExport.UseVisualStyleBackColor = true;
            buttonExport.Click += OnButtonExport_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.DefaultExt = "vcf";
            openFileDialog1.FileName = "*.vcf";
            openFileDialog1.Filter = "Vcf files|*.vcf,*.vcard|All files|*.*";
            // 
            // comboBoxSplitOrMerge
            // 
            comboBoxSplitOrMerge.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSplitOrMerge.FormattingEnabled = true;
            comboBoxSplitOrMerge.Items.AddRange(new object[] { "Split", "Merge" });
            comboBoxSplitOrMerge.Location = new Point(12, 101);
            comboBoxSplitOrMerge.Name = "comboBoxSplitOrMerge";
            comboBoxSplitOrMerge.Size = new Size(182, 33);
            comboBoxSplitOrMerge.TabIndex = 5;
            comboBoxSplitOrMerge.SelectedIndexChanged += OnComboBox1_SelectedIndexChanged;
            // 
            // saveFileDialog1
            // 
            saveFileDialog1.DefaultExt = "vcf";
            saveFileDialog1.Filter = "Vcf files|*.vcf,*.vcard|All files|*.*";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 50);
            label1.Name = "label1";
            label1.Size = new Size(754, 25);
            label1.TabIndex = 6;
            label1.Text = "Split or merge vcf and vCard files without applying any further processing to original file lines.";
            // 
            // splitContainer1
            // 
            splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer1.Location = new Point(12, 283);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(listView1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(groupBox1);
            splitContainer1.Size = new Size(1349, 827);
            splitContainer1.SplitterDistance = 413;
            splitContainer1.TabIndex = 7;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBoxPreview);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1349, 410);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Preview";
            // 
            // textBoxPreview
            // 
            textBoxPreview.Dock = DockStyle.Fill;
            textBoxPreview.Location = new Point(3, 27);
            textBoxPreview.Multiline = true;
            textBoxPreview.Name = "textBoxPreview";
            textBoxPreview.ReadOnly = true;
            textBoxPreview.ScrollBars = ScrollBars.Both;
            textBoxPreview.Size = new Size(1343, 380);
            textBoxPreview.TabIndex = 0;
            textBoxPreview.WordWrap = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 229);
            label2.Name = "label2";
            label2.Size = new Size(50, 25);
            label2.TabIndex = 0;
            label2.Text = "Filter";
            // 
            // textBoxFilter
            // 
            textBoxFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxFilter.Location = new Point(79, 227);
            textBoxFilter.Name = "textBoxFilter";
            textBoxFilter.Size = new Size(1215, 31);
            textBoxFilter.TabIndex = 1;
            textBoxFilter.TextChanged += OnTextBoxFilter_TextChanged;
            // 
            // buttonClearFilter
            // 
            buttonClearFilter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonClearFilter.Location = new Point(1309, 224);
            buttonClearFilter.Name = "buttonClearFilter";
            buttonClearFilter.Size = new Size(52, 34);
            buttonClearFilter.TabIndex = 2;
            buttonClearFilter.Text = "X";
            buttonClearFilter.UseVisualStyleBackColor = true;
            buttonClearFilter.Click += OnButtonClearFilter_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1378, 33);
            menuStrip1.TabIndex = 8;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutToolStripMenuItem, toolStripSeparator1, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(54, 29);
            fileToolStripMenuItem.Text = "File";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(164, 34);
            aboutToolStripMenuItem.Text = "About";
            aboutToolStripMenuItem.Click += OnAboutToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(161, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(164, 34);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += OnExitToolStripMenuItem_Click;
            // 
            // labelItemsNumber
            // 
            labelItemsNumber.AutoSize = true;
            labelItemsNumber.Location = new Point(142, 172);
            labelItemsNumber.Name = "labelItemsNumber";
            labelItemsNumber.Size = new Size(70, 25);
            labelItemsNumber.TabIndex = 9;
            labelItemsNumber.Text = "0 items";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1378, 1122);
            Controls.Add(labelItemsNumber);
            Controls.Add(label2);
            Controls.Add(splitContainer1);
            Controls.Add(textBoxFilter);
            Controls.Add(buttonClearFilter);
            Controls.Add(label1);
            Controls.Add(comboBoxSplitOrMerge);
            Controls.Add(buttonExport);
            Controls.Add(buttonRefresh);
            Controls.Add(textBoxSourceVcf);
            Controls.Add(buttonBrowse);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(400, 400);
            Name = "Form1";
            Text = "vCard File Splitter";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonBrowse;
        private TextBox textBoxSourceVcf;
        private Button buttonRefresh;
        private ListView listView1;
        private Button buttonExport;
        private OpenFileDialog openFileDialog1;
        private FolderBrowserDialog folderBrowserDialog1;
        private ComboBox comboBoxSplitOrMerge;
        private SaveFileDialog saveFileDialog1;
        private Label label1;
        private SplitContainer splitContainer1;
        private GroupBox groupBox1;
        private TextBox textBoxPreview;
        private Label label2;
        private TextBox textBoxFilter;
        private Button buttonClearFilter;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem exitToolStripMenuItem;
        private Label labelItemsNumber;
    }
}