using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    internal class carro
    {
        public string? Modelo { get; set; }
        public int Ano { get; set; }
        public float Velo { get; set; }

        public void acelerar()
        {
            Velo++;
            Console.WriteLine($"A velocidade do carro é: {Velo}");
        }

        public void Frear() => Console.WriteLine("Freiando o carro........");

        //public void Frear()
        //{
        //    Console.WriteLine("Freiando o carro..............");
        //}
    }
}
