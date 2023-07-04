using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTimesReporter
{
    class Sale
    {
        public string hour { get; set; }
        public string country { get; set; }
        public string referral { get; set; }
        public string count { get; set; }
        public DateTime date { get; set; }
        public string notes { get; set; }
    }

    enum country
    {
        USA,
        UK,
        Australia,
        Canada,
        NZ
    }

    class Program
    {        
        public static string ParseCountry(string textLine)
        {
            int commaStart = textLine.IndexOf(",");
            int commaEnd = textLine.IndexOf(",", commaStart+1);
            string country = textLine.Substring(commaStart+1, commaEnd-commaStart-1);
            return country;
        }

        public static string ParseReferral(string textLine)
        {
            int commaStart = textLine.IndexOf(",", 22);
            int commaEnd = textLine.IndexOf(",", commaStart + 1);
            string referral = textLine.Substring(commaStart + 1, commaEnd - commaStart - 1);
            return referral;
        }

        public static string ParseSales(string textLine)
        {
            int commaStart = 21 + ParseCountry(textLine).Length + ParseReferral(textLine).Length;
            string sales = textLine.Substring(commaStart+1);
            return sales;
        }

        static void Main(string[] args)
        {
            //Grid that will store all the sales information per hour and day of the week.
            int[,] TimesDaysGrid = new int[24, 7];
            //All sales from file on memory as the Sales class
            List<Sale> salesList = new List<Sale>();

            for (int i = 0; i <= 23; i++)
            {
                for (int j = 0; j <= 6; j++)
                {
                    TimesDaysGrid[i, j] = 0;
                }
            }

            Console.Write("Filename?-> ");
            string fileName = Console.ReadLine();
            fileName = @"efsales.csv";
            /*
            Console.WriteLine("1- United States\r\n2- United Kingdom\r\n0- All");
            char whatCountry = Convert.ToChar(Console.Read());
            Console.WriteLine("1- Social\r\n2- Search Engine\r\n3- Direct\r\n0- All");
            Console.Write("Lower sales margin?> ");
            int lowerSalesMargin = Convert.ToInt16(Console.ReadLine());
            */

            Console.Write("Only Social referrals? (y/n)> ");
            bool onlySocial = Console.ReadLine().ToLower() == "y";

            //Reading sales file and first line, called saleItem.
            StreamReader objReader = new StreamReader(fileName);
            string saleItem = objReader.ReadLine();

            //Sale variables definition (which will be modelled as a class in the next version).
            string saleDate;
            string saleHour;
            string saleCountry;
            string saleReferral;
            string saleCount;

            DateTime dateValue, dateStart, dateFinish;
            int[] maxSales = new int[7];
            int lineCount = 0;

            //Used to calculate the number of weeks that were analized.
            dateStart = DateTime.Parse(saleItem.Substring(0, 10));
            dateFinish = DateTime.Parse(saleItem.Substring(0, 10));

            //Object that will store each sale parsed from the text file.
            Sale sale = new Sale();
            
            //Main loop to read all the lines on the sales text/csv file.
            while (saleItem != null)
            {
                //Parsing of the text file line into date, hour, country, sales, etc.
                saleDate = saleItem.Substring(0,10);
                dateValue = DateTime.Parse(saleDate);
                saleHour = saleItem.Substring(11, 2);                
                saleCountry = ParseCountry(saleItem);
                saleReferral = ParseReferral(saleItem);
                saleCount = ParseSales(saleItem);

                sale.date = DateTime.Parse(saleItem.Substring(0, 10));
                sale.hour = saleItem.Substring(11, 2);
                sale.country = ParseCountry(saleItem);
                sale.referral = ParseReferral(saleItem);
                sale.count = ParseSales(saleItem);

                //Storing of the sale into the hours and weedays grid to be displayed.
                if (onlySocial)
                {
                    if (saleReferral == "Social")
                    //if (saleCountry == "New Zealand")
                    {
                        TimesDaysGrid[Convert.ToInt16(saleHour), (int)dateValue.DayOfWeek] += Convert.ToInt16(saleCount);
                    }
                             
                }
                else
                {
                    TimesDaysGrid[Convert.ToInt16(saleHour), (int)dateValue.DayOfWeek] += Convert.ToInt16(saleCount);
                }
                
                //Monitor while the loop works.
                Console.Write("." + lineCount.ToString());

                // Read a new file line to be parsed
                saleItem = objReader.ReadLine();
                if (saleItem == null) dateFinish = DateTime.Parse(saleDate);
                lineCount++;                
            }

            //Write to file
            for (int i = 0; i < 24; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    File.AppendAllText(@"efsales.txt", TimesDaysGrid[i, j] + ",");
                }
                File.AppendAllText(@"efsales.txt", "\n");
            }
            

            // Calculate max for each day
            int[] maxSale = new int[] { 0, 0, 0, 0, 0, 0, 0 };
            for (int i = 0; i <=6; i++)
            {
                for (int j = 0; j <= 23; j++)
                {
                    if (TimesDaysGrid[Convert.ToInt16(j), Convert.ToInt16(i)] > maxSale[i])
                        maxSale[i] = TimesDaysGrid[Convert.ToInt16(j), Convert.ToInt16(i)];
                }
            }

            //Console.Write("Lower sales margin?> ");
            //lowerSalesMargin = Convert.ToInt16(Console.ReadLine());
            //int menuOption = Convert.ToInt16(Console.ReadKey(true));
            int lowerSalesMargin = -1;
            while (lowerSalesMargin != 0)
            {
                Console.Clear();
                Console.Write("Lower sales margin? (0 to exit)> ");
                lowerSalesMargin = Convert.ToInt16(Console.ReadLine());
                if (lowerSalesMargin == 0)
                {
                    break;
                }

                int weeks = (int)(dateFinish - dateStart).TotalDays / 7;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("  Number of weeks analized: ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(weeks);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("  Sales lower than the margin of ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(lowerSalesMargin);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" are shown as two dashes \"--\".");
                Console.WriteLine("------------------------------------------------------------------------");

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\t\tSun\tMon\tTue\tWed\tThu\tFri\tSat");

                for (int i = 0; i <= 23; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("\t" + i + ":00\t");
                    for (int j = 0; j <= 6; j++)
                    {
                        //Print the sales number only if it is higher than the chosen margin,
                        //otherwise it will print two dashes. This helps readability of the report.
                        if (TimesDaysGrid[i, j] >= lowerSalesMargin)
                        {
                            //If sale is a max print it in red.
                            if (maxSale[j] == TimesDaysGrid[i, j])
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                            }
                            //If sale is not a max print it in white.
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            Console.Write(TimesDaysGrid[i, j] + "\t");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write("--\t");
                        }
                    }
                    Console.WriteLine();
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("------------------------------------------------------------------------");
                Console.ReadLine();
            }//while menuOption       
        }
    }
}
