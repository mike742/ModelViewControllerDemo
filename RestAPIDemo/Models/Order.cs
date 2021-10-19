using System;
using System.ComponentModel.DataAnnotations;

namespace RestAPIDemo.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
}
