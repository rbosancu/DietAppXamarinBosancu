using System;
using System.Collections.Generic;
using System.Text;

namespace DietApp.Models
{
    public class Breakfast
    {
        public DateTime Day;

        public List<Aliment> Foods = new List<Aliment>();
    }
}
