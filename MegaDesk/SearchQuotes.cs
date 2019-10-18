using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using static MegaDesk.Desk;

namespace MegaDesk
{
    public partial class SearchQuotes : Form
    {
        MainMenu searchQuotesToMenu;
        DisplayQuote displayQuote;
        DesktopMaterial newMaterial;
        List<DeskQuote> list;
        DeskQuote quoteToShow = new DeskQuote();
        List<DeskQuote> displayList = new List<DeskQuote>();
        HashSet<String> searchNames = new HashSet<String>();
        List<String> displayNames = new List<String>();
        String nameSelection = "";
        public SearchQuotes()
        {
            InitializeComponent();

            List<DesktopMaterial> materials = Enum.GetValues(typeof(DesktopMaterial)).Cast<DesktopMaterial>().ToList();

            materialComboBox.DataSource = materials;
            materialComboBox.DropDownStyle = ComboBoxStyle.DropDown;

            //Try to load deskquotes into list, otherwise give error message after form is loaded
            try
            {
                list = getDeskQuotes();
 
                for (int i = 0; i < list.Count; i++)
                {
                    searchNames.Add(list[i].FirstName);
                }
                foreach(String name in searchNames)
                {
                    displayNames.Add(name);
                }
                
                nameComboBox.DropDownStyle = ComboBoxStyle.DropDown;
                nameComboBox.DataSource = displayNames;

                displaySearchQuoteButton.Enabled = false;

                /* logic for name selection to grid */

                nameSelection = nameComboBox.Text;
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].FirstName == nameSelection)
                    {
/*                        quoteToShow = ;*/
                        displayList.Add(list[i]);
                    }
                }

                searchGrid.DataSource = displayList;

            }
            catch(Exception exc)
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

        private void searchGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRow = e.RowIndex;
            
            // Get the selected row and material type
            quoteToShow = list[selectedRow];
            newMaterial = (DesktopMaterial)materialComboBox.SelectedItem;

            // Add the price difference between the two selections to the total
            int priceDiff = quoteToShow.changeMaterialCost(quoteToShow, newMaterial.ToString());
            quoteToShow.TotalCost += priceDiff;
            quoteToShow.Desk.MaterialType = newMaterial;

            displaySearchQuoteButton.Enabled = true;
        }

        private void displaySearchQuoteButton_Click(object sender, EventArgs e)
        {
            if (displayQuote == null)
            {
                displayQuote = new DisplayQuote(quoteToShow);
            }

            Hide();
            displayQuote.Show();
        }

        private void changeNameButton_Click(object sender, EventArgs e)
        {
            nameSelection = nameComboBox.Text;
            displayList.Clear();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].FirstName == nameSelection)
                {
                    quoteToShow = list[i];
                    displayList.Add(quoteToShow);
                }
            }
            searchGrid.DataSource = null;
            searchGrid.DataSource = displayList;
            searchGrid.Refresh();
        }
    }
}