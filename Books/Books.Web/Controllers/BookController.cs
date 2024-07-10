﻿using Books.Persistence.Context;
using Books.Web.Interfaces;
using Books.Web.Repositories;
using Books.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Books.Web.Models;
using System.Diagnostics;
namespace Lecture19_Tarea.Controllers
{
    public class BookController:Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly ApplicationContext _context;
        private readonly BookAdoRepository _bookAdoRepository;
        public BookController(ApplicationContext context, IBookRepository bookRepository, BookAdoRepository bookAdoRepository)
        {
            _bookRepository = bookRepository;
            _context = context;
            _bookAdoRepository = bookAdoRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            //var cotacts = _context.Contacts.ToList();
            var books = _bookRepository.GetAll();
            return View(books);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Book model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            _bookRepository.Add(model);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var contactFromDb = _bookRepository.GetById(id);
            if (contactFromDb == null)
            {
                return NotFound();
            }
            return View(contactFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Book model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _bookRepository.Update(model);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var contactFromDb = _bookRepository.GetById(id);
            if (contactFromDb == null)
            {
                return NotFound();
            }
            return View(contactFromDb);
        }
        [HttpPost]
        public IActionResult Delete(Book model)
        {
            _bookRepository.Delete(model.BookId);
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
