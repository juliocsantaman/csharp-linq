// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

string[] fruits = new string[] { "Red apple", "Green apple", "Grape", "Mango" };

var appleList = fruits.Where(item => item.EndsWith("apple")).ToList();

appleList.ForEach(item => Console.WriteLine(item));