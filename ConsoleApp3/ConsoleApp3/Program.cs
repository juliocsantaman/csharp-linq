// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using Humanizer;
using System.Globalization;

int age = 23;

Console.WriteLine($"Age: {age.ToWords(new CultureInfo("es"))}");