using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;

class Library
{

    private Dictionary<int, string> books = new Dictionary<int, string>();

    public string this[int bookId]
    {
        get
        {
            if (books.ContainsKey(bookId))
            {
                return books[bookId];
            }
            return "Book ID not found";
        }
        set
        {
            books[bookId] = value;
        }
    }

    public string this[string title]
    {
        get
        {
            var book = books.FirstOrDefault(b => b.Value == title);
            if(!book.Equals(default(KeyValuePair<int, string>)))
            {
                return book.Value;
            }
            return "Book title not found";
        }
    }
}
