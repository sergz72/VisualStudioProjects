namespace classes
{
  partial class ad4360_control_form
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
      System.Windows.Forms.Label label5;
      System.Windows.Forms.GroupBox groupBox1;
      System.Windows.Forms.Label label2;
      System.Windows.Forms.Label label1;
      System.Windows.Forms.GroupBox groupBox2;
      System.Windows.Forms.GroupBox groupBox3;
      System.Windows.Forms.Label label3;
      System.Windows.Forms.Label label4;
      System.Windows.Forms.Label label6;
      System.Windows.Forms.Label label7;
      System.Windows.Forms.Label label8;
      System.Windows.Forms.Label label111;
      System.Windows.Forms.GroupBox groupBox5;
      this.corePowerLevel = new System.Windows.Forms.ComboBox();
      this.bnSyncPowerDown = new System.Windows.Forms.RadioButton();
      this.bnAsyncPowerDown = new System.Windows.Forms.RadioButton();
      this.bnPowerNormal = new System.Windows.Forms.RadioButton();
      this.bnCPThreeState = new System.Windows.Forms.CheckBox();
      this.currentSetting2 = new System.Windows.Forms.ComboBox();
      this.currentSetting1 = new System.Windows.Forms.ComboBox();
      this.bnCurrentSetting2 = new System.Windows.Forms.RadioButton();
      this.bnCurrentSetting1 = new System.Windows.Forms.RadioButton();
      this.bnPhaseDetPolPos = new System.Windows.Forms.RadioButton();
      this.bnPhaseDetPolNeg = new System.Windows.Forms.RadioButton();
      this.bnExit = new System.Windows.Forms.Button();
      this.bnFreqSet = new System.Windows.Forms.Button();
      this.bnCounterReset = new System.Windows.Forms.CheckBox();
      this.bnMuteTillLockDetect = new System.Windows.Forms.CheckBox();
      this.outPowerLevel = new System.Windows.Forms.ComboBox();
      this.muxoutControl = new System.Windows.Forms.ComboBox();
      this.bnSetControlWord = new System.Windows.Forms.Button();
      this.bnSetRCounterWord = new System.Windows.Forms.Button();
      this.label9 = new System.Windows.Forms.Label();
      this.bandSelClockDiv = new System.Windows.Forms.ComboBox();
      this.antiBLPW = new System.Windows.Forms.ComboBox();
      this.bnThreeCycles = new System.Windows.Forms.RadioButton();
      this.bnFiveCycles = new System.Windows.Forms.RadioButton();
      this.nCounterValue = new classes.NumericBox();
      this.rCounterValue = new classes.NumericBox();
      this.referenceFreq = new classes.NumericBox();
      this.out_freq = new classes.NumericBox();
      this.FOSC = new classes.NumericBox();
      label5 = new System.Windows.Forms.Label();
      groupBox1 = new System.Windows.Forms.GroupBox();
      label2 = new System.Windows.Forms.Label();
      label1 = new System.Windows.Forms.Label();
      groupBox2 = new System.Windows.Forms.GroupBox();
      groupBox3 = new System.Windows.Forms.GroupBox();
      label3 = new System.Windows.Forms.Label();
      label4 = new System.Windows.Forms.Label();
      label6 = new System.Windows.Forms.Label();
      label7 = new System.Windows.Forms.Label();
      label8 = new System.Windows.Forms.Label();
      label111 = new System.Windows.Forms.Label();
      groupBox5 = new System.Windows.Forms.GroupBox();
      groupBox1.SuspendLayout();
      groupBox2.SuspendLayout();
      groupBox3.SuspendLayout();
      groupBox5.SuspendLayout();
      this.SuspendLayout();
      // 
      // label5
      // 
      label5.AutoSize = true;
      label5.Location = new System.Drawing.Point(12, 18);
      label5.Name = "label5";
      label5.Size = new System.Drawing.Size(60, 13);
      label5.TabIndex = 21;
      label5.Text = "FOSC, kHz";
      // 
      // groupBox1
      // 
      groupBox1.Controls.Add(this.corePowerLevel);
      groupBox1.Controls.Add(label2);
      groupBox1.Controls.Add(this.bnSyncPowerDown);
      groupBox1.Controls.Add(this.bnAsyncPowerDown);
      groupBox1.Controls.Add(this.bnPowerNormal);
      groupBox1.Location = new System.Drawing.Point(15, 36);
      groupBox1.Name = "groupBox1";
      groupBox1.Size = new System.Drawing.Size(342, 95);
      groupBox1.TabIndex = 24;
      groupBox1.TabStop = false;
      groupBox1.Text = "Core power control";
      // 
      // corePowerLevel
      // 
      this.corePowerLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.corePowerLevel.FormattingEnabled = true;
      this.corePowerLevel.Location = new System.Drawing.Point(238, 13);
      this.corePowerLevel.Name = "corePowerLevel";
      this.corePowerLevel.Size = new System.Drawing.Size(98, 21);
      this.corePowerLevel.TabIndex = 4;
      // 
      // label2
      // 
      label2.AutoSize = true;
      label2.Location = new System.Drawing.Point(169, 22);
      label2.Name = "label2";
      label2.Size = new System.Drawing.Size(62, 13);
      label2.TabIndex = 3;
      label2.Text = "Power level";
      // 
      // bnSyncPowerDown
      // 
      this.bnSyncPowerDown.AutoSize = true;
      this.bnSyncPowerDown.Location = new System.Drawing.Point(7, 68);
      this.bnSyncPowerDown.Name = "bnSyncPowerDown";
      this.bnSyncPowerDown.Size = new System.Drawing.Size(148, 17);
      this.bnSyncPowerDown.TabIndex = 2;
      this.bnSyncPowerDown.Text = "Synchronous power down";
      this.bnSyncPowerDown.UseVisualStyleBackColor = true;
      // 
      // bnAsyncPowerDown
      // 
      this.bnAsyncPowerDown.AutoSize = true;
      this.bnAsyncPowerDown.Location = new System.Drawing.Point(7, 44);
      this.bnAsyncPowerDown.Name = "bnAsyncPowerDown";
      this.bnAsyncPowerDown.Size = new System.Drawing.Size(153, 17);
      this.bnAsyncPowerDown.TabIndex = 1;
      this.bnAsyncPowerDown.Text = "Asynchronous power down";
      this.bnAsyncPowerDown.UseVisualStyleBackColor = true;
      // 
      // bnPowerNormal
      // 
      this.bnPowerNormal.AutoSize = true;
      this.bnPowerNormal.Checked = true;
      this.bnPowerNormal.Location = new System.Drawing.Point(7, 20);
      this.bnPowerNormal.Name = "bnPowerNormal";
      this.bnPowerNormal.Size = new System.Drawing.Size(105, 17);
      this.bnPowerNormal.TabIndex = 0;
      this.bnPowerNormal.TabStop = true;
      this.bnPowerNormal.Text = "Normal operation";
      this.bnPowerNormal.UseVisualStyleBackColor = true;
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Location = new System.Drawing.Point(153, 17);
      label1.Name = "label1";
      label1.Size = new System.Drawing.Size(111, 13);
      label1.TabIndex = 26;
      label1.Text = "Output requency, kHz";
      // 
      // groupBox2
      // 
      groupBox2.Controls.Add(this.bnCPThreeState);
      groupBox2.Controls.Add(this.currentSetting2);
      groupBox2.Controls.Add(this.currentSetting1);
      groupBox2.Controls.Add(this.bnCurrentSetting2);
      groupBox2.Controls.Add(this.bnCurrentSetting1);
      groupBox2.Location = new System.Drawing.Point(15, 137);
      groupBox2.Name = "groupBox2";
      groupBox2.Size = new System.Drawing.Size(199, 94);
      groupBox2.TabIndex = 28;
      groupBox2.TabStop = false;
      groupBox2.Text = "Charge pump settings";
      // 
      // bnCPThreeState
      // 
      this.bnCPThreeState.AutoSize = true;
      this.bnCPThreeState.Location = new System.Drawing.Point(7, 71);
      this.bnCPThreeState.Name = "bnCPThreeState";
      this.bnCPThreeState.Size = new System.Drawing.Size(137, 17);
      this.bnCPThreeState.TabIndex = 4;
      this.bnCPThreeState.Text = "Charge pump output off";
      this.bnCPThreeState.UseVisualStyleBackColor = true;
      // 
      // currentSetting2
      // 
      this.currentSetting2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.currentSetting2.FormattingEnabled = true;
      this.currentSetting2.Location = new System.Drawing.Point(115, 43);
      this.currentSetting2.Name = "currentSetting2";
      this.currentSetting2.Size = new System.Drawing.Size(74, 21);
      this.currentSetting2.TabIndex = 3;
      // 
      // currentSetting1
      // 
      this.currentSetting1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.currentSetting1.FormattingEnabled = true;
      this.currentSetting1.Location = new System.Drawing.Point(115, 16);
      this.currentSetting1.Name = "currentSetting1";
      this.currentSetting1.Size = new System.Drawing.Size(74, 21);
      this.currentSetting1.TabIndex = 2;
      // 
      // bnCurrentSetting2
      // 
      this.bnCurrentSetting2.AutoSize = true;
      this.bnCurrentSetting2.Location = new System.Drawing.Point(6, 47);
      this.bnCurrentSetting2.Name = "bnCurrentSetting2";
      this.bnCurrentSetting2.Size = new System.Drawing.Size(102, 17);
      this.bnCurrentSetting2.TabIndex = 1;
      this.bnCurrentSetting2.Text = "Current setting 2";
      this.bnCurrentSetting2.UseVisualStyleBackColor = true;
      // 
      // bnCurrentSetting1
      // 
      this.bnCurrentSetting1.AutoSize = true;
      this.bnCurrentSetting1.Checked = true;
      this.bnCurrentSetting1.Location = new System.Drawing.Point(7, 20);
      this.bnCurrentSetting1.Name = "bnCurrentSetting1";
      this.bnCurrentSetting1.Size = new System.Drawing.Size(102, 17);
      this.bnCurrentSetting1.TabIndex = 0;
      this.bnCurrentSetting1.TabStop = true;
      this.bnCurrentSetting1.Text = "Current setting 1";
      this.bnCurrentSetting1.UseVisualStyleBackColor = true;
      // 
      // groupBox3
      // 
      groupBox3.Controls.Add(this.bnPhaseDetPolPos);
      groupBox3.Controls.Add(this.bnPhaseDetPolNeg);
      groupBox3.Location = new System.Drawing.Point(220, 137);
      groupBox3.Name = "groupBox3";
      groupBox3.Size = new System.Drawing.Size(137, 66);
      groupBox3.TabIndex = 29;
      groupBox3.TabStop = false;
      groupBox3.Text = "Phase detector polarity";
      // 
      // bnPthasDetPolPos
      // 
      this.bnPhaseDetPolPos.AutoSize = true;
      this.bnPhaseDetPolPos.Checked = true;
      this.bnPhaseDetPolPos.Location = new System.Drawing.Point(7, 42);
      this.bnPhaseDetPolPos.Name = "bnPthasDetPolPos";
      this.bnPhaseDetPolPos.Size = new System.Drawing.Size(62, 17);
      this.bnPhaseDetPolPos.TabIndex = 1;
      this.bnPhaseDetPolPos.TabStop = true;
      this.bnPhaseDetPolPos.Text = "Positive";
      this.bnPhaseDetPolPos.UseVisualStyleBackColor = true;
      // 
      // bnPhaseDetPolNeg
      // 
      this.bnPhaseDetPolNeg.AutoSize = true;
      this.bnPhaseDetPolNeg.Location = new System.Drawing.Point(7, 19);
      this.bnPhaseDetPolNeg.Name = "bnPhaseDetPolNeg";
      this.bnPhaseDetPolNeg.Size = new System.Drawing.Size(68, 17);
      this.bnPhaseDetPolNeg.TabIndex = 0;
      this.bnPhaseDetPolNeg.Text = "Negative";
      this.bnPhaseDetPolNeg.UseVisualStyleBackColor = true;
      // 
      // label3
      // 
      label3.AutoSize = true;
      label3.Location = new System.Drawing.Point(140, 237);
      label3.Name = "label3";
      label3.Size = new System.Drawing.Size(96, 13);
      label3.TabIndex = 32;
      label3.Text = "Output power level";
      // 
      // label4
      // 
      label4.AutoSize = true;
      label4.Location = new System.Drawing.Point(140, 264);
      label4.Name = "label4";
      label4.Size = new System.Drawing.Size(77, 13);
      label4.TabIndex = 33;
      label4.Text = "Muxout control";
      // 
      // label6
      // 
      label6.AutoSize = true;
      label6.Location = new System.Drawing.Point(15, 323);
      label6.Name = "label6";
      label6.Size = new System.Drawing.Size(132, 13);
      label6.TabIndex = 37;
      label6.Text = "Reference frequency, kHz";
      // 
      // label7
      // 
      label7.AutoSize = true;
      label7.Location = new System.Drawing.Point(231, 323);
      label7.Name = "label7";
      label7.Size = new System.Drawing.Size(83, 13);
      label7.TabIndex = 39;
      label7.Text = "R counter value";
      // 
      // label8
      // 
      label8.AutoSize = true;
      label8.Location = new System.Drawing.Point(15, 378);
      label8.Name = "label8";
      label8.Size = new System.Drawing.Size(83, 13);
      label8.TabIndex = 42;
      label8.Text = "N counter value";
      // 
      // bnExit
      // 
      this.bnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.bnExit.Location = new System.Drawing.Point(363, 38);
      this.bnExit.Name = "bnExit";
      this.bnExit.Size = new System.Drawing.Size(75, 211);
      this.bnExit.TabIndex = 23;
      this.bnExit.Text = "Exit";
      this.bnExit.UseVisualStyleBackColor = true;
      // 
      // bnFreqSet
      // 
      this.bnFreqSet.Enabled = false;
      this.bnFreqSet.Location = new System.Drawing.Point(367, 6);
      this.bnFreqSet.Name = "bnFreqSet";
      this.bnFreqSet.Size = new System.Drawing.Size(71, 23);
      this.bnFreqSet.TabIndex = 25;
      this.bnFreqSet.Text = "Set";
      this.bnFreqSet.UseVisualStyleBackColor = true;
      this.bnFreqSet.Click += new System.EventHandler(this.bnFreqSet_Click);
      // 
      // bnCounterReset
      // 
      this.bnCounterReset.AutoSize = true;
      this.bnCounterReset.Location = new System.Drawing.Point(15, 237);
      this.bnCounterReset.Name = "bnCounterReset";
      this.bnCounterReset.Size = new System.Drawing.Size(98, 17);
      this.bnCounterReset.TabIndex = 30;
      this.bnCounterReset.Text = "Reset counters";
      this.bnCounterReset.UseVisualStyleBackColor = true;
      // 
      // bnMuteTillLockDetect
      // 
      this.bnMuteTillLockDetect.AutoSize = true;
      this.bnMuteTillLockDetect.Location = new System.Drawing.Point(15, 264);
      this.bnMuteTillLockDetect.Name = "bnMuteTillLockDetect";
      this.bnMuteTillLockDetect.Size = new System.Drawing.Size(118, 17);
      this.bnMuteTillLockDetect.TabIndex = 31;
      this.bnMuteTillLockDetect.Text = "Mute till lock detect";
      this.bnMuteTillLockDetect.UseVisualStyleBackColor = true;
      // 
      // outPowerLevel
      // 
      this.outPowerLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.outPowerLevel.FormattingEnabled = true;
      this.outPowerLevel.Location = new System.Drawing.Point(243, 228);
      this.outPowerLevel.Name = "outPowerLevel";
      this.outPowerLevel.Size = new System.Drawing.Size(73, 21);
      this.outPowerLevel.TabIndex = 34;
      // 
      // muxoutControl
      // 
      this.muxoutControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.muxoutControl.FormattingEnabled = true;
      this.muxoutControl.Location = new System.Drawing.Point(243, 255);
      this.muxoutControl.Name = "muxoutControl";
      this.muxoutControl.Size = new System.Drawing.Size(195, 21);
      this.muxoutControl.TabIndex = 35;
      // 
      // bnSetControlWord
      // 
      this.bnSetControlWord.Location = new System.Drawing.Point(12, 287);
      this.bnSetControlWord.Name = "bnSetControlWord";
      this.bnSetControlWord.Size = new System.Drawing.Size(426, 23);
      this.bnSetControlWord.TabIndex = 36;
      this.bnSetControlWord.Text = "Set control word";
      this.bnSetControlWord.UseVisualStyleBackColor = true;
      this.bnSetControlWord.Click += new System.EventHandler(this.bnSetControlWord_Click);
      // 
      // bnSetRCounterWord
      // 
      this.bnSetRCounterWord.Location = new System.Drawing.Point(12, 342);
      this.bnSetRCounterWord.Name = "bnSetRCounterWord";
      this.bnSetRCounterWord.Size = new System.Drawing.Size(426, 23);
      this.bnSetRCounterWord.TabIndex = 41;
      this.bnSetRCounterWord.Text = "Set R counter word";
      this.bnSetRCounterWord.UseVisualStyleBackColor = true;
      this.bnSetRCounterWord.Click += new System.EventHandler(this.bnSetRCounterWord_Click);
      // 
      // label111
      // 
      label111.AutoSize = true;
      label111.Location = new System.Drawing.Point(15, 405);
      label111.Name = "label111";
      label111.Size = new System.Drawing.Size(126, 13);
      label111.TabIndex = 44;
      label111.Text = "Band select clock divider";
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(15, 432);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(127, 13);
      this.label9.TabIndex = 45;
      this.label9.Text = "Anti backlash pulse width";
      // 
      // bandSelClockDiv
      // 
      this.bandSelClockDiv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.bandSelClockDiv.FormattingEnabled = true;
      this.bandSelClockDiv.Location = new System.Drawing.Point(147, 397);
      this.bandSelClockDiv.Name = "bandSelClockDiv";
      this.bandSelClockDiv.Size = new System.Drawing.Size(74, 21);
      this.bandSelClockDiv.TabIndex = 46;
      // 
      // antiBLPW
      // 
      this.antiBLPW.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.antiBLPW.FormattingEnabled = true;
      this.antiBLPW.Location = new System.Drawing.Point(148, 424);
      this.antiBLPW.Name = "antiBLPW";
      this.antiBLPW.Size = new System.Drawing.Size(73, 21);
      this.antiBLPW.TabIndex = 47;
      // 
      // groupBox5
      // 
      groupBox5.Controls.Add(this.bnFiveCycles);
      groupBox5.Controls.Add(this.bnThreeCycles);
      groupBox5.Location = new System.Drawing.Point(227, 371);
      groupBox5.Name = "groupBox5";
      groupBox5.Size = new System.Drawing.Size(160, 74);
      groupBox5.TabIndex = 49;
      groupBox5.TabStop = false;
      groupBox5.Text = "Lock detect precision";
      // 
      // bnThreeCycles
      // 
      this.bnThreeCycles.AutoSize = true;
      this.bnThreeCycles.Checked = true;
      this.bnThreeCycles.Location = new System.Drawing.Point(7, 19);
      this.bnThreeCycles.Name = "bnThreeCycles";
      this.bnThreeCycles.Size = new System.Drawing.Size(147, 17);
      this.bnThreeCycles.TabIndex = 0;
      this.bnThreeCycles.TabStop = true;
      this.bnThreeCycles.Text = "Three consecutive cycles";
      this.bnThreeCycles.UseVisualStyleBackColor = true;
      // 
      // bnFiveCycles
      // 
      this.bnFiveCycles.AutoSize = true;
      this.bnFiveCycles.Location = new System.Drawing.Point(7, 42);
      this.bnFiveCycles.Name = "bnFiveCycles";
      this.bnFiveCycles.Size = new System.Drawing.Size(139, 17);
      this.bnFiveCycles.TabIndex = 1;
      this.bnFiveCycles.Text = "Five consecutive cycles";
      this.bnFiveCycles.UseVisualStyleBackColor = true;
      // 
      // nCounterValue
      // 
      this.nCounterValue.allowMinus = false;
      this.nCounterValue.allowPoint = false;
      this.nCounterValue.Location = new System.Drawing.Point(104, 371);
      this.nCounterValue.Name = "nCounterValue";
      this.nCounterValue.Size = new System.Drawing.Size(117, 20);
      this.nCounterValue.TabIndex = 43;
      this.nCounterValue.TextChanged += new System.EventHandler(this.nCounterValue_TextChanged);
      // 
      // rCounterValue
      // 
      this.rCounterValue.allowMinus = false;
      this.rCounterValue.allowPoint = false;
      this.rCounterValue.Location = new System.Drawing.Point(320, 316);
      this.rCounterValue.Name = "rCounterValue";
      this.rCounterValue.Size = new System.Drawing.Size(117, 20);
      this.rCounterValue.TabIndex = 40;
      this.rCounterValue.TextChanged += new System.EventHandler(this.rCounterValue_TextChanged);
      // 
      // referenceFreq
      // 
      this.referenceFreq.allowMinus = false;
      this.referenceFreq.allowPoint = false;
      this.referenceFreq.Location = new System.Drawing.Point(156, 316);
      this.referenceFreq.Name = "referenceFreq";
      this.referenceFreq.Size = new System.Drawing.Size(69, 20);
      this.referenceFreq.TabIndex = 38;
      this.referenceFreq.Text = "100";
      this.referenceFreq.TextChanged += new System.EventHandler(this.referenceFreq_TextChanged);
      // 
      // out_freq
      // 
      this.out_freq.allowMinus = false;
      this.out_freq.allowPoint = false;
      this.out_freq.Location = new System.Drawing.Point(270, 9);
      this.out_freq.Name = "out_freq";
      this.out_freq.Size = new System.Drawing.Size(91, 20);
      this.out_freq.TabIndex = 27;
      this.out_freq.TextChanged += new System.EventHandler(this.out_freq_TextChanged);
      // 
      // FOSC
      // 
      this.FOSC.allowMinus = false;
      this.FOSC.allowPoint = false;
      this.FOSC.Location = new System.Drawing.Point(78, 10);
      this.FOSC.Name = "FOSC";
      this.FOSC.ReadOnly = true;
      this.FOSC.Size = new System.Drawing.Size(69, 20);
      this.FOSC.TabIndex = 22;
      this.FOSC.TextChanged += new System.EventHandler(this.out_freq_TextChanged);
      // 
      // ad4360_control_form
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(450, 461);
      this.Controls.Add(groupBox5);
      this.Controls.Add(this.antiBLPW);
      this.Controls.Add(this.bandSelClockDiv);
      this.Controls.Add(this.label9);
      this.Controls.Add(label111);
      this.Controls.Add(this.nCounterValue);
      this.Controls.Add(label8);
      this.Controls.Add(this.bnSetRCounterWord);
      this.Controls.Add(this.rCounterValue);
      this.Controls.Add(label7);
      this.Controls.Add(this.referenceFreq);
      this.Controls.Add(label6);
      this.Controls.Add(this.bnSetControlWord);
      this.Controls.Add(this.muxoutControl);
      this.Controls.Add(this.outPowerLevel);
      this.Controls.Add(label4);
      this.Controls.Add(label3);
      this.Controls.Add(this.bnMuteTillLockDetect);
      this.Controls.Add(this.bnCounterReset);
      this.Controls.Add(groupBox3);
      this.Controls.Add(groupBox2);
      this.Controls.Add(this.out_freq);
      this.Controls.Add(label1);
      this.Controls.Add(this.bnFreqSet);
      this.Controls.Add(groupBox1);
      this.Controls.Add(this.bnExit);
      this.Controls.Add(this.FOSC);
      this.Controls.Add(label5);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Name = "ad4360_control_form";
      this.Text = "ad4360 control";
      groupBox1.ResumeLayout(false);
      groupBox1.PerformLayout();
      groupBox2.ResumeLayout(false);
      groupBox2.PerformLayout();
      groupBox3.ResumeLayout(false);
      groupBox3.PerformLayout();
      groupBox5.ResumeLayout(false);
      groupBox5.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private NumericBox FOSC;
    private System.Windows.Forms.Button bnExit;
    private NumericBox out_freq;
    private System.Windows.Forms.Button bnFreqSet;
    private System.Windows.Forms.RadioButton bnPowerNormal;
    private System.Windows.Forms.RadioButton bnSyncPowerDown;
    private System.Windows.Forms.RadioButton bnAsyncPowerDown;
    private System.Windows.Forms.ComboBox corePowerLevel;
    private System.Windows.Forms.RadioButton bnCurrentSetting2;
    private System.Windows.Forms.RadioButton bnCurrentSetting1;
    private System.Windows.Forms.ComboBox currentSetting1;
    private System.Windows.Forms.ComboBox currentSetting2;
    private System.Windows.Forms.CheckBox bnCPThreeState;
    private System.Windows.Forms.RadioButton bnPhaseDetPolPos;
    private System.Windows.Forms.RadioButton bnPhaseDetPolNeg;
    private System.Windows.Forms.CheckBox bnCounterReset;
    private System.Windows.Forms.CheckBox bnMuteTillLockDetect;
    private System.Windows.Forms.ComboBox outPowerLevel;
    private System.Windows.Forms.ComboBox muxoutControl;
    private System.Windows.Forms.Button bnSetControlWord;
    private NumericBox referenceFreq;
    private NumericBox rCounterValue;
    private System.Windows.Forms.Button bnSetRCounterWord;
    private NumericBox nCounterValue;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.ComboBox bandSelClockDiv;
    private System.Windows.Forms.ComboBox antiBLPW;
    private System.Windows.Forms.RadioButton bnFiveCycles;
    private System.Windows.Forms.RadioButton bnThreeCycles;
  }
}