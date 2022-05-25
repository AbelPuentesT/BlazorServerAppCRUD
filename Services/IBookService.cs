using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorServerCRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlazorServerCRUD.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllBooks();
        Task<Book> GetBookById(int id);
        Task<bool> UpdateBook(Book book);
        Task<bool> AddBook(Book book);
        Task<bool> SaveBook(Book book);
        Task<bool> DeleteBook(int id);

    }
}