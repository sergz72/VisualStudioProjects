namespace classes
{
  partial class cdce913_control_form
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
      System.Windows.Forms.Label label3;
      System.Windows.Forms.Label label4;
      System.Windows.Forms.Label label5;
      this.bnInit = new System.Windows.Forms.Button();
      this.bnSave = new System.Windows.Forms.Button();
      this.bnExit = new System.Windows.Forms.Button();
      this.bnFreqSet = new System.Windows.Forms.Button();
      this.y1_pdiv = new System.Windows.Forms.TextBox();
      this.bnY1Disable = new System.Windows.Forms.Button();
      this.bnY1Enable = new System.Windows.Forms.Button();
      this.bnY2Y3Enable = new System.Windows.Forms.Button();
      this.bnY2Y3Disable = new System.Windows.Forms.Button();
      this.bnY2PdivSet = new System.Windows.Forms.Button();
      this.bnY3PdivSet = new System.Windows.Forms.Button();
      this.y3_pdiv = new classes.NumericBox();
      this.y2_pdiv = new classes.NumericBox();
      this.y1_frequency = new classes.NumericBox();
      this.FOSC = new classes.NumericBox();
      label1 = new System.Windows.Forms.Label();
      label2 = new System.Windows.Forms.Label();
      label3 = new System.Windows.Forms.Label();
      label4 = new System.Windows.Forms.Label();
      label5 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Location = new System.Drawing.Point(13, 76);
      label1.Name = "label1";
      label1.Size = new System.Drawing.Size(95, 13);
      label1.TabIndex = 4;
      label1.Text = "Y1 frequency, kHz";
      // 
      // label2
      // 
      label2.AutoSize = true;
      label2.Location = new System.Drawing.Point(65, 102);
      label2.Name = "label2";
      label2.Size = new System.Drawing.Size(43, 13);
      label2.TabIndex = 6;
      label2.Text = "Y1 pdiv";
      // 
      // label3
      // 
      label3.AutoSize = true;
      label3.Location = new System.Drawing.Point(65, 128);
      label3.Name = "label3";
      label3.Size = new System.Drawing.Size(43, 13);
      label3.TabIndex = 8;
      label3.Text = "Y2 pdiv";
      // 
      // label4
      // 
      label4.AutoSize = true;
      label4.Location = new System.Drawing.Point(65, 154);
      label4.Name = "label4";
      label4.Size = new System.Drawing.Size(43, 13);
      label4.TabIndex = 10;
      label4.Text = "Y3 pdiv";
      // 
      // bnInit
      // 
      this.bnInit.Location = new System.Drawing.Point(12, 38);
      this.bnInit.Name = "bnInit";
      this.bnInit.Size = new System.Drawing.Size(355, 23);
      this.bnInit.TabIndex = 0;
      this.bnInit.Text = "Init";
      this.bnInit.UseVisualStyleBackColor = true;
      this.bnInit.Click += new System.EventHandler(this.bnInit_Click);
      // 
      // bnSave
      // 
      this.bnSave.Enabled = false;
      this.bnSave.Location = new System.Drawing.Point(12, 173);
      this.bnSave.Name = "bnSave";
      this.bnSave.Size = new System.Drawing.Size(355, 23);
      this.bnSave.TabIndex = 1;
      this.bnSave.Text = "Save settings to EEPROM";
      this.bnSave.UseVisualStyleBackColor = true;
      this.bnSave.Click += new System.EventHandler(this.bnSave_Click);
      // 
      // bnExit
      // 
      this.bnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.bnExit.Location = new System.Drawing.Point(373, 38);
      this.bnExit.Name = "bnExit";
      this.bnExit.Size = new System.Drawing.Size(75, 158);
      this.bnExit.TabIndex = 2;
      this.bnExit.Text = "Exit";
      this.bnExit.UseVisualStyleBackColor = true;
      // 
      // bnFreqSet
      // 
      this.bnFreqSet.Enabled = false;
      this.bnFreqSet.Location = new System.Drawing.Point(211, 66);
      this.bnFreqSet.Name = "bnFreqSet";
      this.bnFreqSet.Size = new System.Drawing.Size(156, 23);
      this.bnFreqSet.TabIndex = 3;
      this.bnFreqSet.Text = "Set";
      this.bnFreqSet.UseVisualStyleBackColor = true;
      this.bnFreqSet.Click += new System.EventHandler(this.bnFreqSet_Click);
      // 
      // y1_pdiv
      // 
      this.y1_pdiv.Location = new System.Drawing.Point(114, 95);
      this.y1_pdiv.Name = "y1_pdiv";
      this.y1_pdiv.ReadOnly = true;
      this.y1_pdiv.Size = new System.Drawing.Size(91, 20);
      this.y1_pdiv.TabIndex = 7;
      // 
      // bnY1Disable
      // 
      this.bnY1Disable.Enabled = false;
      this.bnY1Disable.Location = new System.Drawing.Point(211, 92);
      this.bnY1Disable.Name = "bnY1Disable";
      this.bnY1Disable.Size = new System.Drawing.Size(75, 23);
      this.bnY1Disable.TabIndex = 12;
      this.bnY1Disable.Text = "Y1 disable";
      this.bnY1Disable.UseVisualStyleBackColor = true;
      this.bnY1Disable.Click += new System.EventHandler(this.bnY1Disable_Click);
      // 
      // bnY1Enable
      // 
      this.bnY1Enable.Enabled = false;
      this.bnY1Enable.Location = new System.Drawing.Point(292, 92);
      this.bnY1Enable.Name = "bnY1Enable";
      this.bnY1Enable.Size = new System.Drawing.Size(75, 23);
      this.bnY1Enable.TabIndex = 13;
      this.bnY1Enable.Text = "Y1 enable";
      this.bnY1Enable.UseVisualStyleBackColor = true;
      this.bnY1Enable.Click += new System.EventHandler(this.bnY1Enable_Click);
      // 
      // bnY2Y3Enable
      // 
      this.bnY2Y3Enable.Enabled = false;
      this.bnY2Y3Enable.Location = new System.Drawing.Point(322, 118);
      this.bnY2Y3Enable.Name = "bnY2Y3Enable";
      this.bnY2Y3Enable.Size = new System.Drawing.Size(47, 49);
      this.bnY2Y3Enable.TabIndex = 15;
      this.bnY2Y3Enable.Text = "Y2,Y3 enable";
      this.bnY2Y3Enable.UseVisualStyleBackColor = true;
      this.bnY2Y3Enable.Click += new System.EventHandler(this.bnY2Y3Enable_Click);
      // 
      // bnY2Y3Disable
      // 
      this.bnY2Y3Disable.Enabled = false;
      this.bnY2Y3Disable.Location = new System.Drawing.Point(268, 118);
      this.bnY2Y3Disable.Name = "bnY2Y3Disable";
      this.bnY2Y3Disable.Size = new System.Drawing.Size(48, 49);
      this.bnY2Y3Disable.TabIndex = 14;
      this.bnY2Y3Disable.Text = "Y2,Y3 disable";
      this.bnY2Y3Disable.UseVisualStyleBackColor = true;
      this.bnY2Y3Disable.Click += new System.EventHandler(this.bnY2Y3Disable_Click);
      // 
      // label5
      // 
      label5.AutoSize = true;
      label5.Location = new System.Drawing.Point(48, 19);
      label5.Name = "label5";
      label5.Size = new System.Drawing.Size(60, 13);
      label5.TabIndex = 16;
      label5.Text = "FOSC, kHz";
      // 
      // bnY2PdivSet
      // 
      this.bnY2PdivSet.Enabled = false;
      this.bnY2PdivSet.Location = new System.Drawing.Point(211, 119);
      this.bnY2PdivSet.Name = "bnY2PdivSet";
      this.bnY2PdivSet.Size = new System.Drawing.Size(51, 23);
      this.bnY2PdivSet.TabIndex = 18;
      this.bnY2PdivSet.Text = "Set";
      this.bnY2PdivSet.UseVisualStyleBackColor = true;
      this.bnY2PdivSet.Click += new System.EventHandler(this.bnY2PdivSet_Click);
      // 
      // bnY3PdivSet
      // 
      this.bnY3PdivSet.Enabled = false;
      this.bnY3PdivSet.Location = new System.Drawing.Point(211, 145);
      this.bnY3PdivSet.Name = "bnY3PdivSet";
      this.bnY3PdivSet.Size = new System.Drawing.Size(51, 23);
      this.bnY3PdivSet.TabIndex = 19;
      this.bnY3PdivSet.Text = "Set";
      this.bnY3PdivSet.UseVisualStyleBackColor = true;
      this.bnY3PdivSet.Click += new System.EventHandler(this.bnY3PdivSet_Click);
      // 
      // y3_pdiv
      // 
      this.y3_pdiv.allowMinus = false;
      this.y3_pdiv.allowPoint = false;
      this.y3_pdiv.Location = new System.Drawing.Point(114, 148);
      this.y3_pdiv.Name = "y3_pdiv";
      this.y3_pdiv.Size = new System.Drawing.Size(91, 20);
      this.y3_pdiv.TabIndex = 23;
      this.y3_pdiv.TextChanged += new System.EventHandler(this.y3_pdiv_TextChanged);
      // 
      // y2_pdiv
      // 
      this.y2_pdiv.allowMinus = false;
      this.y2_pdiv.allowPoint = false;
      this.y2_pdiv.Location = new System.Drawing.Point(114, 122);
      this.y2_pdiv.Name = "y2_pdiv";
      this.y2_pdiv.Size = new System.Drawing.Size(91, 20);
      this.y2_pdiv.TabIndex = 22;
      this.y2_pdiv.TextChanged += new System.EventHandler(this.y2_pdiv_TextChanged);
      // 
      // y1_frequency
      // 
      this.y1_frequency.allowMinus = false;
      this.y1_frequency.allowPoint = false;
      this.y1_frequency.Location = new System.Drawing.Point(114, 69);
      this.y1_frequency.Name = "y1_frequency";
      this.y1_frequency.Size = new System.Drawing.Size(91, 20);
      this.y1_frequency.TabIndex = 21;
      this.y1_frequency.TextChanged += new System.EventHandler(this.y1_frequency_TextChanged);
      // 
      // FOSC
      // 
      this.FOSC.allowMinus = false;
      this.FOSC.allowPoint = false;
      this.FOSC.Location = new System.Drawing.Point(114, 11);
      this.FOSC.Name = "FOSC";
      this.FOSC.Size = new System.Drawing.Size(91, 20);
      this.FOSC.TabIndex = 20;
      this.FOSC.TextChanged += new System.EventHandler(this.FOSC_TextChanged);
      // 
      // cdce913_control_form
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.bnExit;
      this.ClientSize = new System.Drawing.Size(460, 208);
      this.Controls.Add(this.y3_pdiv);
      this.Controls.Add(this.y2_pdiv);
      this.Controls.Add(this.y1_frequency);
      this.Controls.Add(this.FOSC);
      this.Controls.Add(this.bnY3PdivSet);
      this.Controls.Add(this.bnY2PdivSet);
      this.Controls.Add(label5);
      this.Controls.Add(this.bnY2Y3Enable);
      this.Controls.Add(this.bnY2Y3Disable);
      this.Controls.Add(this.bnY1Enable);
      this.Controls.Add(this.bnY1Disable);
      this.Controls.Add(label4);
      this.Controls.Add(label3);
      this.Controls.Add(this.y1_pdiv);
      this.Controls.Add(label2);
      this.Controls.Add(label1);
      this.Controls.Add(this.bnFreqSet);
      this.Controls.Add(this.bnExit);
      this.Controls.Add(this.bnSave);
      this.Controls.Add(this.bnInit);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Name = "cdce913_control_form";
      this.Text = "cdce913 control";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button bnInit;
    private System.Windows.Forms.Button bnSave;
    private System.Windows.Forms.Button bnExit;
    private System.Windows.Forms.Button bnFreqSet;
    private System.Windows.Forms.TextBox y1_pdiv;
    private System.Windows.Forms.Button bnY1Disable;
    private System.Windows.Forms.Button bnY1Enable;
    private System.Windows.Forms.Button bnY2Y3Enable;
    private System.Windows.Forms.Button bnY2Y3Disable;
    private System.Windows.Forms.Button bnY2PdivSet;
    private System.Windows.Forms.Button bnY3PdivSet;
    private NumericBox FOSC;
    private NumericBox y1_frequency;
    private NumericBox y2_pdiv;
    private NumericBox y3_pdiv;
  }
}