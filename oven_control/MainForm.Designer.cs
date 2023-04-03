namespace oven_control
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
      this.components = new System.ComponentModel.Container();
      System.Windows.Forms.Label label1;
      System.Windows.Forms.Label label2;
      System.Windows.Forms.Label label4;
      this.temp_panel = new System.Windows.Forms.Panel();
      this.program_code = new System.Windows.Forms.TextBox();
      this.bnStart = new System.Windows.Forms.Button();
      this.bnStop = new System.Windows.Forms.Button();
      this.bnExit = new System.Windows.Forms.Button();
      this.temp_value = new System.Windows.Forms.Label();
      this.time_value = new System.Windows.Forms.Label();
      this.bnLoadProgram = new System.Windows.Forms.Button();
      this.bnSaveProgram = new System.Windows.Forms.Button();
      this.timer = new System.Windows.Forms.Timer(this.components);
      label1 = new System.Windows.Forms.Label();
      label2 = new System.Windows.Forms.Label();
      label4 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // label1
      // 
      label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      label1.AutoSize = true;
      label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      label1.Location = new System.Drawing.Point(352, 1);
      label1.Name = "label1";
      label1.Size = new System.Drawing.Size(185, 13);
      label1.TabIndex = 2;
      label1.Text = "Program code (temp:time at each line)";
      // 
      // label2
      // 
      label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      label2.AutoSize = true;
      label2.Location = new System.Drawing.Point(568, 1);
      label2.Name = "label2";
      label2.Size = new System.Drawing.Size(37, 13);
      label2.TabIndex = 6;
      label2.Text = "Temp:";
      // 
      // label4
      // 
      label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      label4.AutoSize = true;
      label4.Location = new System.Drawing.Point(605, 53);
      label4.Name = "label4";
      label4.Size = new System.Drawing.Size(33, 13);
      label4.TabIndex = 9;
      label4.Text = "Time:";
      // 
      // temp_panel
      // 
      this.temp_panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.temp_panel.BackColor = System.Drawing.SystemColors.Window;
      this.temp_panel.Location = new System.Drawing.Point(1, 1);
      this.temp_panel.Name = "temp_panel";
      this.temp_panel.Size = new System.Drawing.Size(345, 355);
      this.temp_panel.TabIndex = 0;
      this.temp_panel.Paint += new System.Windows.Forms.PaintEventHandler(this.temp_panel_Paint);
      // 
      // program_code
      // 
      this.program_code.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.program_code.Location = new System.Drawing.Point(352, 17);
      this.program_code.Multiline = true;
      this.program_code.Name = "program_code";
      this.program_code.Size = new System.Drawing.Size(250, 337);
      this.program_code.TabIndex = 1;
      this.program_code.TextChanged += new System.EventHandler(this.program_code_TextChanged);
      // 
      // bnStart
      // 
      this.bnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.bnStart.Location = new System.Drawing.Point(608, 100);
      this.bnStart.Name = "bnStart";
      this.bnStart.Size = new System.Drawing.Size(75, 23);
      this.bnStart.TabIndex = 3;
      this.bnStart.Text = "Start";
      this.bnStart.UseVisualStyleBackColor = true;
      this.bnStart.Click += new System.EventHandler(this.bnStart_Click);
      // 
      // bnStop
      // 
      this.bnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.bnStop.Enabled = false;
      this.bnStop.Location = new System.Drawing.Point(608, 129);
      this.bnStop.Name = "bnStop";
      this.bnStop.Size = new System.Drawing.Size(75, 23);
      this.bnStop.TabIndex = 4;
      this.bnStop.Text = "Stop";
      this.bnStop.UseVisualStyleBackColor = true;
      this.bnStop.Click += new System.EventHandler(this.bnStop_Click);
      // 
      // bnExit
      // 
      this.bnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.bnExit.Location = new System.Drawing.Point(608, 240);
      this.bnExit.Name = "bnExit";
      this.bnExit.Size = new System.Drawing.Size(75, 23);
      this.bnExit.TabIndex = 5;
      this.bnExit.Text = "Exit";
      this.bnExit.UseVisualStyleBackColor = true;
      this.bnExit.Click += new System.EventHandler(this.bnExit_Click);
      // 
      // temp_value
      // 
      this.temp_value.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.temp_value.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.temp_value.Location = new System.Drawing.Point(604, 1);
      this.temp_value.Name = "temp_value";
      this.temp_value.Size = new System.Drawing.Size(89, 46);
      this.temp_value.TabIndex = 7;
      this.temp_value.Text = "000";
      this.temp_value.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // time_value
      // 
      this.time_value.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.time_value.AutoSize = true;
      this.time_value.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.time_value.Location = new System.Drawing.Point(604, 66);
      this.time_value.Name = "time_value";
      this.time_value.Size = new System.Drawing.Size(87, 31);
      this.time_value.TabIndex = 8;
      this.time_value.Text = "00:00";
      this.time_value.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // bnLoadProgram
      // 
      this.bnLoadProgram.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.bnLoadProgram.Location = new System.Drawing.Point(608, 158);
      this.bnLoadProgram.Name = "bnLoadProgram";
      this.bnLoadProgram.Size = new System.Drawing.Size(75, 35);
      this.bnLoadProgram.TabIndex = 10;
      this.bnLoadProgram.Text = "Load program";
      this.bnLoadProgram.UseVisualStyleBackColor = true;
      this.bnLoadProgram.Click += new System.EventHandler(this.bnLoadProgram_Click);
      // 
      // bnSaveProgram
      // 
      this.bnSaveProgram.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.bnSaveProgram.Enabled = false;
      this.bnSaveProgram.Location = new System.Drawing.Point(608, 199);
      this.bnSaveProgram.Name = "bnSaveProgram";
      this.bnSaveProgram.Size = new System.Drawing.Size(75, 35);
      this.bnSaveProgram.TabIndex = 11;
      this.bnSaveProgram.Text = "Save program";
      this.bnSaveProgram.UseVisualStyleBackColor = true;
      // 
      // timer
      // 
      this.timer.Interval = 1000;
      this.timer.Tick += new System.EventHandler(this.timer_Tick);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(695, 356);
      this.Controls.Add(this.bnSaveProgram);
      this.Controls.Add(this.bnLoadProgram);
      this.Controls.Add(label4);
      this.Controls.Add(this.time_value);
      this.Controls.Add(this.temp_value);
      this.Controls.Add(label2);
      this.Controls.Add(this.bnExit);
      this.Controls.Add(this.bnStop);
      this.Controls.Add(this.bnStart);
      this.Controls.Add(label1);
      this.Controls.Add(this.program_code);
      this.Controls.Add(this.temp_panel);
      this.Name = "MainForm";
      this.Text = "oven_control";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Panel temp_panel;
    private System.Windows.Forms.TextBox program_code;
    private System.Windows.Forms.Button bnStart;
    private System.Windows.Forms.Button bnStop;
    private System.Windows.Forms.Button bnExit;
    private System.Windows.Forms.Label temp_value;
    private System.Windows.Forms.Label time_value;
    private System.Windows.Forms.Button bnLoadProgram;
    private System.Windows.Forms.Button bnSaveProgram;
    private System.Windows.Forms.Timer timer;
  }
}

