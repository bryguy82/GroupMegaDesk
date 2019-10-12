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
    public partial class SearchQuotes : Form
    {
        MainMenu searchQuotesToMenu;
        List<DeskQuote> list;
        public SearchQuotes()
        {
            InitializeComponent();

            //Try to load deskquotes into list, otherwise give error message after form is loaded
            try
            {
                list = getDeskQuotes();
                //Test quotes
                //MessageBox.Show(list.ToString(), "Test");
            }
            catch
            {
                list = new List<DeskQuote>();
                this.Shown += new EventHandler(SearchQuotes_Shown);
            }
        }

        void SearchQuotes_Shown(object sender, EventArgs e)
        {
            //Display Error and return to main menu
            MessageBox.Show("Something went wrong. Please try again later.", "Error loading quotes");
            searchMainMenu.PerformClick();
        }

        private void mainMenu_Click(object sender, EventArgs e)
        {
            if (searchQuotesToMenu == null)
            {
                searchQuotesToMenu = new MainMenu();
            }
            Hide();
            searchQuotesToMenu.Show();
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
    }
}
