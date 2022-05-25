using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorServerCRUD.Data;
using BlazorServerCRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorServerCRUD.Services
{
    public class BookService : IBookService
    {
        //inyeccion de depenrencias
        private readonly BookContext? _bookContext;
        public BookService(BookContext bookContext)
        {
            _bookContext = bookContext;
        }

        public async Task<bool> AddBook(Book book)
        {
            _bookContext.Add(book);
            return await _bookContext.SaveChangesAsync()>0;
        }

        public async Task<bool> DeleteBook(int id)
        {
            var book=await _bookContext.Books.FindAsync(id);
            _bookContext.Remove(book);
            return await _bookContext.SaveChangesAsync()>0;
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await _bookContext.Books.ToListAsync();
        }

        public async Task<Book> GetBookById(int id)
        {
            return await _bookContext.Books.FindAsync(id);
        }

        public async Task<bool> SaveBook(Book book)
        {
            if(book.Id>0)
                return await UpdateBook(book);
            else
                return await AddBook(book);

        }

        public async Task<bool> UpdateBook(Book book)
        {
            _bookContext.Entry(book).State = EntityState.Modified;
            return await _bookContext.SaveChangesAsync()>0 ;
        }
    }
}