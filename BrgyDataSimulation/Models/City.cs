using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BrgyDataSimulation.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("ProvinceId")]
        public virtual Province Province { get; set; }
        public int ProvinceId { get; set; }
    }
}