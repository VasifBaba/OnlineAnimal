using HS_01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HS_01.ViewModels
{
    public class DefaultVIiewModel
    {
        public List<Category> ctg { get; set; }
        public List<Animal> ani { get; set; }
        public Animal aniDetail { get; set; }
        public List<City> cty { get; set; }
        public User uss { get; set; }
        public List<Banner> ban { get; set; }
        public Elanlar elanFirst { get; set; }
        public IEnumerable<Animal> anima { get; set; }
   
    }
}