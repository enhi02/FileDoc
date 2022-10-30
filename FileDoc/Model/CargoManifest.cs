
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FileDoc.Model
{
    public class CargoManifest
    {
        [Key]
        public int FlightId { get; set; }
        public int FlightNo { get; set; }
        public DateTime Time { get; set; }
        public string PointOfUnLoading { get; set; }
        public string PointOfLoading { get; set; }
    }
}
