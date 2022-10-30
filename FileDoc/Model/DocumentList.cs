using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FileDoc.Model
{
    public class DocumentList
    {
        [Key]
        public int DocumentId { get; set; }
        public string DocumentName { get; set; }
        public string Type { get; set; }
        public DateTime createdDate { get; set; }
        public string FlightNo { get; set; }

        public int UserId { get; set; }
        public UserModel User { get; set; }
    }
}
