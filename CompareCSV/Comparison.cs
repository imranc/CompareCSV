using System;
using System.IO;
using System.Collections.Generic;


namespace CompareCSV
{
    public class Comparison
    {
        static List<string> csvToArray(string fileName)
        {
                List<string> listA = new List<string>();
                using (StreamReader sr = new StreamReader(fileName))
                {
                    while (!sr.EndOfStream)
                    {
                        String line = sr.ReadLine();
                        listA.Add(line);
                    }
                }
                return listA;
        }

        public static void diffOfCsv(string csvA, string csvB)
        {
            var lineCountInA = File.ReadAllLines(csvA).Length;
            var lineCountInB = File.ReadAllLines(csvB).Length;

                using(StreamReader srA = new StreamReader(csvA))
                using(StreamReader srB = new StreamReader(csvB)){
                    if (lineCountInA > lineCountInB)
                    {
                        while(!srA.EndOfStream)
                        {
                            string lineA = srA.ReadLine();
                            string lineB = "";
                            if (!srB.EndOfStream)
                            {
                                lineB = srB.ReadLine();
                            }
                            
                            if (!lineA.Equals(lineB))
                            {
                                Console.WriteLine("< {0}", lineA);
                                Console.WriteLine("---");
                                Console.WriteLine("> {0}", lineB);
                            }
                        }
                    }
                    else
                    {
                        while(!srB.EndOfStream)
                        {
                            string lineB = srB.ReadLine();
                            string lineA = "";
                            if (!srA.EndOfStream)
                            {
                                lineA = srA.ReadLine();
                            }
                            if (!lineB.Equals(lineA))
                            {
                                Console.WriteLine("< {0}", lineA);
                                Console.WriteLine("---");
                                Console.WriteLine("> {0}", lineB);
                            }
                        }
                    }
                }
        }
        static void Main(string[] args)
        {
            diffOfCsv(args[0], args[1]);
        }
    }
}
