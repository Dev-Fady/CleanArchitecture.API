using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public string? CreatedByID { get; set; }
        public string? CreatedByName { get; set; }
        public DateTime? CreatedDateTime { get; set; }

        public string? ModifiedByID { get; set; }
        public string? ModifiedByName { get; set; }
        public DateTime? ModifiedDateTime { get; set; }

        public string? ArchivedByID { get; set; }
        public string? ArchivedByName { get; set; }
        public DateTime? ArchivedDateTime { get; set; }

        public bool IsArchived { get; set; } = false;
    }
}
