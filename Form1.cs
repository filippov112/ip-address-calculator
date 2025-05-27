using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ipcalc
{
    public partial class Ipcalc : Form
    {
        public Ipcalc()
        {
            InitializeComponent();
        }

        private void Calc_Click(object sender, EventArgs e)
        {
            List<NumericUpDown> IPaddr = new List<NumericUpDown> { IP1, IP2, IP3, IP4, IPM };
            List<TextBox> Naddr = new List<TextBox> { Net1, Net2, Net3, Net4 };
            List<TextBox> Waddr = new List<TextBox> { W1, W2, W3, W4 };
            List<TextBox> Mask = new List<TextBox> { Mask1, Mask2, Mask3, Mask4 };
            Hosts.Text = (Math.Pow(2, 32 - (int)IPM.Value) - 2).ToString();
            for (int i = 0; i < 4; i++)
            {
                Naddr[i].Text = "0";
                Waddr[i].Text = "0";
                Mask[i].Text = "0";
            }
            foreach (TextBox n in Naddr)
            {
                n.Text = "0";
            }
            for (int i = 0; i < IPaddr.Count - 1; i++)
            {
                int curr_oct = (int)IPaddr[i].Value;
                int width_addr = 0;
                for (int j = 1; j <= 8; j++)
                {
                    int bit = i * 8 + j;
                    int des = (int)Math.Pow(2, 8 - j);
                    if (bit <= IPM.Value)
                        Mask[i].Text = (int.Parse(Mask[i].Text) + des).ToString();
                    if (bit <= IPM.Value && curr_oct >= des)
                    {
                        curr_oct -= des;
                    }
                    if (bit > IPM.Value)
                    {
                        width_addr += des;
                    }
                }
                Naddr[i].Text = (IPaddr[i].Value - curr_oct).ToString();
                Waddr[i].Text = (int.Parse(Naddr[i].Text) + width_addr).ToString();
            }
        }
    }
}
