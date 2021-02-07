using System.Collections.Generic;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using Frank.Apps.StarMap.Models;
using Microsoft.Extensions.Options;

namespace Frank.Apps.StarMap.Repositories
{
    public class StarRepository
    {
        public CsvConfiguration _configuration;

        public StarRepository(IOptions<CsvConfiguration> configuration)
        {
            _configuration = configuration.Value;
        }



        //public IEnumerable<Star> GetEnumerable(DirectoryInfo directory)
        //{

        //}

        public IEnumerable<Star> GetEnumerable(string csvString)
        {
            var output = new List<Star>();

            using var reader = new StringReader(csvString);
            using var csv = new CsvReader(reader, _configuration);
            csv.Context.RegisterClassMap<StartClassMap>();

            var records = csv.GetRecords<Star>();
            output.AddRange(records);

            return output;
        }
    }
}
