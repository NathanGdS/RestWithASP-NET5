using RestWithASPNET.Data.Converter.Contract;
using RestWithASPNET.Data.VO;
using RestWithASPNET.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET.Data.Converter.Implementation
{
    public class BookConverter : IParser<BookVO, Book>, IParser<Book, BookVO>
    {
        public Book Parse(BookVO origin)
        {
            if (origin == null)
            {
                return null;
            } else
            {
                return new Book
                {
                    Id = origin.Id,
                    Author = origin.Author,
                    LaunchDate = origin.LaunchDate,
                    Price = origin.Price,
                    Title = origin.Title
                };
            }
        }

        public BookVO Parse(Book origin)
        {
            if (origin == null)
            {
                return null;
            } else
            {
                return new BookVO
                {
                    Id = origin.Id,
                    Author = origin.Author,
                    LaunchDate = origin.LaunchDate,
                    Price = origin.Price,
                    Title = origin.Title
                };
            }
        }

        public List<Book> Parse(List<BookVO> origin)
        {
            if (origin == null)
            {
                return null;
            } else
            {
                return origin.Select(item => Parse(item)).ToList();
            }
        }

        public List<BookVO> Parse(List<Book> origin)
        {
            if (origin == null)
            {
                return null;
            } else
            {
                return origin.Select(item => Parse(item)).ToList();
            }
        }
    }
}
