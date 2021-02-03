using System;
using System.Collections.Generic;

namespace myDNAcodingTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var pipettingRobot = new PipettingRobot();

            // Act
            pipettingRobot.Place(5, 2);
            pipettingRobot.Move("S");
            var report = pipettingRobot.Report();
            foreach (var r in report)
            {
                Console.WriteLine(r);
            }
        }
    }

    public class PipettingRobot
    {
        public static Dictionary<string, string> Wells = new Dictionary<string, string>
        {
            ["11"] = "EMPTY",
            ["12"] = "FULL",
            ["13"] = "EMPTY",
            ["14"] = "EMPTY",
            ["15"] = "FULL",
            ["21"] = "EMPTY",
            ["22"] = "EMPTY",
            ["23"] = "EMPTY",
            ["24"] = "EMPTY",
            ["25"] = "EMPTY",
            ["31"] = "FULL",
            ["32"] = "EMPTY",
            ["33"] = "EMPTY",
            ["34"] = "EMPTY",
            ["35"] = "EMPTY",
            ["41"] = "EMPTY",
            ["42"] = "EMPTY",
            ["43"] = "FULL",
            ["44"] = "EMPTY",
            ["45"] = "EMPTY",
            ["51"] = "EMPTY",
            ["52"] = "EMPTY",
            ["53"] = "EMPTY",
            ["54"] = "EMPTY",
            ["55"] = "EMPTY"
        };



        private int[] location = new int[2];

        public int[] Place(int x, int y)
        {
            if (x <= 0 || x > 5 || y <= 0 || y > 5)
            {
                throw new ArgumentOutOfRangeException();
            }
            location[0] = x;
            location[1] = y;
            return location;
        }

        public string Detect()
        {
            if (location[0] <= 0 || location[0] > 5 || location[1] <= 0 || location[1] > 5)
            {
                throw new ArgumentOutOfRangeException();
            }
            var key = String.Join("", location);
            return Wells[key];
        }

        public void Drop()
        {
            if (Detect() == "EMPTY")
            {
                var key = location.ToString();
                Wells[key] = "FULL";
            }
        }

        public int[] Move(string dir)
        {
            switch (dir)
            {
                case "N":
                    location[0]++;
                    if (location[0] > 5) throw new ArgumentOutOfRangeException();
                    break;
                case "S":
                    location[0]--;
                    if (location[0] < 1) throw new ArgumentOutOfRangeException();
                    break;
                case "E":
                    location[1]++;
                    if (location[1] > 5) throw new ArgumentOutOfRangeException();
                    break;
                case "W":
                    location[1]--;
                    if (location[0] < 1) throw new ArgumentOutOfRangeException();
                    break;
            }

            return location;
        }

        public string[] Report()
        {
            return new string[3] { location[0].ToString(), location[1].ToString(), Detect() };
        }
    }
}
