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
		public string AddBook(string title, string author, string genre, int yearPublished)
		{
			var message = BookService.AddBook(title, author, genre, yearPublished);
			//var p = new Person { Name = name, FavoriteMovie = movie };
			//People.Add(p);
			return message;
		}
		/*
		[HttpPost]
		public IHttpActionResult UpdateBook(Book updated)
		{
			//var found = People.FirstOrDefault(f => f.Id == updated.Id);
			//if (found == null)
			//{
			//	return NotFound();
			//}
			//else
			//{
			//	found.Name = updated.Name;
			//	found.FavoriteMovie = updated.FavoriteMovie;
			//	return Ok(found);
			//}
		}

		[HttpDelete]
		public IHttpActionResult DeleteBook(int id)
		{
			//People = People.Where(w => w.Id != id).ToList();
			return Ok();
		}
		*/
	}
}