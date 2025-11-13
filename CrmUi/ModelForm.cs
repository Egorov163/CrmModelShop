using CrmBl.Model;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace CrmUi
{
    public partial class ModelForm : Form
    {
        ShopComputerModel model = new ShopComputerModel();

        public ModelForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var labels = new List<Label>();


            foreach (var cashDesk in model.CashDesks)
            {
                var cashBoxes = new List<CashBoxView>();

                for (int i = 0; i < model.CashDesks.Count; i++)
                {
                    var box = new CashBoxView(model.CashDesks[i], i, 10, 26 * i);
                    cashBoxes.Add(box);
                    Controls.Add(box.CashDeskName);
                    Controls.Add(box.Price);
                    Controls.Add(box.QueueLength);
                    Controls.Add(box.LeaveCustomersCount);
                }

                model.Start();
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void ModelForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            model.Stop();
        }

        private void ModelForm_Load(object sender, EventArgs e)
        {
            numericUpDown1.Value = model.CustomerSpeed;
            numericUpDown2.Value = model.CashDeskSpeed;
        }

        private void numericUpDown1_ValueChanged_1(object sender, EventArgs e)
        {
            model.CustomerSpeed = (int)numericUpDown1.Value;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            model.CashDeskSpeed = (int)numericUpDown2.Value;
        }

        private void ModelForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            model.Stop();
        }
    }
}
