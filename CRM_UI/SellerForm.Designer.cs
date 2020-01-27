namespace CRM_UI
{
    partial class SellerForm
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
            this.addSellerButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.sellerNameTextbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // addSellerButton
            // 
            this.addSellerButton.Location = new System.Drawing.Point(117, 38);
            this.addSellerButton.Name = "addSellerButton";
            this.addSellerButton.Size = new System.Drawing.Size(75, 23);
            this.addSellerButton.TabIndex = 5;
            this.addSellerButton.Text = "Add";
            this.addSellerButton.UseVisualStyleBackColor = true;
            this.addSellerButton.Click += new System.EventHandler(this.AddSellerButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Name";
            // 
            // sellerNameTextbox
            // 
            this.sellerNameTextbox.Location = new System.Drawing.Point(61, 12);
            this.sellerNameTextbox.Name = "sellerNameTextbox";
            this.sellerNameTextbox.Size = new System.Drawing.Size(210, 20);
            this.sellerNameTextbox.TabIndex = 3;
            // 
            // AddSellerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 69);
            this.Controls.Add(this.addSellerButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sellerNameTextbox);
            this.Name = "AddSellerForm";
            this.Text = "AddSellerForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addSellerButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox sellerNameTextbox;
    }
}