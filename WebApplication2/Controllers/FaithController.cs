using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CountryProject.Managers.Faiths;
using CountryProject.Storage.Entity;
using Microsoft.AspNetCore.Mvc;

namespace CountryProject.Controllers
{
    public class FaithController : Controller
    {

        private readonly IFaithManager _manager;
        public FaithController(IFaithManager manager)
        {
            _manager = manager;
        }

        
        [HttpGet]
        public  async Task<ViewResult> ShowFaith()
        {
            var entity = await _manager.GetAll();
            return View(entity);
        }
        #region Create
        public ViewResult AddFaith()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddFaith(Faith faith)
        {
            Faith ft = await _manager.AddFaith(faith);
                return RedirectToAction("ShowFaith", "Faith", new { Id = ft.Id });
        }
        #endregion

        #region UpdateFaith

        [HttpGet]
        public async Task<ViewResult> UpdateFaith(Guid id)
        {
            Faith faith = await _manager.GetByID(id);
            return View(faith);
        }

        [HttpPost]
        public async Task<ActionResult>UpdateFaith(Guid Id,  Faith faith )
        {
            Faith ft = await _manager.UpdateFaith(Id, faith);
            return RedirectToAction("ShowFaith", "Faith", new { Id = ft.Id });
        }

        #endregion

        #region Delete
        [HttpPost]
        public async Task<ActionResult> Delete(Guid Id)
        {
            Faith ft = await _manager.RemoveFaith(Id);
            return RedirectToAction("ShowFaith","Faith");
        }
        #endregion
    }
}