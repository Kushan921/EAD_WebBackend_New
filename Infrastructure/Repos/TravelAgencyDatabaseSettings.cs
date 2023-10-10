using Domain.IRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repos
{
    public class TravelAgencyDatabaseSettings: ITravelAgencyDatabaseSettings
    {
        public string? TrainSheduleCollectionName { get; set; } = String.Empty;
        public string? UserCollectionName { get; set; } = String.Empty;
        public string? ConnectionString { get; set; } = String.Empty;
        public string? DatabaseName { get; set; } = String.Empty;
    }
}
