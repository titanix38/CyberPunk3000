using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Resources;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cyber.UnitTest
{
    [TestClass]
    public class TestGaming
    {
        [TestMethod]
        public void TestAction()
        {
            //MainWindow main = new MainWindow();
            //Assert.IsNotNull(main);
        }



        [TestMethod]
        public void TestDice10Launch()
        {
            // TODO : Faire le test pour le dé de 10

        }

        [TestMethod]
        public void TestTempNearZero()
        {
            int[] ts = new[] { 15, -7, 9, 14, 7, 12 };

            int result = ComputeClosestToZero(ts);
        }

        private int ComputeClosestToZero(int[] ts)
        {
            if (ts == null || ts.Length == 0) return 0;
            Array.Sort(ts);

            int tneg = -0;
            int tpos = 0;

            int nbNeg = 0;
            int nbPos = 0;

            if (ts.Length > 10000) Array.Copy(ts, new int[10000], 10000);


            for (int i = 0; i < ts.Length; i++)
            {
                if (ts[i] < 0)
                {
                    tneg = (int)Math.Abs((decimal)ts[i]);
                    nbNeg++;
                }
                else
                {
                    tpos = ts[i];
                    nbPos++;
                    break;
                }

            }

            if (tneg == tpos) return tpos;

            if (nbNeg == 0) return tpos;
            else if (nbPos == 0) return -tneg;
            else if (tneg < tpos) return -tneg;
            else return tpos;

        }


        [TestMethod]
        public void TestFoundNumber()
        {
            bool res1 = Exists(new[] { -9, 14, 37, 102 }, 102);
            bool res2 = Exists(new[] { -9, 14, 37, 102 }, 36);
        }


        [TestMethod]
        public void TestWeight()
        {
            int w1 = 100;
            int w2 = 140;
            int w3 = 90;

            int res = Solve(w1, w2, w3);

        }


        private static int Solve(int weight0, int weight1, int weight2)
        {
            // Write your code here
            // To debug: Console.Error.WriteLine("Debug messages...");
            int[] wghts = { weight0, weight1, weight2 };

            int maxValue = wghts.Max();
            int maxIndex = wghts.ToList().IndexOf(maxValue);
            return maxIndex;
            // return -1;
        }


        [TestMethod]

        public void Method()
        {
            //int[] numbers = new int[]{1,2,3,4,5,6};
            //int[] threeNumbers = numbers[4..^1];

        }

        [TestMethod]
        public void TestEnd()
        {
            //bool result = Exists(new[] {-9, 14, 37, 102}, 36);
            bool result = Check("([)])");


            return;
        }


        private bool Check(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return true;
            }

            int nbPar = 0;

            int nbCro = 0;

            char[] chars = str.ToCharArray();

            foreach (var ch in chars)
            {
                switch (ch)
                {
                    case '(':
                        nbPar++;
                        break;
                    case ')':
                        if (nbPar == 0)
                        {
                            return false;
                        }
                        else
                        {
                            nbPar--;
                        }
                        break;
                    case '[':
                        nbCro++;
                        break;

                    case ']':
                        if (nbCro == 0)
                        {
                            return false;
                        }
                        else
                        {
                            nbCro--;
                        }

                        break;
                }
            }




            if (nbCro == 0 && nbPar == 0) return true;


            return false;

        }


        private bool Exists(int[] ints, int k)
        {
            int a = 0;
            int b = ints.Length - 1;
            while (a <= b)
            {
                int m = (a + b) / 2;


                if (ints[m] == k)
                {
                    return true;
                }
                else if (ints[m] < k)
                    a = m + 1;
                else b = m - 1;
            }

            return false;
        }


        [TestMethod]
        public void TestColis()
        {
            string[] strs = new string[]
            {
                "Ab","bcZ"
            };
            //ComputeCheckDigit(strs);

        }
        [TestMethod]
        public void TestSerialXML()
        {
            string strs = string.Empty;
            RemoveClusters(strs);

        }

        private void RemoveClusters(string sww)
        {
            //XmlSerializer xmlSerializer = new XmlSerializer(typeof(LOT));

            string xmlStr = string.Empty;
            //using (var sww = new StringWriter())
            //{
            XmlWriter writer = XmlWriter.Create(sww);
            //xmlSerializer.Serialize(writer, xmllot);

            xmlStr = sww.ToString();
            //XDocument doc = XDocument.Parse(xmlStr);
            XElement root = XElement.Parse(xmlStr);
            root.Element("PLIS")
                .Element("DOCUMENT")
                .Element("FEUILLE")
                .Element("PAGE")
                .Elements("CLUSTERS").ToList().Remove();


            //}
        }



        private static string ComputeCheckDigit(string identificationNumber)
        {
            // Write your code here
            // To debug: Console.Error.WriteLine("Debug messages...");
            char[] parts = identificationNumber.ToCharArray();

            List<int> pair = new List<int>();
            List<int> impair = new List<int>(); ;


            for (int i = 0; i < parts.Length; i++)
            {
                if (i % 2 == 0) pair.Add(int.Parse(parts[i].ToString())); else impair.Add(int.Parse(parts[i].ToString()));

            }
            int somme = pair.Sum(item => item);



            throw new Exception();



        }
        [TestMethod]
        public void TestDataCenter()
        {
            string dir = "U";

            int[] resInts = Solve("U", 0, 0, 1000, 1000);
        }


        private static int[] Solve(string direction, int x, int y, int width, int height)
        {
            // Write your code here
            // To debug: Console.Error.WriteLine("Debug messages...");
            int[] coord = new int[width];
            int x1;
            int y1;
            switch (direction)
            {
                case "U":
                    if (y > 1) coord[x] = y - 1; else coord[x] = y;
                    break;

                case "UR":


                    if (x < width)
                    {
                        x1 = x + 1;
                    }
                    else { x1 = 0; }
                    if (y > 0) { y1 = y - 1; }
                    else { y1 = 0; }
                    coord[x1] = y1;

                    break;

                case "R":
                    if (x < width) x1 = x + 1;
                    else x1 = width;

                    coord[x1] = y;

                    break;

                case "DR":

                    if (x < width) { x1 = x + 1; } else { x1 = width; }
                    if (y < height) { y1 = y + 1; } else { y1 = height; }

                    coord[x1] = y1;


                    break;

                case "D":
                    if (y < height) { y1 = y + 1; } else { y1 = height; }
                    coord[x] = y1;
                    break;

                case "DL":
                    if (x > 0) { x1 = x - 1; } else { x1 = width; }
                    if (y < height) { y1 = y + 1; } else { y1 = height; }


                    coord[x1] = y1;

                    break;

                case "L":
                    if (x > 0) { x1 = x - 1; } else { x1 = width; }
                    coord[x1] = y;

                    break;

                case "UL":

                    if (y > 1) y1 = y - 1; else y1 = y;
                    if (x > 0) { x1 = x - 1; } else { x1 = width; }

                    coord[x1] = y1;

                    break;



            }


            return null;
        }


        [TestMethod]
        public void TestDuoDigit()
        {
            //string strs = Is(2020);
            int num = -79;
            Assert.AreEqual(false, string.IsNullOrEmpty(IsDuoDigit(num)));
        }


        public int Count(int n)
        {
            return (n * (n - 1) / 2);

        }

        private string IsDuoDigit(int number)
        {

            number = Math.Abs(number);
            char[] num = number.ToString().ToCharArray();


            //Array.Sort(num);




            char[] outChar = num.Distinct().ToArray();
            if (outChar.Length <= 2)
            {
                return "duodigit";
            }

            return "";
        }

        private string Tansport(int length, int height, int width, int mass)
        {
            int volume = length * height * width;

            int outStandard = 1000000;
            if (volume > outStandard || mass > 20)
            {
                return "NON STANDARD";
            }
            else if (volume <= outStandard && mass <= 20 && (length > 150 || height > 150 || width > 150))
            {
                return "SPECIAL";
            }
            else
            {
                return "STANDARD";
            }



        }


        [TestMethod]
        public void TestClassEqualL()
        {
            Foo T = new Foo();

            Foo U = T;

            T.Test = 1;
            U.Test = 2;

            Console.WriteLine("T.Test = " + T.Test);

        }

    }


    internal class Foo
    {
        private int _test;


        public int Test
        {
            get => _test;
            set => _test = value;
        }
    }
}
