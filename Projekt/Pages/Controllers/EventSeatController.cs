using Microsoft.AspNetCore.Mvc;
using Projekt.Pages.Model;
using Projekt.Pages.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.Pages.Controllers
{
    public class EventSeatController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public EventSeatController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var events = _unitOfWork.EventSeatRepository.GetEventSeat();
            return View(events);
        }

        public IActionResult Details(int id)
        {
            var events = _unitOfWork.EventSeatRepository.GetEventSeatByID(id);
            return View(events);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EventSeat events)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.EventSeatRepository.InsertEventSeat(events);

                return RedirectToAction(nameof(Index));
            }
            return View(events);
        }

        public IActionResult Edit(int id)
        {
            var events = _unitOfWork.EventSeatRepository.GetEventSeatByID(id);
            return View(events);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EventSeat e)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.EventSeatRepository.UpdateEventSeat(e);
                _unitOfWork.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(e);
        }

        public IActionResult Delete(int id)
        {
            var evseat = _unitOfWork.EventSeatRepository.GetEventSeatByID(id);
            return View(evseat);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var events = _unitOfWork.EventSeatRepository.GetEventSeatByID(id); 
            _unitOfWork.EventRepository.DeleteEvent(events.Id);
            _unitOfWork.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
