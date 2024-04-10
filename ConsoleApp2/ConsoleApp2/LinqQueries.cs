using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class LinqQueries
    {

        private List<Book> books = new List<Book>();

        public LinqQueries()
        {
            using (StreamReader reader = new StreamReader("books.json"))
            {
                string json = reader.ReadToEnd();
                //this.books = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json);
                //this.books = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
                this.books = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? Enumerable.Empty<Book>().ToList();
            }
        }

        public IEnumerable<Book> AllBooks()
        {
            return this.books;
        }

        public IEnumerable<Book> BooksAfter2000()
        {
            // Extension method.
            // return this.books.Where(book => book.PublishedDate.Year > 2000);

            // Query expresion.
            return from l in this.books where l.PublishedDate.Year > 2000 select l;
        }

        public IEnumerable<Book> BooksWithMore250PagesAndTitleWithWordInAction()
        {
            // Extension method.
            return this.books.Where(book => book.PageCount > 250 && book.Title.Contains("in Action"));

            // Query expresion.
            // return from l in this.books where l.PageCount > 250 && l.Title.Contains("in Action") select l;
        }

        public Boolean AllElementsHaveValueInStatus()
        {
            return this.books.All(book => book.Status != string.Empty);
        }

        public Boolean SomeElementWasPublishedIn2005()
        {
            return this.books.Any(book => book.PublishedDate.Year == 2005);
        }

        public IEnumerable<Book> BooksInCategory(string category)
        {
            // Extension method.
            return this.books.Where(book => book.Categories.Contains(category));


            // Query expression.
            //return from l in this.books where l.Categories.Contains(category) select l;
        }

        public IEnumerable<Book> BooksInCategoryOrderByTitle(string category, OrderMode orderMode)
        {
            // Extension method.
            IEnumerable<Book> books = this.books.Where(book => book.Categories.Contains(category));

            // Query expression.
            // IEnumerable<Book> books = from l in this.books where l.Categories.Contains(category) select l;

            if (orderMode == OrderMode.asc)
            {
                return books.OrderBy(book => book.Title);

            }

            return books.OrderByDescending(book => book.Title);
        }

        public IEnumerable<Book> BooksWithMore450PageNumberOrderByPageNumber(OrderMode orderMode)
        {
            // Extension method.
            IEnumerable<Book> books = this.books.Where(book => book.PageCount > 450);

            // Query expression.
            //IEnumerable<Book> books = from l in this.books where l.PageCount > 450 select l;

            if (orderMode == OrderMode.asc)
            {
                return books.OrderBy(book => book.PageCount);

            }

            return books.OrderByDescending(book => book.PageCount);
        }

        public IEnumerable<Book> ThreeBooksWithRecentDateAndCategoryJava()
        {
            return this.books.Where(book => book.Categories.Contains("Java")).OrderByDescending(book => book.PublishedDate).Take(3).ToList();
            //return this.books.Where(book => book.Categories.Contains("Java")).OrderBy(book => book.PublishedDate).TakeLast(3).ToList();

        }

        public IEnumerable<Book> ThirdAndFourBookWithMore400Pages()
        {
            return this.books.Where(book => book.PageCount > 400).Take(4).ToList().Skip(2);

        }

        public IEnumerable<Book> SelectTitleAndPageNumberOfFirstThreeBooks()
        {
            return this.books.Take(3).Select(book => new Book() { Title=book.Title, PageCount=book.PageCount });
        }

        public int BookNumbersBetween200And500Pages()
        {
            //return this.books.Where(book => book.PageCount >= 200 && book.PageCount <= 500).Count();
            return this.books.Count(book => book.PageCount >= 200 && book.PageCount <= 500);
        }

        public DateTime LesserPublishedDate()
        {
            return this.books.Min(book => book.PublishedDate);
        }

        public int BiggerPageNumber()
        {
            return this.books.Max(book => book.PageCount);
        }

        public Book LesserBookPageNumberGreaterThan0()
        {
            return this.books.Where(book => book.PageCount > 0).MinBy(book => book.PageCount);
        }

        public Book MostRecentPublishedDate()
        {
            return this.books.MaxBy(book => book.PublishedDate);
        }

        public int PageTotal()
        {
            return this.books.Where(book => book.PageCount >=0 && book.PageCount <=500).Sum(book => book.PageCount);
        }

        public string TitlesPublishedDateAfter2015()
        {
            return this.books.Where(book => book.PublishedDate.Year > 2015).Aggregate("", (BookTitles, next) =>
            {
                if(BookTitles != string.Empty)
                {
                    BookTitles += " - " + next.Title;
                } else
                {
                    BookTitles += next.Title;
                }

                return BookTitles;
            });
        }

        public double TitleCharacterAverage()
        {
            return this.books.Average(book => book.Title.Length);
        }

        public IEnumerable<IGrouping<int, Book>> PublishedBooksSince2000GroupByYear()
        {
            return this.books.Where(book => book.PublishedDate.Year >= 2000).GroupBy(book => book.PublishedDate.Year);
        }

        public ILookup<char, Book> BookDictionaryByWord()
        {
            return this.books.ToLookup(book => book.Title[0], book => book);
        }

        public IEnumerable<Book> BooksWithMore500Pages()
        {
            return this.books.Where(book => book.PageCount > 500);
        }

        public IEnumerable<Book> PublishedBooksAfter2005()
        {
            return this.books.Where(book => book.PublishedDate.Year > 2005);
        }

        public IEnumerable<Book> JoinBooksWithMore500PagesAndPublishedBooksAfter2005()
        {
            IEnumerable<Book> booksWithMore500Pages = this.BooksWithMore500Pages();
            IEnumerable<Book> publishedBooksAfter2005 = this.PublishedBooksAfter2005();

            return publishedBooksAfter2005.Join(booksWithMore500Pages, x => x.Title, y => y.Title, (x, y) => x);

        }

        public enum OrderMode
        {
            asc,
            desc
        }
    }

}
