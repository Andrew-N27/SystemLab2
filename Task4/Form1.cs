using System;
using System.Windows.Forms;

namespace Task4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            LisViewProcc.myColumns();
            LisViewProcc.SetListProc();

            LisViewProcc.MouseClick += listView_Click;
        }

        private void btn_Click(object sender, EventArgs e)
        {
            if(((Button)sender).Name != "btnStart")
            {
                myProcess.Strat(((Button)sender).Text);
            }
            else
            {
                myProcess.Strat(tbNameProc.Text);
            }
        }

        private void btnStopProc_Click(object sender, EventArgs e)
        {
            myProcess.Kill(LisViewProcc.GetSelectedListId());
            btnStopProc.Enabled = false;
            UpdateListView();
        }

        private void listView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            LisViewProcc.ListViewItemSorter = new ListViewColumnComparer(e.Column);
        }

        private void listView_Click(object sender, EventArgs e)
        {
            btnStopProc.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateListView();
        }

        private void btnTimeUp_Click(object sender, EventArgs e)
        {
            timer1.Interval = Convert.ToInt32(tbUpDown.Text) * 1000;
        }

        private void btnUpdateListView_Click(object sender, EventArgs e)
        {
            UpdateListView();
        }

        private void UpdateListView()
        {
            LisViewProcc.RemoveListProc();
            LisViewProcc.SetListProc();
        }
    }
}
