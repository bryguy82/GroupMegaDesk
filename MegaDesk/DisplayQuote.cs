using System;
using System.Windows.Forms;

namespace MegaDesk
{
    public partial class DisplayQuote : Form
    {
        MainMenu showQuotesToMenu;
        DeskQuote deskQuote;

        public DisplayQuote(DeskQuote fromDeskQuote)
        {
            InitializeComponent();
            deskQuote = fromDeskQuote;
            Desk desk = deskQuote.Desk;

            theDate.Text = deskQuote.PurchaseDate;
            theCustomer.Text = $"{deskQuote.FirstName} {deskQuote.LastName}";
            theMaterial.Text = $"{desk.MaterialType.ToString()}  (${(int)desk.MaterialType})";

            theDate.Text = String.Format("{0,10:dd-MMM-yy}", deskQuote.PurchaseDate);
            theWidth.Text = String.Format("{0,0:0} in", desk.Width);
            theDepth.Text = String.Format("{0,0:0} in", desk.Depth);
            theArea.Text = String.Format("{0,0:0} in\xB2 ({1,0:$0.00})", desk.getArea(), desk.getArea() * 1);
            theDrawers.Text = String.Format("{0,0:0} ({1,0:$0.00})", desk.DrawerNum.ToString(), desk.DrawerNum * 50);
            theRush.Text = String.Format("{0,0:$0.00}", deskQuote.RushCost);
            theTotal.Text = String.Format("{0,0:$0.00}", deskQuote.TotalCost);
            theBaseCost.Text = String.Format("{0,0:$0.00}", DeskQuote.BASECOST);
            
        }

        private void mainMenu_Click(object sender, EventArgs e)
        {
            if (showQuotesToMenu == null)
            {
                showQuotesToMenu = new MainMenu();
            }
            Hide();
            showQuotesToMenu.Show();
        }

        private void SaveQuote_Click(object sender, EventArgs e)
        {
            try
            {
                deskQuote.storeQuote();
                MessageBox.Show("Quote Saved!", "Notice");
                mainMenu.PerformClick();
            }
            catch
            {
                MessageBox.Show("Something went wrong with saving the quote. Try again later.", "Error");
            }
        }

        private void DisplayQuote_Load(object sender, EventArgs e)
        {
            this.Show();
        }

        
    }
}
