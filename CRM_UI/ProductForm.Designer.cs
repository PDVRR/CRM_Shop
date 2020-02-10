namespace CRM_UI
{
    partial class ProductForm
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
            this.productNameTextbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.AddProductButton = new System.Windows.Forms.Button();
            this.productPriceNUD = new System.Windows.Forms.NumericUpDown();
            this.productCountNUD = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.productPriceNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productCountNUD)).BeginInit();
            this.SuspendLayout();
            // 
            // productNameTextbox
            // 
            this.productNameTextbox.Location = new System.Drawing.Point(141, 12);
            this.productNameTextbox.Name = "productNameTextbox";
            this.productNameTextbox.Size = new System.Drawing.Size(143, 20);
            this.productNameTextbox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Price";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Count";
            // 
            // AddProductButton
            // 
            this.AddProductButton.Location = new System.Drawing.Point(141, 140);
            this.AddProductButton.Name = "AddProductButton";
            this.AddProductButton.Size = new System.Drawing.Size(75, 23);
            this.AddProductButton.TabIndex = 6;
            this.AddProductButton.Text = "Add";
            this.AddProductButton.UseVisualStyleBackColor = true;
            this.AddProductButton.Click += new System.EventHandler(this.AddProductButton_Click);
            // 
            // productPriceNUD
            // 
            this.productPriceNUD.DecimalPlaces = 2;
            this.productPriceNUD.Location = new System.Drawing.Point(141, 47);
            this.productPriceNUD.Name = "productPriceNUD";
            this.productPriceNUD.Size = new System.Drawing.Size(143, 20);
            this.productPriceNUD.TabIndex = 7;
            this.productPriceNUD.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // productCountNUD
            // 
            this.productCountNUD.Location = new System.Drawing.Point(141, 85);
            this.productCountNUD.Name = "productCountNUD";
            this.productCountNUD.Size = new System.Drawing.Size(143, 20);
            this.productCountNUD.TabIndex = 8;
            // 
            // ProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 201);
            this.Controls.Add(this.productCountNUD);
            this.Controls.Add(this.productPriceNUD);
            this.Controls.Add(this.AddProductButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.productNameTextbox);
            this.Name = "ProductForm";
            this.Text = "AddProductForm";
            ((System.ComponentModel.ISupportInitialize)(this.productPriceNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productCountNUD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox productNameTextbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button AddProductButton;
        private System.Windows.Forms.NumericUpDown productPriceNUD;
        private System.Windows.Forms.NumericUpDown productCountNUD;
    }
}