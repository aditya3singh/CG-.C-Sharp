using System;
using System.Collections.Generic;

namespace DialingCodesApp
{
    public static class DialingCodes
    {
        public static Dictionary<int, string> GetEmptyDictionary()
        {
            return new Dictionary<int, string>();
        }

        public static Dictionary<int, string> GetExistingDictionary()
        {
            return new Dictionary<int, string>
            {
                { 1, "United States of America" },
                { 55, "Brazil" },
                { 91, "India" }
            };
        }
        public static Dictionary<int, string> AddCountryToEmptyDictionary(int countryCode, string countryName)
        {
            Dictionary<int, string> dic = new Dictionary<int, string>();
            dic.Add(countryCode, countryName);
            return dic;
        }
        public static Dictionary<int, string> AddCountryToExistingDictionary(Dictionary<int, string> existingDictionary,
            int countryCode,
            string countryName)
        {
            existingDictionary[countryCode] = countryName;
            return existingDictionary;
        }

        public static string GetCountryNameFromDictionary(Dictionary<int, string> existingDictionary, int countryCode)
        {
            if (existingDictionary.ContainsKey(countryCode))
            {
                return existingDictionary[countryCode];
            }
            return string.Empty;
        }

        public static bool CheckCodeExists(Dictionary<int, string> existingDictionary, int
countryCode)
        {
            return existingDictionary.ContainsKey(countryCode);
        }

        public static Dictionary<int, string> UpdateDictionary(Dictionary<int, string> existingDictionary, int
countryCode, string countryName)
        {
            if (existingDictionary.ContainsKey(countryCode))
            {
                existingDictionary[countryCode] = countryName;
            }
            return existingDictionary;
        }

        public static Dictionary<int, string> RemoveCountryFromDictionary(
            Dictionary<int, string> existingDictionary,
            int countryCode)
        {
            if (existingDictionary.ContainsKey(countryCode))
            {
                existingDictionary.Remove(countryCode);
            }
            return existingDictionary;
        }

        public static string FindLongestCountryName(
            Dictionary<int, string> existingDictionary)
        {
            if (existingDictionary.Count == 0)
            {
                return string.Empty;
            }

            string longestName = string.Empty;

            foreach (var country in existingDictionary.Values)
            {
                if (country.Length > longestName.Length)
                {
                    longestName = country;
                }
            }

            return longestName;
        }
    }

   
class Program
    {
        static void Main()
        {
            Dictionary<int, string> emptyDict = DialingCodes.GetEmptyDictionary();
            Console.WriteLine("Empty Dictionary Count: " + emptyDict.Count);

            Dictionary<int, string> existingDict = DialingCodes.GetExistingDictionary();
            Console.WriteLine("\nPredefined Dictionary:");
            PrintDictionary(existingDict);

            var japanDict = DialingCodes.AddCountryToEmptyDictionary(81, "Japan");
            Console.WriteLine("\nAfter Adding Japan:");
            PrintDictionary(existingDict);

            Console.WriteLine("\nCountry for code 91: " + DialingCodes.GetCountryNameFromDictionary(existingDict, 91));
            Console.WriteLine("Does code 99 exist? " + DialingCodes.CheckCodeExists(existingDict, 99));

            DialingCodes.UpdateDictionary(existingDict, 91, "Republic of India");
            Console.WriteLine("\nAfter Updating India:");
            PrintDictionary(existingDict);

            DialingCodes.RemoveCountryFromDictionary(existingDict, 1);
            Console.WriteLine("\nAfter Removing USA:");
            PrintDictionary(existingDict);

            Console.WriteLine("\nLongest Country Name: " + DialingCodes.FindLongestCountryName(existingDict));
        }

        static void PrintDictionary(Dictionary<int, string> dict)
        {
            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key} : {item.Value}");
            }
        }

    }
}