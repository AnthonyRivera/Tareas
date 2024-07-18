using Books.Persistence.Context;
using Books.Web.Interfaces;
using Books.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Books.Web.Models;
using System.Diagnostics;
namespace Lecture19_Tarea.Controllers
{
    public class PacienteController:Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Edit(int id)
        {
            // Pasar el id al modelo para ser utilizado en la vista
            return View(new Paciente { ID = id });
        }

        public IActionResult Delete(int id)
        {
            // Pasar el id al modelo para ser utilizado en la vista
            return View();
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
