using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreUI.Static
{
    public static class Endpoints
    {
        public static string BaseUrl = "https://localhost:44328/";
        public static string AuthorsUrl = $"{BaseUrl}api/authors/";
        public static string BooksUrl = $"{BaseUrl}api/books/";
        public static string RegisterUrl = $"{BaseUrl}api/register/";
    }
}
