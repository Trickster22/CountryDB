using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CountryProject.Managers.Polities;
using CountryProject.Storage.Entity;
using Microsoft.AspNetCore.Mvc;

namespace CountryProject.Controllers
{
    public class PolityController : Controller
    {
        private readonly IPolityManager _manager;
        public PolityController (IPolityManager manager)
        {
            _manager = manager;
        }


        [HttpGet]
        public async Task<ViewResult> ShowPolity()
        {
            var entity = await _manager.GetAll();
            return View(entity);
        }
        #region Create
        public ViewResult AddPolity()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddPolity(Polity polity)
        {
            Polity pt = await _manager.AddPolity(polity);
            return RedirectToAction("ShowPolity", "Polity", new { Id = pt.Id });
        }
        #endregion
    }
}