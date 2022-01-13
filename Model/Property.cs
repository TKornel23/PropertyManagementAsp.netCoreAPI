using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyManagement.Model
{
    public class Property
    {
        public int Price { get; set; }
        public int Age { get; set; }
        public int RoomNumber { get; set; }
        public int Owner { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Address { get; set; }
        public string Img { get; set; }
    }
}
