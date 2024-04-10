// See https://aka.ms/new-console-template for more information
using ConsoleApp2;
using System.Collections.Generic;

// Console.WriteLine("Hello, World!");

LinqQueries queries = new LinqQueries();

//PrintValues(queries.AllBooks());
//PrintValues(queries.BooksAfter2000());
//PrintValues(queries.BooksWithMore250PagesAndTitleWithWordInAction());

// Filtra todos los animales que sean de color verde que su nombre inicie con una vocal.
List<Animal> animals = new List<Animal>();
animals.Add(new Animal() { Nombre = "Hormiga", Color = "Rojo" });
animals.Add(new Animal() { Nombre = "Lobo", Color = "Gris" });
animals.Add(new Animal() { Nombre = "Elefante", Color = "Gris" });
animals.Add(new Animal() { Nombre = "Pantegra", Color = "Negro" });
animals.Add(new Animal() { Nombre = "Gato", Color = "Negro" });
animals.Add(new Animal() { Nombre = "Iguana", Color = "Verde" });
animals.Add(new Animal() { Nombre = "Sapo", Color = "Verde" });
animals.Add(new Animal() { Nombre = "Camaleon", Color = "Verde" });
animals.Add(new Animal() { Nombre = "Gallina", Color = "Blanco" });

IEnumerable<Animal> greenAnimalsWithFirstLetterIsAVowel = animals
    .Where(animal => animal.Color == "Verde" && "AEIOUaeiou".Contains(animal.Nombre.FirstOrDefault()));

//PrintAnimalValues(greenAnimalsWithFirstLetterIsAVowel);

// Retorna los elementos de la colleción animal ordenados por nombre
IEnumerable<Animal> animalsOrderByName = animals.OrderBy(animal => animal.Nombre);
//PrintAnimalValues(animalsOrderByName);

// Retorna los datos de la colleción Animales agrupada por color 
IEnumerable<IGrouping<string, Animal>> animalsGroupByColor = animals.GroupBy(animal => animal.Color);
//PrintAnimalsByGroup(animalsGroupByColor);


//Console.WriteLine("AllElementsHaveValueInStatus: {0}", queries.AllElementsHaveValueInStatus());
//Console.WriteLine("SomeElementWasPublishedIn2005 {0}", queries.SomeElementWasPublishedIn2005());

//PrintValues(queries.BooksInCategory("Python"));

//PrintValues(queries.BooksInCategoryOrderByTitle("Java", LinqQueries.OrderMode.asc));
//PrintValues(queries.BooksWithMore450PageNumberOrderByPageNumber(LinqQueries.OrderMode.desc));

//PrintValues(queries.ThreeBooksWithRecentDateAndCategoryJava());
//PrintValues(queries.ThirdAndFourBookWithMore400Pages());

//PrintValues(queries.SelectTitleAndPageNumberOfFirstThreeBooks());

//Console.WriteLine(queries.BookNumbersBetween200And500Pages());

//Console.WriteLine("LesserPublishedDate " + queries.LesserPublishedDate());

//Console.WriteLine("BiggerPageNumber " + queries.BiggerPageNumber());

Book lesserBookPageNumberGreaterThan0 = queries.LesserBookPageNumberGreaterThan0();

//Console.WriteLine($"{lesserBookPageNumberGreaterThan0.Title} - {lesserBookPageNumberGreaterThan0.PageCount}");

Book mostRecentPublishedDate = queries.MostRecentPublishedDate();

//Console.WriteLine($"{mostRecentPublishedDate.Title} - {mostRecentPublishedDate.PublishedDate}");

//Console.WriteLine($"Page total: {queries.PageTotal()}");

//Console.WriteLine($"TitlesPublishedDateAfter2015: {queries.TitlesPublishedDateAfter2015()}");

//Console.WriteLine($"TitleCharacterAverage: {queries.TitleCharacterAverage()}");

//PrintGroup(queries.PublishedBooksSince2000GroupByYear());


var dictionaryLookup = queries.BookDictionaryByWord();
//PrintDictionary(dictionaryLookup, 'S');

PrintValues(queries.JoinBooksWithMore500PagesAndPublishedBooksAfter2005());


void PrintAnimalValues(IEnumerable<Animal> animals)
{
	foreach (var item in animals)
	{
		Console.WriteLine("{0} {1}", item.Nombre, item.Color);
	}
}

void PrintAnimalsByGroup(IEnumerable<IGrouping<string, Animal>> animals)
{
    foreach (var group in animals)
    {
        Console.WriteLine($"Grupo: {group.Key}");
        foreach (var item in group)
		{
            Console.WriteLine("{0} {1}", item.Nombre, item.Color);
        }
		Console.WriteLine();
    }
}

void PrintValues(IEnumerable<Book> books)
{
    Console.WriteLine("{0,-60} {1,15} {2,15} {3,15}\n", "Titulo", "N. Páginas", "Fecha publicación", "Estatus");
	foreach (var item in books)
	{
		Console.WriteLine("{0,-60} {1,15} {2,15} {3,15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString(), item.Status);
		//Console.WriteLine("Categorías");
		//foreach (var item2 in item.Categories)
		//{
		//	Console.WriteLine(item2);
		//}
		//Console.WriteLine();
	}


}

void PrintGroup(IEnumerable<IGrouping<int, Book>> books)
{
	foreach (var group in books)
	{
		Console.WriteLine("");
		Console.WriteLine($"Grupo: {group.Key}");
		Console.WriteLine("{0,-60} {1,15} {2,15} {3,15}\n", "Titulo", "N. Páginas", "Fecha publicación", "Estatus");
		foreach (var item in group)
		{
			Console.WriteLine("{0,-60} {1,15} {2,15} {3,15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString(), item.Status);
		}

	}
}

void PrintDictionary(ILookup<char, Book> books, char word)
{
    Console.WriteLine("{0,-60} {1,15} {2,15} {3,15}\n", "Titulo", "N. Páginas", "Fecha publicación", "Estatus");
    foreach (var item in books[word])
    {
        Console.WriteLine("{0,-60} {1,15} {2,15} {3,15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString(), item.Status);
        //Console.WriteLine("Categorías");
        //foreach (var item2 in item.Categories)
        //{
        //	Console.WriteLine(item2);
        //}
        //Console.WriteLine();
    }


}
