namespace generator_ad9833
{
  partial class MainForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
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
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.Windows.Forms.Label label1;
      System.Windows.Forms.Label label2;
      System.Windows.Forms.StatusStrip SweepFreqL;
      System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
      System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
      System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel7;
      System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel8;
      System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
      System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
      System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
      System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
      System.Windows.Forms.Label label3;
      System.Windows.Forms.Label label4;
      System.Windows.Forms.Label label5;
      this.PortNameLabel = new System.Windows.Forms.ToolStripStatusLabel();
      this.PortSpeedLabel = new System.Windows.Forms.ToolStripStatusLabel();
      this.PortBitsLabel = new System.Windows.Forms.ToolStripStatusLabel();
      this.PortParityLabel = new System.Windows.Forms.ToolStripStatusLabel();
      this.PortStopBitsLabel = new System.Windows.Forms.ToolStripStatusLabel();
      this.F1Label = new System.Windows.Forms.ToolStripStatusLabel();
      this.F2Label = new System.Windows.Forms.ToolStripStatusLabel();
      this.ResolutionLabel = new System.Windows.Forms.ToolStripStatusLabel();
      this.SweepFreqLabel = new System.Windows.Forms.ToolStripStatusLabel();
      this.modeBox = new System.Windows.Forms.GroupBox();
      this.bnOff = new System.Windows.Forms.RadioButton();
      this.bnSquareDiv2 = new System.Windows.Forms.RadioButton();
      this.bnAFC = new System.Windows.Forms.RadioButton();
      this.bnSine = new System.Windows.Forms.RadioButton();
      this.bnTriangular = new System.Windows.Forms.RadioButton();
      this.bnSquare = new System.Windows.Forms.RadioButton();
      this.AFCPanel = new System.Windows.Forms.Panel();
      this.bnExit = new System.Windows.Forms.Button();
      this.bnFSet = new System.Windows.Forms.Button();
      this.AFCBox = new System.Windows.Forms.GroupBox();
      this.bxPointsCount = new classes.NumericBox();
      this.bnStopAFC = new System.Windows.Forms.Button();
      this.bnAFCSet = new System.Windows.Forms.Button();
      this.bxSweepDelay = new classes.NumericBox();
      this.bxResolution = new classes.NumericBox();
      this.F2 = new classes.NumericBox();
      this.F1 = new classes.NumericBox();
      this.menuStrip = new System.Windows.Forms.MenuStrip();
      this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      label1 = new System.Windows.Forms.Label();
      label2 = new System.Windows.Forms.Label();
      SweepFreqL = new System.Windows.Forms.StatusStrip();
      toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
      toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
      toolStripStatusLabel7 = new System.Windows.Forms.ToolStripStatusLabel();
      toolStripStatusLabel8 = new System.Windows.Forms.ToolStripStatusLabel();
      toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
      toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
      toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
      toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
      label3 = new System.Windows.Forms.Label();
      label4 = new System.Windows.Forms.Label();
      label5 = new System.Windows.Forms.Label();
      SweepFreqL.SuspendLayout();
      this.modeBox.SuspendLayout();
      this.AFCBox.SuspendLayout();
      this.menuStrip.SuspendLayout();
      this.SuspendLayout();
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Location = new System.Drawing.Point(12, 35);
      label1.Name = "label1";
      label1.Size = new System.Drawing.Size(19, 13);
      label1.TabIndex = 1;
      label1.Text = "F1";
      // 
      // label2
      // 
      label2.AutoSize = true;
      label2.Location = new System.Drawing.Point(145, 35);
      label2.Name = "label2";
      label2.Size = new System.Drawing.Size(19, 13);
      label2.TabIndex = 2;
      label2.Text = "F2";
      // 
      // SweepFreqL
      // 
      SweepFreqL.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PortNameLabel,
            this.PortSpeedLabel,
            this.PortBitsLabel,
            this.PortParityLabel,
            this.PortStopBitsLabel,
            toolStripStatusLabel5,
            this.F1Label,
            toolStripStatusLabel6,
            toolStripStatusLabel7,
            this.F2Label,
            toolStripStatusLabel8,
            toolStripStatusLabel1,
            this.ResolutionLabel,
            toolStripStatusLabel2,
            toolStripStatusLabel3,
            this.SweepFreqLabel,
            toolStripStatusLabel4});
      SweepFreqL.Location = new System.Drawing.Point(0, 368);
      SweepFreqL.Name = "SweepFreqL";
      SweepFreqL.Size = new System.Drawing.Size(913, 24);
      SweepFreqL.TabIndex = 0;
      SweepFreqL.Text = "10";
      // 
      // PortNameLabel
      // 
      this.PortNameLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
      this.PortNameLabel.Name = "PortNameLabel";
      this.PortNameLabel.Size = new System.Drawing.Size(53, 19);
      this.PortNameLabel.Text = "COMXX";
      // 
      // PortSpeedLabel
      // 
      this.PortSpeedLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
      this.PortSpeedLabel.Name = "PortSpeedLabel";
      this.PortSpeedLabel.Size = new System.Drawing.Size(41, 19);
      this.PortSpeedLabel.Text = "57600";
      // 
      // PortBitsLabel
      // 
      this.PortBitsLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
      this.PortBitsLabel.Name = "PortBitsLabel";
      this.PortBitsLabel.Size = new System.Drawing.Size(17, 19);
      this.PortBitsLabel.Text = "8";
      // 
      // PortParityLabel
      // 
      this.PortParityLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
      this.PortParityLabel.Name = "PortParityLabel";
      this.PortParityLabel.Size = new System.Drawing.Size(20, 19);
      this.PortParityLabel.Text = "N";
      // 
      // PortStopBitsLabel
      // 
      this.PortStopBitsLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
      this.PortStopBitsLabel.Name = "PortStopBitsLabel";
      this.PortStopBitsLabel.Size = new System.Drawing.Size(17, 19);
      this.PortStopBitsLabel.Text = "1";
      // 
      // toolStripStatusLabel5
      // 
      toolStripStatusLabel5.Name = "toolStripStatusLabel5";
      toolStripStatusLabel5.Size = new System.Drawing.Size(22, 19);
      toolStripStatusLabel5.Text = "F1:";
      // 
      // F1Label
      // 
      this.F1Label.Name = "F1Label";
      this.F1Label.Size = new System.Drawing.Size(13, 19);
      this.F1Label.Text = "0";
      // 
      // toolStripStatusLabel6
      // 
      toolStripStatusLabel6.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
      toolStripStatusLabel6.Name = "toolStripStatusLabel6";
      toolStripStatusLabel6.Size = new System.Drawing.Size(25, 19);
      toolStripStatusLabel6.Text = "Hz";
      // 
      // toolStripStatusLabel7
      // 
      toolStripStatusLabel7.Name = "toolStripStatusLabel7";
      toolStripStatusLabel7.Size = new System.Drawing.Size(22, 19);
      toolStripStatusLabel7.Text = "F2:";
      // 
      // F2Label
      // 
      this.F2Label.Name = "F2Label";
      this.F2Label.Size = new System.Drawing.Size(13, 19);
      this.F2Label.Text = "0";
      // 
      // toolStripStatusLabel8
      // 
      toolStripStatusLabel8.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
      toolStripStatusLabel8.Name = "toolStripStatusLabel8";
      toolStripStatusLabel8.Size = new System.Drawing.Size(25, 19);
      toolStripStatusLabel8.Text = "Hz";
      // 
      // toolStripStatusLabel1
      // 
      toolStripStatusLabel1.Name = "toolStripStatusLabel1";
      toolStripStatusLabel1.Size = new System.Drawing.Size(66, 19);
      toolStripStatusLabel1.Text = "Resolution:";
      // 
      // ResolutionLabel
      // 
      this.ResolutionLabel.Name = "ResolutionLabel";
      this.ResolutionLabel.Size = new System.Drawing.Size(12, 19);
      this.ResolutionLabel.Text = "-";
      // 
      // toolStripStatusLabel2
      // 
      toolStripStatusLabel2.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
      toolStripStatusLabel2.Name = "toolStripStatusLabel2";
      toolStripStatusLabel2.Size = new System.Drawing.Size(25, 19);
      toolStripStatusLabel2.Text = "Hz";
      // 
      // toolStripStatusLabel3
      // 
      toolStripStatusLabel3.Name = "toolStripStatusLabel3";
      toolStripStatusLabel3.Size = new System.Drawing.Size(64, 19);
      toolStripStatusLabel3.Text = "Step delay:";
      // 
      // SweepFreqLabel
      // 
      this.SweepFreqLabel.Name = "SweepFreqLabel";
      this.SweepFreqLabel.Size = new System.Drawing.Size(12, 19);
      this.SweepFreqLabel.Text = "-";
      // 
      // toolStripStatusLabel4
      // 
      toolStripStatusLabel4.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
      toolStripStatusLabel4.Name = "toolStripStatusLabel4";
      toolStripStatusLabel4.Size = new System.Drawing.Size(27, 19);
      toolStripStatusLabel4.Text = "ms";
      // 
      // label3
      // 
      label3.AutoSize = true;
      label3.Location = new System.Drawing.Point(7, 20);
      label3.Name = "label3";
      label3.Size = new System.Drawing.Size(76, 13);
      label3.TabIndex = 0;
      label3.Text = "Resolution, Hz";
      // 
      // label4
      // 
      label4.AutoSize = true;
      label4.Location = new System.Drawing.Point(7, 71);
      label4.Name = "label4";
      label4.Size = new System.Drawing.Size(76, 13);
      label4.TabIndex = 2;
      label4.Text = "Step delay, ms";
      // 
      // label5
      // 
      label5.AutoSize = true;
      label5.Location = new System.Drawing.Point(7, 46);
      label5.Name = "label5";
      label5.Size = new System.Drawing.Size(66, 13);
      label5.TabIndex = 11;
      label5.Text = "Points count";
      // 
      // modeBox
      // 
      this.modeBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.modeBox.Controls.Add(this.bnOff);
      this.modeBox.Controls.Add(this.bnSquareDiv2);
      this.modeBox.Controls.Add(this.bnAFC);
      this.modeBox.Controls.Add(this.bnSine);
      this.modeBox.Controls.Add(this.bnTriangular);
      this.modeBox.Controls.Add(this.bnSquare);
      this.modeBox.Enabled = false;
      this.modeBox.Location = new System.Drawing.Point(761, 24);
      this.modeBox.Name = "modeBox";
      this.modeBox.Size = new System.Drawing.Size(140, 158);
      this.modeBox.TabIndex = 7;
      this.modeBox.TabStop = false;
      this.modeBox.Text = "Mode";
      // 
      // bnOff
      // 
      this.bnOff.AutoSize = true;
      this.bnOff.Location = new System.Drawing.Point(7, 135);
      this.bnOff.Name = "bnOff";
      this.bnOff.Size = new System.Drawing.Size(39, 17);
      this.bnOff.TabIndex = 5;
      this.bnOff.TabStop = true;
      this.bnOff.Text = "Off";
      this.bnOff.UseVisualStyleBackColor = true;
      this.bnOff.CheckedChanged += new System.EventHandler(this.bnOff_CheckedChanged);
      // 
      // bnSquareDiv2
      // 
      this.bnSquareDiv2.AutoSize = true;
      this.bnSquareDiv2.Location = new System.Drawing.Point(7, 43);
      this.bnSquareDiv2.Name = "bnSquareDiv2";
      this.bnSquareDiv2.Size = new System.Drawing.Size(131, 17);
      this.bnSquareDiv2.TabIndex = 4;
      this.bnSquareDiv2.TabStop = true;
      this.bnSquareDiv2.Text = "Square wave (MSB/2)";
      this.bnSquareDiv2.UseVisualStyleBackColor = true;
      this.bnSquareDiv2.CheckedChanged += new System.EventHandler(this.SquareDiv2_CheckedChanged);
      // 
      // bnAFC
      // 
      this.bnAFC.AutoSize = true;
      this.bnAFC.Location = new System.Drawing.Point(7, 112);
      this.bnAFC.Name = "bnAFC";
      this.bnAFC.Size = new System.Drawing.Size(74, 17);
      this.bnAFC.TabIndex = 3;
      this.bnAFC.TabStop = true;
      this.bnAFC.Text = "AFC meter";
      this.bnAFC.UseVisualStyleBackColor = true;
      this.bnAFC.CheckedChanged += new System.EventHandler(this.AFC_CheckedChanged);
      // 
      // bnSine
      // 
      this.bnSine.AutoSize = true;
      this.bnSine.Checked = true;
      this.bnSine.Location = new System.Drawing.Point(7, 89);
      this.bnSine.Name = "bnSine";
      this.bnSine.Size = new System.Drawing.Size(75, 17);
      this.bnSine.TabIndex = 2;
      this.bnSine.TabStop = true;
      this.bnSine.Text = "Sine wave";
      this.bnSine.UseVisualStyleBackColor = true;
      this.bnSine.CheckedChanged += new System.EventHandler(this.Sine_CheckedChanged);
      // 
      // bnTriangular
      // 
      this.bnTriangular.AutoSize = true;
      this.bnTriangular.Location = new System.Drawing.Point(7, 66);
      this.bnTriangular.Name = "bnTriangular";
      this.bnTriangular.Size = new System.Drawing.Size(101, 17);
      this.bnTriangular.TabIndex = 1;
      this.bnTriangular.TabStop = true;
      this.bnTriangular.Text = "Triangular wave";
      this.bnTriangular.UseVisualStyleBackColor = true;
      this.bnTriangular.CheckedChanged += new System.EventHandler(this.Triangular_CheckedChanged);
      // 
      // bnSquare
      // 
      this.bnSquare.AutoSize = true;
      this.bnSquare.Location = new System.Drawing.Point(7, 20);
      this.bnSquare.Name = "bnSquare";
      this.bnSquare.Size = new System.Drawing.Size(120, 17);
      this.bnSquare.TabIndex = 0;
      this.bnSquare.TabStop = true;
      this.bnSquare.Text = "Square wave (MSB)";
      this.bnSquare.UseVisualStyleBackColor = true;
      this.bnSquare.CheckedChanged += new System.EventHandler(this.Square_CheckedChanged);
      // 
      // AFCPanel
      // 
      this.AFCPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.AFCPanel.BackColor = System.Drawing.SystemColors.Window;
      this.AFCPanel.Location = new System.Drawing.Point(0, 54);
      this.AFCPanel.Name = "AFCPanel";
      this.AFCPanel.Size = new System.Drawing.Size(755, 313);
      this.AFCPanel.TabIndex = 5;
      this.AFCPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.AFCPanel_Paint);
      this.AFCPanel.Resize += new System.EventHandler(this.AFCPanel_Resize);
      // 
      // bnExit
      // 
      this.bnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.bnExit.Location = new System.Drawing.Point(761, 344);
      this.bnExit.Name = "bnExit";
      this.bnExit.Size = new System.Drawing.Size(140, 23);
      this.bnExit.TabIndex = 6;
      this.bnExit.Text = "Exit";
      this.bnExit.UseVisualStyleBackColor = true;
      this.bnExit.Click += new System.EventHandler(this.bnExit_Click);
      // 
      // bnFSet
      // 
      this.bnFSet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.bnFSet.Enabled = false;
      this.bnFSet.Location = new System.Drawing.Point(276, 26);
      this.bnFSet.Name = "bnFSet";
      this.bnFSet.Size = new System.Drawing.Size(479, 23);
      this.bnFSet.TabIndex = 8;
      this.bnFSet.Text = "Set";
      this.bnFSet.UseVisualStyleBackColor = true;
      this.bnFSet.Click += new System.EventHandler(this.FSet_Click);
      // 
      // AFCBox
      // 
      this.AFCBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.AFCBox.Controls.Add(this.bxPointsCount);
      this.AFCBox.Controls.Add(label5);
      this.AFCBox.Controls.Add(this.bnStopAFC);
      this.AFCBox.Controls.Add(this.bnAFCSet);
      this.AFCBox.Controls.Add(this.bxSweepDelay);
      this.AFCBox.Controls.Add(label4);
      this.AFCBox.Controls.Add(this.bxResolution);
      this.AFCBox.Controls.Add(label3);
      this.AFCBox.Enabled = false;
      this.AFCBox.Location = new System.Drawing.Point(761, 188);
      this.AFCBox.Name = "AFCBox";
      this.AFCBox.Size = new System.Drawing.Size(140, 150);
      this.AFCBox.TabIndex = 9;
      this.AFCBox.TabStop = false;
      this.AFCBox.Text = "AFC";
      // 
      // bxPointsCount
      // 
      this.bxPointsCount.allowMinus = false;
      this.bxPointsCount.allowPoint = true;
      this.bxPointsCount.Location = new System.Drawing.Point(89, 38);
      this.bxPointsCount.Name = "bxPointsCount";
      this.bxPointsCount.Size = new System.Drawing.Size(45, 20);
      this.bxPointsCount.TabIndex = 12;
      this.bxPointsCount.Text = "50";
      this.bxPointsCount.TextChanged += new System.EventHandler(this.bxPointsCount_TextChanged);
      // 
      // bnStopAFC
      // 
      this.bnStopAFC.Enabled = false;
      this.bnStopAFC.Location = new System.Drawing.Point(3, 121);
      this.bnStopAFC.Name = "bnStopAFC";
      this.bnStopAFC.Size = new System.Drawing.Size(131, 23);
      this.bnStopAFC.TabIndex = 10;
      this.bnStopAFC.Text = "Stop AFC";
      this.bnStopAFC.UseVisualStyleBackColor = true;
      this.bnStopAFC.Click += new System.EventHandler(this.bnStopAFC_Click);
      // 
      // bnAFCSet
      // 
      this.bnAFCSet.Enabled = false;
      this.bnAFCSet.Location = new System.Drawing.Point(3, 92);
      this.bnAFCSet.Name = "bnAFCSet";
      this.bnAFCSet.Size = new System.Drawing.Size(131, 23);
      this.bnAFCSet.TabIndex = 5;
      this.bnAFCSet.Text = "Set";
      this.bnAFCSet.UseVisualStyleBackColor = true;
      this.bnAFCSet.Click += new System.EventHandler(this.AFCSet_Click);
      // 
      // bxSweepDelay
      // 
      this.bxSweepDelay.allowMinus = false;
      this.bxSweepDelay.allowPoint = false;
      this.bxSweepDelay.Location = new System.Drawing.Point(89, 64);
      this.bxSweepDelay.Name = "bxSweepDelay";
      this.bxSweepDelay.Size = new System.Drawing.Size(45, 20);
      this.bxSweepDelay.TabIndex = 3;
      this.bxSweepDelay.Text = "1";
      this.bxSweepDelay.TextChanged += new System.EventHandler(this.SweepFreq_TextChanged);
      // 
      // bxResolution
      // 
      this.bxResolution.allowMinus = false;
      this.bxResolution.allowPoint = true;
      this.bxResolution.Location = new System.Drawing.Point(89, 12);
      this.bxResolution.Name = "bxResolution";
      this.bxResolution.Size = new System.Drawing.Size(45, 20);
      this.bxResolution.TabIndex = 1;
      this.bxResolution.TextChanged += new System.EventHandler(this.Resolution_TextChanged);
      // 
      // F2
      // 
      this.F2.allowMinus = false;
      this.F2.allowPoint = true;
      this.F2.Enabled = false;
      this.F2.Location = new System.Drawing.Point(170, 28);
      this.F2.Name = "F2";
      this.F2.Size = new System.Drawing.Size(100, 20);
      this.F2.TabIndex = 4;
      this.F2.TextChanged += new System.EventHandler(this.F2_TextChanged);
      // 
      // F1
      // 
      this.F1.allowMinus = false;
      this.F1.allowPoint = true;
      this.F1.Enabled = false;
      this.F1.Location = new System.Drawing.Point(39, 28);
      this.F1.Name = "F1";
      this.F1.Size = new System.Drawing.Size(100, 20);
      this.F1.TabIndex = 3;
      this.F1.TextChanged += new System.EventHandler(this.F1_TextChanged);
      // 
      // menuStrip
      // 
      this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
      this.menuStrip.Location = new System.Drawing.Point(0, 0);
      this.menuStrip.Name = "menuStrip";
      this.menuStrip.Size = new System.Drawing.Size(913, 24);
      this.menuStrip.TabIndex = 10;
      this.menuStrip.Text = "menuStrip1";
      // 
      // fileToolStripMenuItem
      // 
      this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
      this.fileToolStripMenuItem.Text = "&File";
      // 
      // exitToolStripMenuItem
      // 
      this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
      this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
      this.exitToolStripMenuItem.Text = "E&xit";
      this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
      // 
      // aboutToolStripMenuItem
      // 
      this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
      this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
      this.aboutToolStripMenuItem.Text = "&About";
      this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(913, 392);
      this.Controls.Add(this.AFCBox);
      this.Controls.Add(this.bnFSet);
      this.Controls.Add(this.modeBox);
      this.Controls.Add(this.bnExit);
      this.Controls.Add(this.AFCPanel);
      this.Controls.Add(this.F2);
      this.Controls.Add(this.F1);
      this.Controls.Add(label2);
      this.Controls.Add(label1);
      this.Controls.Add(SweepFreqL);
      this.Controls.Add(this.menuStrip);
      this.MainMenuStrip = this.menuStrip;
      this.Name = "MainForm";
      this.Text = "Generator";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
      SweepFreqL.ResumeLayout(false);
      SweepFreqL.PerformLayout();
      this.modeBox.ResumeLayout(false);
      this.modeBox.PerformLayout();
      this.AFCBox.ResumeLayout(false);
      this.AFCBox.PerformLayout();
      this.menuStrip.ResumeLayout(false);
      this.menuStrip.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private classes.NumericBox F1;
    private classes.NumericBox F2;
    private System.Windows.Forms.Panel AFCPanel;
    private System.Windows.Forms.Button bnExit;
    private System.Windows.Forms.RadioButton bnSquare;
    private System.Windows.Forms.RadioButton bnTriangular;
    private System.Windows.Forms.RadioButton bnSine;
    private System.Windows.Forms.RadioButton bnAFC;
    private System.Windows.Forms.Button bnFSet;
    private System.Windows.Forms.RadioButton bnSquareDiv2;
    private System.Windows.Forms.GroupBox AFCBox;
    private classes.NumericBox bxResolution;
    private classes.NumericBox bxSweepDelay;
    private System.Windows.Forms.Button bnAFCSet;
    private System.Windows.Forms.ToolStripStatusLabel PortNameLabel;
    private System.Windows.Forms.ToolStripStatusLabel PortSpeedLabel;
    private System.Windows.Forms.ToolStripStatusLabel PortBitsLabel;
    private System.Windows.Forms.ToolStripStatusLabel PortParityLabel;
    private System.Windows.Forms.ToolStripStatusLabel PortStopBitsLabel;
    private System.Windows.Forms.ToolStripStatusLabel ResolutionLabel;
    private System.Windows.Forms.ToolStripStatusLabel F1Label;
    private System.Windows.Forms.ToolStripStatusLabel SweepFreqLabel;
    private System.Windows.Forms.ToolStripStatusLabel F2Label;
    private System.Windows.Forms.Button bnStopAFC;
    private System.Windows.Forms.RadioButton bnOff;
    private System.Windows.Forms.MenuStrip menuStrip;
    private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    private classes.NumericBox bxPointsCount;
    private System.Windows.Forms.GroupBox modeBox;
  }
}

