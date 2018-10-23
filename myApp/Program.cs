using System;
using Biblioteka;

namespace myApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Wykaz w = new Wykaz();
            w.Imie = "Arur";
            Console.WriteLine(w.Imie);
        }
    }
}
