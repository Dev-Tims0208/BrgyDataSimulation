using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BrgyDataSimulation.Models
{
    public class Barangay
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("CityId")]
        public virtual City City { get; set; }
        public int CityId { get; set; }
        public string Population { get; set; }
    }
}