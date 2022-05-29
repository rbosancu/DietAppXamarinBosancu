using System;
using System.Collections.Generic;
using System.Text;

namespace DietApp.Models
{
    public class Aliment
    {
        public string Nume { get; set; }
        public int Greutate { get; set; }

        private double _calorii;
        public double Calorii 
        {
            get => Math.Round(_calorii, 2);
            set => _calorii = value;
        }

        public Aliment()
        {

        }
    }
}
