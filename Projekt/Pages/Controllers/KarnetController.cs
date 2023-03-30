using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projekt.Pages.Model;
using Projekt.Pages.Repository;
using Microsoft.AspNetCore.Mvc;
namespace Projekt.Pages.Controllers
{
    public class KarnetController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public KarnetController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var events = _unitOfWork.KarnetRepository.GetKarnets();
            return View(events);
        }

        public IActionResult Details(int id)
        {
            var events = _unitOfWork.KarnetRepository.GetKarnetByID(id);
            return View(events);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Karnet karnet)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.KarnetRepository.InsertKarnet(karnet);

                return RedirectToAction(nameof(Index));
            }
            return View(karnet);
        }

        public IActionResult Edit(int id)
        {
            var events = _unitOfWork.SeatRepository.GetSeatByID(id);
            return View(events);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Seat e)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.SeatRepository.UpdateSeat(e);
                _unitOfWork.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(e);
        }

        public IActionResult Delete(int id)
        {
            var evseat = _unitOfWork.SeatRepository.GetSeatByID(id);
            return View(evseat);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var events = _unitOfWork.SeatRepository.GetSeatByID(id);
            _unitOfWork.SeatRepository.DeleteSeat(events.Id);
            _unitOfWork.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
