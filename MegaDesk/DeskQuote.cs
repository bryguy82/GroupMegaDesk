using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using Newtonsoft.Json;

namespace MegaDesk
{

    class DeskQuote
    {
        public const int BASECOST = 200;
        private static String firstName;
        private static String lastName;
        private static int totalCost;
        private static int sizeCost;
        private static int drawerCost;
        private static int materialCost;
        private static int rushCost;
        private Dictionary<int, int> rushSmallDict = new Dictionary<int, int>();
        private Dictionary<int, int> rushMedDict = new Dictionary<int, int>();
        private Dictionary<int, int> rushLargeDict = new Dictionary<int, int>();
        private static int[] rushDays = new int[] { 3, 5, 7 };
        private static Desk desk;
        private static String purchaseDate;
        private static String[] rushPrices;
        private static List<string> errorMessages = new List<string>();

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public int TotalCost { get => totalCost; set => totalCost = value; }
        public int RushCost { get => rushCost; set => rushCost = value; }
        internal Desk Desk { get => desk; set => desk = value; }
        public string PurchaseDate { get => purchaseDate; set => purchaseDate = value; }

        public DeskQuote()
        {

        }

        public int buildDesk(int width, int depth)
        {
            desk = new Desk();
            desk.Width = width;
            desk.Depth = depth;
            return width * depth;
        }

        public int calcCost(int area, int drawers, String material)
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
            drawerCost = drawers * 50;

            if (area > 1000)
            {
                sizeCost = area - 1000;
            }

            return area + BASECOST + sizeCost + drawerCost + materialCost;
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
            string fileName = "../../Resources/rushOrderPrices.txt";
            try
            {
                if (File.Exists(fileName))
                {
                    rushPrices = File.ReadAllLines(fileName);
                }
                for (int i = 0; i < rushPrices.Length; i++)
                {
                    int rushCost = int.Parse(rushPrices[i]);
                    switch (i)
                    {
                        case 0:
                        case 3:
                        case 6:
                            if (i == 0)
                            {
                                rushSmallDict.Add(rushDays[0], rushCost);
                            }
                            else if (i == 3)
                            {
                                rushSmallDict.Add(rushDays[1], rushCost);
                            }
                            else
                            {
                                rushSmallDict.Add(rushDays[2], rushCost);
                            }
                            break;
                        case 1:
                        case 4:
                        case 7:
                            if (i == 1)
                            {
                                rushMedDict.Add(rushDays[0], rushCost);
                            }
                            else if (i == 4)
                            {
                                rushMedDict.Add(rushDays[1], rushCost);
                            }
                            else
                            {
                                rushMedDict.Add(rushDays[2], rushCost);
                            }
                            break;
                        case 2:
                        case 5:
                        case 8:
                            if (i == 2)
                            {
                                rushLargeDict.Add(rushDays[0], rushCost);
                            }
                            else if (i == 5)
                            {
                                rushLargeDict.Add(rushDays[1], rushCost);
                            }
                            else
                            {
                                rushLargeDict.Add(rushDays[2], rushCost);
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

        public void saveQuote()
        {
            DeskQuote customerQuote = new DeskQuote();
            customerQuote.Desk = desk;
        }

        public void storeQuote()
        {
            //Create new streamreader, have it read all objects in quotes.json
            StreamReader reader = new StreamReader("../../Resources/quotes.json");
            string jsonString = "";
            while (reader.EndOfStream == false)
            {
                jsonString += reader.ReadLine();
            }
            reader.Close();

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
    }
}
