using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using LibraryAPI.Models;
using LibraryAPI.Services;

namespace LibraryAPI.Controllers
{
	public class CatalogController : ApiController
	{


		[HttpGet]
		public IHttpActionResult GetAllBooks()
		{
			var books = BookService.GetAllBooks();
			return Ok(books);
		}

		[HttpGet]
		public IHttpActionResult GetBooksByStatus(bool IsCheckedOut)
		{
			var requestedStatus = IsCheckedOut ? 1:0;
			var books = BookService.GetBooksByStatus(requestedStatus);
			return Ok(books);
		}

		/*
		[HttpGet]
		public IHttpActionResult GetBook(string title)
		{
			//return Ok(Books.FirstOrDefault(f => String.Compare(title, f.title) == 0));
		}
		*/
		 
		[HttpPut]
		public IHttpActionResult AddBook(string title, string author, string genre, int yearPublished)
		{
			var message = BookService.AddBook(title, author, genre, yearPublished);
			return Ok(message);
		}
		
		[HttpPost]
		public IHttpActionResult UpdateBook(int id, string title, string author, string genre, int yearPublished, bool isCheckedOut, DateTime checkOutDate, DateTime dueDate)
		{
			var checkedOut = isCheckedOut ? 1 : 0;
			var message = BookService.UpdateBook(id, title, author, genre, yearPublished, checkedOut, checkOutDate, dueDate);
			return Ok(message);

		}
		
		[HttpDelete]
		public IHttpActionResult DeleteBook(int id)
		{
			var message = BookService.DeleteBook(id);
			return Ok();
		}
		
	}
}