using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Task2.Tests
{
    [TestFixture]
    public class SearchTests
    {   
        [TestCase(ExpectedResult = 3)]
        public int BinarySearch_ArrayOfIntegers_ExpectedIndexOfInteger()
        {
            int[] temp = { 1, 2, 3, 4, 5, 6, 7 };
            return temp.BinarySearch(4);
        }

        [TestCase(ExpectedResult = -1)]
        public int BinarySearch_ArrayOfIntegersNoValue_ExpectedIndexOfInteger()
        {
            int[] temp = { 1, 2, 3, 4, 5, 6, 7 };
            return temp.BinarySearch(15);
        }

        [TestCase(ExpectedResult = 1)]
        public int BinarySearch_ArrayOfStrings_ExpectedIndexOfString()
        {
            string[] str = { "a", "b", "c", "d" };
            return str.BinarySearch("b");
        }

        [TestCase(ExpectedResult = 1)]
        public int BinarySearch_ArrayOfSymbols_ExpectedIndexOfSymbol()
        {
            string temp = "abcdef";
            return temp.ToCharArray().BinarySearch('b');
        }

        [TestCase(ExpectedResult = 0)]
        public int BinarySearch_ArrayOfBooks_ExpectedIndexOfBook()
        {
            Book book1 = new Book("Война и мир", "Лев Толстой", "роман-эпопея", 1408, "русский", "Россия");
            Book book2 = new Book("Преступление и наказание", "Федор Достоевский", "роман", 608, "русский", "Россия");
            Book book3 = new Book("Собачье сердце", "Михаил Булгаков", "повесть", 384, "русский", "Россия");
            Book book4 = new Book("Тихий Дон", "Михаил Шолохов", "роман-эпопея", 1505, "русский", "Россия");
            Book book5 = new Book("Обломов", "Иван Гончаров", "роман", 640, "русский", "Россия");
            Book book6 = new Book("Идиот", "Федор Достоевский", "роман", 640, "русский", "Россия");
            Book book7 = new Book("Тихий дон", "Михаил Шолохов", "роман-эпопея", 1230, "английский", "Россия");

            Book[] temp = new Book[] { book1, book2, book3, book4, book5, book6, book7 };

            return temp.BinarySearch(book3);
        }

        [TestCase(ExpectedResult = 1)]
        public int BinarySearch_ArrayOfBooksAnonMethod_ExpectedIndexOfBook()
        {
            Book book1 = new Book("Война и мир", "Лев Толстой", "роман-эпопея", 1408, "русский", "Россия");
            Book book2 = new Book("Преступление и наказание", "Федор Достоевский", "роман", 608, "русский", "Россия");
            Book book3 = new Book("Собачье сердце", "Михаил Булгаков", "повесть", 384, "русский", "Россия");
            Book book4 = new Book("Тихий Дон", "Михаил Шолохов", "роман-эпопея", 1505, "русский", "Россия");
            Book book5 = new Book("Обломов", "Иван Гончаров", "роман", 640, "русский", "Россия");
            Book book6 = new Book("Идиот", "Федор Достоевский", "роман", 640, "русский", "Россия");
            Book book7 = new Book("Тихий дон", "Михаил Шолохов", "роман-эпопея", 1230, "английский", "Россия");

            Book[] temp = new Book[] { book1, book2, book3, book4, book5, book6, book7 };

            return temp.BinarySearch(book6, delegate (Book firstBook, Book secondBook)
            {
                return firstBook.Title.CompareTo(secondBook.Title);
            });
        }

        [Test]
        public void BinarySearch_ArrayOfStringsNullReferencedValue_ThrowsArgumentNullException()
        {
            string[] str = { "a", "b", "c", "d" };
            Assert.Throws<ArgumentNullException>(() => str.BinarySearch(null));
        }

        [Test]
        public void BinarySearch_NullReferencedArray_ThrowsArgumentNullException()
        {
            string[] str = null;
            Assert.Throws<ArgumentNullException>(() => str.BinarySearch("b"));
        }

        [Test]
        public void BinarySearch_BlankArrayOfStrings_ThrowsArgumentException()
        {
            string[] str = { };
            Assert.Throws<ArgumentException>(() => str.BinarySearch("a"));
        }

    }
}
