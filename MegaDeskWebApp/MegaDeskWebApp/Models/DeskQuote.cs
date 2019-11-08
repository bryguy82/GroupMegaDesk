using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MegaDeskWebApp.Models
{
    public class DeskQuote
    {

        public int DeskQuoteID { get; set; }

        public Desk desk { get; set; }

        [Display(Name = "Purchase Date"), DataType(DataType.Date), Required]
        public DateTime purchaseDate { get; set; }

        [Display(Name = "First Name"), StringLength(60, MinimumLength = 3), Required]
        public String firstName { get; set; }

        [Display(Name = "Last Name"), StringLength(60, MinimumLength = 3), Required]
        public String lastName { get; set; }

        [DataType(DataType.Currency)]
        public int sizeCost { get; set; }

        [DataType(DataType.Currency)]
        public int drawerCost { get; set; }

        [DataType(DataType.Currency)]
        public int materialCost { get; set; }

        [DataType(DataType.Currency)]
        public int rushCost { get; set; }

        [DataType(DataType.Currency)]
        public int totalCost { get; set; }

        [DataType(DataType.Currency)]
        public const int BASECOST = 200;


        private Dictionary<int, int> rushSmallDict = new Dictionary<int, int>();
        private Dictionary<int, int> rushMedDict = new Dictionary<int, int>();
        private Dictionary<int, int> rushLargeDict = new Dictionary<int, int>();
        private int[] rushDays = new int[] { 3, 5, 7 };
        private int[] rushPrices = new int[] { 60, 70, 80, 40, 50, 60, 30, 35, 40 };
/*        private String[] rushPrices = new String[9];*/
        private List<string> errorMessages = new List<string>();


        public DeskQuote()
        {

        }

        public int calcCost(int area, int drawers, String material)
        {

            materialCost = calcMaterialCost(material);
            drawerCost = drawers * 50;

            sizeCost = area * 1;

            return BASECOST + sizeCost + drawerCost + materialCost;
        }

        public int calcMaterialCost(String material)
        {
            switch (material)
            {
                case ("Laminate"):
                    materialCost = 100;
                    break;
                case ("Oak"):
                    materialCost = 200;
                    break;
                case ("Pine"):
                    materialCost = 50;
                    break;
                case ("Rosewood"):
                    materialCost = 300;
                    break;
                default:
                    materialCost = 125;
                    break;
            }
            return materialCost;
        }

        public void rushTextFile()
        {
            /**
             * Read the text file into a string array
             * Convert them to int while adding to dictionaries
             * 
             * File has rush costs going from the most expensive
             * to the least expensive by rush date.
             * EX: 3 day small desk, 3 day med desk, 3 day large desk,
             *     5 day small desk, 5 day med desk, 5 day large desk,
             *     7 day small desk, 7 day med desk, 7 day large desk
             */
/*            string fileName = "../Resources/rushOrderPrices.txt";*/
            try
            {
/*                if (File.Exists(fileName))
                {
                    rushPrices = File.ReadAllLines(fileName);
                }*/
                for (int i = 0; i < rushPrices.Length; i++)
                {
/*                    rushCost = int.Parse(rushPrices[i]);*/
                    switch (i)
                    {
                        case 0:
                        case 3:
                        case 6:
                            if (i == 0)
                            {
                                rushSmallDict.Add(rushDays[0], rushPrices[i]);
                            }
                            else if (i == 3)
                            {
                                rushSmallDict.Add(rushDays[1], rushPrices[i]);
                            }
                            else
                            {
                                rushSmallDict.Add(rushDays[2], rushPrices[i]);
                            }
                            break;
                        case 1:
                        case 4:
                        case 7:
                            if (i == 1)
                            {
                                rushMedDict.Add(rushDays[0], rushPrices[i]);
                            }
                            else if (i == 4)
                            {
                                rushMedDict.Add(rushDays[1], rushPrices[i]);
                            }
                            else
                            {
                                rushMedDict.Add(rushDays[2], rushPrices[i]);
                            }
                            break;
                        case 2:
                        case 5:
                        case 8:
                            if (i == 2)
                            {
                                rushLargeDict.Add(rushDays[0], rushPrices[i]);
                            }
                            else if (i == 5)
                            {
                                rushLargeDict.Add(rushDays[1], rushPrices[i]);
                            }
                            else
                            {
                                rushLargeDict.Add(rushDays[2], rushPrices[i]);
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (FileNotFoundException exc)
            {
                errorMessages.Add(exc.Message);
            }
            catch (FormatException exc)
            {
                errorMessages.Add(exc.Message);
            }
        }

        public int calcRush(int deskSize, int days)
        {
            // Get the prices from a file.
            rushTextFile();
            
            // Set up the cost based on the size of the desktop
            if (deskSize <= 1000)
            {
                rushCost = rushSmallDict[days];
            }
            else if (deskSize > 1000 && deskSize <= 2000)
            {
                rushCost = rushMedDict[days];
            }
            else
            {
                rushCost = rushLargeDict[days];
            }
            return rushCost;
        }

        public void storeQuote()
        {
            //Create new streamreader, have it read all objects in quotes.json
            string jsonString = "";
            jsonString += File.ReadAllText("../../Resources/quotes.json");
            Console.WriteLine(jsonString);
            //Set up list of DeskQuote objects and deserialize json file

            List<DeskQuote> list;
            list = JsonConvert.DeserializeObject<List<DeskQuote>>(jsonString);
            if (list == null)
            {
                list = new List<DeskQuote>();
            }
            //add new deskQuote to the list, and write it to the json file
            list.Add(this);
            var convertedJson = JsonConvert.SerializeObject(list, Formatting.Indented);
            StreamWriter writer = new StreamWriter("../../Resources/quotes.json");
            writer.WriteLine(convertedJson);
            writer.Close();

        }
        public int changeMaterialCost(DeskQuote quote, String materialNew)
        {
            string oldMaterial = quote.materialCost.ToString();
            int costSub = calcMaterialCost(oldMaterial);
            int costAdd = calcMaterialCost(materialNew);
            return costSub - costAdd;
        }
    }
}
