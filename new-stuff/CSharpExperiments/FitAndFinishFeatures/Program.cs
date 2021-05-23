using System;
using System.Text;

namespace FitAndFinishFeatures
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Weather w = new(); //in C# 9.0, no need to specify the type name after new.
            Console.WriteLine(w.Place);
            Weather w1 = new() {Place = "Romania"}; // you can set the properties with new.
            Console.WriteLine(w1.Place);
            Console.WriteLine(ForecastFor(DateTime.Now, new())); //new can be used as method argument
        }

        static int ForecastFor(DateTime forecastDate, Weather weather)
        {
            if (weather.Place is null) weather.Place = "Romania"; //default to Romania
            return weather.Temprature + new Random().Next(5);
        }
    }

    class Weather
    {
        public string Place { get; set; }
        public int Temprature { get; set; }
    }
}