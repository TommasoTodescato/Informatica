using System;
using System.Linq;
using System.Windows.Forms;

namespace Tombola
{
    public partial class Form1 : Form
    {
        private CCartella Cart;

        public Form1()
        {
            Cart = new CCartella();

            InitializeComponent();

        }
        // coordinates initialization
        private void Form1_Load(object sender, EventArgs e)
        {
            int x = 0, y = 0;

            // in the future we should filter by button type (casella)
            foreach (var button in Controls.OfType<Button>().Reverse())
            {
                button.Tag = (x, y);

                if (Cart.Cartella[x, y].Number != -1)
                    button.Text = Cart.Cartella[x, y].Number.ToString();
                else
                    button.Text = "";

                x++;
                if (x >= 9)
                {
                    y++;
                    x = 0;
                }
            }
        }


        // TODO: Make a tick on the button when Ticked is true
        private void Checked(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                (int, int) tmp = ((int, int))btn.Tag;
                Cart.Cartella[tmp.Item1, tmp.Item2].Ticked ^= true;

                if (Cart.Cartella[tmp.Item1, tmp.Item2].Ticked && btn.Text != "")
                {
                    btn.BackColor = System.Drawing.Color.Firebrick;
                    btn.ForeColor = System.Drawing.Color.Snow;

                    int temp = WinCheck(Cart);          //massimo di celle ticked per riga
                    if (temp > Cart.MaxWin && temp > 1)
                    {
                        Cart.MaxWin = temp;
                        var PopUp = new Popup();
                        PopUp.label3.Text = PopUp.WinTexts[Cart.MaxWin];
                        PopUp.ShowDialog();
                    }
                }
                else
                {
                    btn.BackColor = System.Drawing.Color.Moccasin;
                    btn.ForeColor = System.Drawing.Color.DarkRed;
                }
            }
        }

        private void Display_Wins_Click(object sender, EventArgs e)
        {

        }

        private int WinCheck(CCartella cart)
        {
            int temp = 0;
            int max = 0;
            int fullRows = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (cart.Cartella[j, i].Ticked)
                        temp++;
                }
                if (temp > max)
                    max = temp;
                if (temp == 5)
                    fullRows++;
                temp = 0;
            }
            if (fullRows == 3)
                if (Cart.MaxWin == 6)   //tombolino, da rivedere per il multiplayer
                    max = 7;
                else                    //tombola
                    max = 6;
            fullRows = 0;
            return max;
        }
    }
}
