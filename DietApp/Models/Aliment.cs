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
        public int Carbohidrati { get; set; }
        public int Proteine { get; set; }

        public Aliment()
        {

        }
        //public Aliment(string nume, int greutate, int calorii)
        //{
        //    Nume = nume;
        //    Greutate = greutate;
        //    Calorii = calorii;
        //}
    }
}
