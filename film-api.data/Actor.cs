using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace film_api.data
{
    public class Actor
    {
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
    }
}
