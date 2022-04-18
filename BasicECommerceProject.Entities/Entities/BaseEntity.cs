using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BasicECommerceProject.Entities.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        [JsonIgnore]
        public DateTime RecordDate { get; set; }

        [JsonIgnore]
        public DateTime? UpdateDate { get; set; }

        [JsonIgnore]
        public bool IsDeleted { get; set; }
    }
}
