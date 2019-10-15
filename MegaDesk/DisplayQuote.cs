using System;
using System.Windows.Forms;

namespace MegaDesk
{
    public partial class DisplayQuote : Form
    {
        MainMenu showQuotesToMenu;
        DeskQuote deskQuote;

        public DisplayQuote()
        {
            InitializeComponent();
            deskQuote = new DeskQuote();
            Desk desk = deskQuote.Desk;

            theDate.Text = deskQuote.PurchaseDate;
            theCustomer.Text = $"{deskQuote.FirstName} {deskQuote.LastName}";
            theWidth.Text = desk.Width.ToString();
            theDepth.Text = desk.Depth.ToString();
            theArea.Text = (desk.Width * desk.Depth).ToString();
            theDrawers.Text = desk.DrawerNum.ToString();
            theMaterial.Text = desk.MaterialType.ToString();
            theRush.Text = deskQuote.RushCost.ToString();
            theTotal.Text = deskQuote.TotalCost.ToString();

            theDate.Text = String.Format("{0,10:dd-MMM-yy}", deskQuote.PurchaseDate);
            theWidth.Text = String.Format("{0,10:0}", desk.Width);
            theDepth.Text = String.Format("{0,10:0}", desk.Depth);
            theArea.Text = String.Format("{0,10:0}", desk.Width * desk.Depth);
            theDrawers.Text = String.Format("{0,10:0}", desk.DrawerNum);
            theRush.Text = String.Format("{0,10:$0.00}", deskQuote.RushCost);
            theTotal.Text = String.Format("{0,10:$0.00}", deskQuote.TotalCost);


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
