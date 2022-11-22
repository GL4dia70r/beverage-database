// David Allen
// 11/15/2022 - 11/21/2022
// Assignment 5: Databases
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace cis237_assignment_5.Models
{
    public partial class Beverage
    {
        [Key]
        [Column("id")]
        [StringLength(10)]
        public string Id { get; set; }
        [Required]
        [Column("name")]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [Column("pack")]
        [StringLength(20)]
        public string Pack { get; set; }
        [Column("price", TypeName = "money")]
        public decimal Price { get; set; }
        [Column("active")]
        public bool Active { get; set; }

        public Beverage(
            string id, 
            string name, 
            string pack, 
            decimal price, 
            bool active
        )
        {
            this.Id = id;
            this.Name = name;
            this.Pack = pack;
            this.Price = price;
            this.Active = active;
        }
    }
}
