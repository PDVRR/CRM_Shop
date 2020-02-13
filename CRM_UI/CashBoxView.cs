using System;
using System.Windows.Forms;
using CRM_BL.Model;

namespace CRM_UI
{
    public class CashBoxView
    {
        CashRegister cashRegister;

        public Label CashRegisterName { get; set; } = new Label();
        public NumericUpDown Price { get; set; } = new NumericUpDown();
        public ProgressBar QueueLength { get; set; } = new ProgressBar();
        public Label LeaveCustomersCount { get; set; } = new Label();

        public CashBoxView(CashRegister cashRegister, int number, int x, int y)
        {
            this.cashRegister = cashRegister;

            CashRegisterName.AutoSize = true;
            CashRegisterName.Location = new System.Drawing.Point(x, y);
            CashRegisterName.Name = "label" + number;
            CashRegisterName.Size = new System.Drawing.Size(35, 13);
            CashRegisterName.TabIndex = number;
            CashRegisterName.Text = cashRegister.ToString();

            Price.Location = new System.Drawing.Point(x + 70, y);
            Price.Name = "numericUpDown" + number;
            Price.Size = new System.Drawing.Size(120, 20);
            Price.TabIndex = number;
            Price.Maximum = 1000000000000000;

            QueueLength.Location = new System.Drawing.Point(x + 250, y);
            QueueLength.Maximum = cashRegister.MaxQueueLength;
            QueueLength.Name = "progressBar" + number;
            QueueLength.Size = new System.Drawing.Size(100, 23);
            QueueLength.TabIndex = number;
            QueueLength.Value = 0;
            QueueLength.Minimum = 0;
            QueueLength.Maximum = 1000;

            LeaveCustomersCount.AutoSize = true;
            LeaveCustomersCount.Location = new System.Drawing.Point(x + 400, y);
            LeaveCustomersCount.Name = "label2" + number;
            LeaveCustomersCount.Size = new System.Drawing.Size(35, 13);
            LeaveCustomersCount.TabIndex = number;
            LeaveCustomersCount.Text = "";

            cashRegister.CheckClosed += CashRegister_CheckClosed;
        }

        private void CashRegister_CheckClosed(object sender, Check e)
        {
            Price.Invoke((Action) delegate
            {
                Price.Value += e.Price;
                QueueLength.Value = cashRegister.Count;
                LeaveCustomersCount.Text = cashRegister.GoneCustomer.ToString();
            });
        }
    }
}