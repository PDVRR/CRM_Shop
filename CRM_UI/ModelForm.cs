using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CRM_BL.Model;

namespace CRM_UI
{
    public partial class ModelForm : Form
    {
        private ShopComputerModel model = new ShopComputerModel();
        public ModelForm()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            var cashBoxes = new List<CashBoxView>();

            for (int i = 0; i < model.CashRegisters.Count; i++)
            {
                var box = new CashBoxView(model.CashRegisters[i], i, 10, 26 * i);
                cashBoxes.Add(box);
                Controls.Add(box.CashRegisterName);
                Controls.Add(box.Price);
                Controls.Add(box.QueueLength);
                Controls.Add(box.LeaveCustomersCount);
            }

            model.Start();
        }

        private void ModelForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            model.Stop();
        }

        private void ModelForm_Load(object sender, EventArgs e)
        {
            customerSpeedNUD.Value = model.CustomerSpeed;
            cashRegisterSpeedNUD.Value = model.CashRegisterSpeed;
        }

        private void customerSpeedNUD_ValueChanged(object sender, EventArgs e)
        {
            model.CustomerSpeed = (int)customerSpeedNUD.Value;
        }

        private void cashRegisterSpeedNUD_ValueChanged(object sender, EventArgs e)
        {
            model.CashRegisterSpeed = (int)cashRegisterSpeedNUD.Value;
        }
    }
}
