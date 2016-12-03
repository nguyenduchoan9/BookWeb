using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookManagement.Models;
using System.Collections;
using BookManagement.DAO;
using System.IO;

namespace BookManagement.Controllers
{
    public class HomeController : CommonMethod.CommonMethod
    {
        //BookManagementEntities db = new BookManagementEntities();
        //
        // GET: /Home/
        public ActionResult Index(string searchkey, int? page)
        {
            BookDAO book = new BookDAO();
            ViewBag.SearchString = searchkey;
            return View(book.ListBook(searchkey, page ?? 1, 12));
        }

        public ActionResult BookDetail(int bookID)
        {
            BookDAO book = new BookDAO();
            if (book == null)
            {
                Redirect("Index");
            }
            return View(book.BookDetail(bookID));
        }
        [HttpGet]
        public ActionResult InsertBook()
        {

            SetViewBag();
            return View("InsertBook");
        }
        [HttpPost]
        public ActionResult InsertBook(BookManagement.Models.Books.AddBookView book, HttpPostedFileBase upload_File)
        {
            BookDAO _bookDAO = new BookDAO();
            if (ModelState.IsValid)
            {

                if (_bookDAO.CheckBook(book.Name, book.PublisherID, book.PublishedDate) == true)
                {
                    ModelState.AddModelError("", "This book is already exsisted!");
                    SetViewBag();
                    return View("InsertBook");
                }
                if ((upload_File.ContentLength < 0) || (upload_File == null))
                {
                    SetMessage("ERROR", "Book is not added!");
                    SetViewBag();
                    return View("InsertBook");
                }
                string relativePath = "~/Content/Img/Books/" + Path.GetFileName(upload_File.FileName);
                string physicalPath = Server.MapPath(relativePath);
                upload_File.SaveAs(physicalPath);
                if (_bookDAO.InsertBook(book, upload_File.FileName) == false)
                {
                    SetMessage("ERROR", "Book is not added!");
                    SetViewBag();
                    return View("InsertBook");
                }
                SetMessage("SUCCESS", "Book is added");
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "");
            }
            SetViewBag();
            SetMessage("ERROR", "Book is not added!");
            return View("InsertBook", book);
        }

        //public ActionResult GetBooks()
        //{

        //}
        public void SetViewBag()
        {
            var bookstatus = new DAO.Status.BookStatusDAO();
            ViewBag.BookStatus = bookstatus.ListBookStatus();
            var bookauthor = new DAO.Authors.AuthorDAO();
            ViewBag.BookAuthor = bookauthor.ListAuthor();
            var bookpublisher = new DAO.Publisher.PublisherDAO();
            ViewBag.BookPublisher = bookpublisher.GetPublisher();
            var bookgenres = new DAO.Genres.GenresDAO();
            ViewBag.BookGenres = bookgenres.ListGenres();
        }

        public ActionResult ListBookByAuthor(int authorID, int? page)
        {
            BookDAO _book = new BookDAO();
            Session.Add("AUTHOR_ID", authorID);
            return View(_book.GetByAuthor(authorID, page ?? 1, 12));
        }
    }
}