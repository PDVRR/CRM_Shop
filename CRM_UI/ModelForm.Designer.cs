namespace CRM_UI
{
    partial class ModelForm
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
            this.startButton = new System.Windows.Forms.Button();
            this.customerSpeedNUD = new System.Windows.Forms.NumericUpDown();
            this.cashRegisterSpeedNUD = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.customerSpeedNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cashRegisterSpeedNUD)).BeginInit();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(695, 415);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // customerSpeedNUD
            // 
            this.customerSpeedNUD.Location = new System.Drawing.Point(668, 12);
            this.customerSpeedNUD.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.customerSpeedNUD.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.customerSpeedNUD.Name = "customerSpeedNUD";
            this.customerSpeedNUD.Size = new System.Drawing.Size(120, 20);
            this.customerSpeedNUD.TabIndex = 1;
            this.customerSpeedNUD.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.customerSpeedNUD.ValueChanged += new System.EventHandler(this.customerSpeedNUD_ValueChanged);
            // 
            // cashRegisterSpeedNUD
            // 
            this.cashRegisterSpeedNUD.Location = new System.Drawing.Point(668, 38);
            this.cashRegisterSpeedNUD.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.cashRegisterSpeedNUD.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.cashRegisterSpeedNUD.Name = "cashRegisterSpeedNUD";
            this.cashRegisterSpeedNUD.Size = new System.Drawing.Size(120, 20);
            this.cashRegisterSpeedNUD.TabIndex = 2;
            this.cashRegisterSpeedNUD.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.cashRegisterSpeedNUD.ValueChanged += new System.EventHandler(this.cashRegisterSpeedNUD_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(565, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Customer speed:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(565, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Cashbox speed:";
            // 
            // ModelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cashRegisterSpeedNUD);
            this.Controls.Add(this.customerSpeedNUD);
            this.Controls.Add(this.startButton);
            this.Name = "ModelForm";
            this.Text = "ModelForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ModelForm_FormClosing);
            this.Load += new System.EventHandler(this.ModelForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.customerSpeedNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cashRegisterSpeedNUD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.NumericUpDown customerSpeedNUD;
        private System.Windows.Forms.NumericUpDown cashRegisterSpeedNUD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}