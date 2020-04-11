using BeestjeOpJeFeestje.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeestjeOpJeFeestje.Models
{
    public class AnimalViewModel
    {

        public Animal animal { get; set; }

        public int AccessoiresID { get; set; }

        public List<Accessory> PossibleAccessories { get; set; }

        public List<Accessory> Accessories { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public string Category { get; set; }

        public AnimalViewModel()
        {
            animal = new Animal();
            PossibleAccessories = new List<Accessory>();
            Accessories = new List<Accessory>();
        }
    }
}