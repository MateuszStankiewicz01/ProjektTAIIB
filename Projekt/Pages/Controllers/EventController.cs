using Microsoft.AspNetCore.Mvc;
using Projekt.Pages.Model;
using Projekt.Pages.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.Pages.Controllers
{
    public class EventController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public EventController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var events = _unitOfWork.EventRepository.GetEvent();
            return View(events);
        }

        public IActionResult Details(int id)
        {
            var events = _unitOfWork.EventRepository.GetEventByID(id);
            return View(events);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Event events)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.EventRepository.InsertEvent(events);

                return RedirectToAction(nameof(Index));
            }
            return View(events);
        }

        public IActionResult Edit(int id)
        {
            var events = _unitOfWork.EventRepository.GetEventByID(id);
            return View(events);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Event e)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.EventRepository.UpdateEvent(e);
                _unitOfWork.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(e);
        }

        public IActionResult Delete(int id)
        {
            var user = _unitOfWork.EventRepository.GetEventByID(id);
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var events = _unitOfWork.EventRepository.GetEventByID(id);
            _unitOfWork.EventRepository.DeleteEvent(events.Id);
            _unitOfWork.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
