using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Projekt.Pages.Model;
using Projekt.Pages.Repository;
namespace Projekt.Pages.Controllers
{
    public class StuardController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public StuardController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var events = _unitOfWork.StuardRepository.GetStuards();
            return View(events);
        }

        public IActionResult Details(int id)
        {
            var events = _unitOfWork.StuardRepository.GetStuardByID(id);
            return View(events);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Stuard events)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.StuardRepository.InsertStuard(events);

                return RedirectToAction(nameof(Index));
            }
            return View(events);
        }

        public IActionResult Edit(int id)
        {
            var events = _unitOfWork.StuardRepository.GetStuardByID(id);
            return View(events);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Stuard e)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.StuardRepository.UpdateStuard(e);
                _unitOfWork.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(e);
        }

        public IActionResult Delete(int id)
        {
            var evseat = _unitOfWork.StuardRepository.GetStuardByID(id);
            return View(evseat);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var events = _unitOfWork.StuardRepository.GetStuardByID(id);
            _unitOfWork.StuardRepository.DeleteStuard(events.Id);
            _unitOfWork.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
