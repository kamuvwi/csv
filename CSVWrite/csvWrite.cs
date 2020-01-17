using Cities;
using Csv;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace CSVWrite
{
    public class csvWrite
    {
        public static string WriteTo( string Path)
        {
            var doubleTypeConversion = new DoubleConversion();
            IList<CityModel> myList = ReadCsv.ReadCsvFile<CityModel, CityMap>(Path, doubleTypeConversion);
            var countryCapitalQueryPrimary2= from s in myList
                                      where s.Capital.Equals("primary")
                                      orderby s.Country ascending
                                      select s;
            
            foreach (CityModel city in countryCapitalQueryPrimary2)
            {
                Debug.Write(city.Country + ": " + city.City_name + Environment.NewLine);
            }
            var queryName = nameof(countryCapitalQueryPrimary2);
            var writePath = "c://csvfiles//" + queryName + ".csv";
            using (var writer = new StreamWriter(writePath))
            using (var csv = new CsvWriter(writer))
            {
                csv.WriteRecords(countryCapitalQueryPrimary2);
            }
            return writePath;
        }
    }
}
