using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VoosAPI.Models
{
    public class VoosDatabaseSettings : IVoosDatabaseSettings
    {
        public string VoosCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IVoosDatabaseSettings
    {
        public string VoosCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }



}
