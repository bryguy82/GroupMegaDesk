using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

namespace MegaDesk
{
    public partial class ViewAllQuotes : Form
    {
        MainMenu allQuotesToMenu;
        DisplayQuote displayQuote;
        DeskQuote quoteToShow;
        List<DeskQuote> list;
        public ViewAllQuotes()
        {
            InitializeComponent();

            //Try to load deskquotes into list, otherwise give error message after form is loaded
            try
            {
                list = getDeskQuotes();

                quotesGrid.DataSource = list;

                displayQuoteButton.Enabled = false;

            }
            catch
            {
                list = new List<DeskQuote>();
                this.Shown += new EventHandler(ViewAllQuotes_Shown);
            }
        }

        void ViewAllQuotes_Shown(object sender, EventArgs e)
        {
            //Display Error and return to main menu
            MessageBox.Show("Something went wrong. Please try again later.", "Error loading quotes");
            viewAllMainMenu.PerformClick();
        }

        private void mainMenu_Click(object sender, EventArgs e)
        {
            if (allQuotesToMenu == null)
            {
                allQuotesToMenu = new MainMenu();
            }
            Hide();
            allQuotesToMenu.Show();
        }

        private List<DeskQuote> getDeskQuotes()
        {

            //Create new streamreader, have it read all objects in quotes.json
            StreamReader reader = new StreamReader("../../Resources/quotes.json");
            string jsonString = "";
            while (reader.EndOfStream == false)
            {
                jsonString += reader.ReadLine();
            }
            reader.Close();

            //Set up list of DeskQuote objects and deserialize json file, return list
            //If no quotes exist, return empty list

            List<DeskQuote> returnList;
            returnList = JsonConvert.DeserializeObject<List<DeskQuote>>(jsonString);
            if (returnList == null)
            {
                returnList = new List<DeskQuote>();
            }
            return returnList;
        }

        private void quotesGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /**
              * Where the selected quote matches, use the selection in
              * the "quoteToShow" to get the entire object from "list"
              * before displaying it on DisplayQuote
              */
            int selectedRow = e.RowIndex;
            quoteToShow = list[selectedRow];
            displayQuoteButton.Enabled = true;
        }

        private void displayQuoteButton_Click(object sender, EventArgs e)
        {
            if (displayQuote == null)
            {
                displayQuote = new DisplayQuote(quoteToShow);
            }
            
            Hide();
            displayQuote.Show();
        }
    }
}