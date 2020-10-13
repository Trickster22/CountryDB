using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CountryProject.Managers.Countries;
using CountryProject.Managers.Faiths;
using CountryProject.Managers.Polities;
using CountryProject.Storage.Entity;
using Microsoft.AspNetCore.Mvc;

namespace CountryProject.Controllers
{
    public class CountryController : Controller
    {
        private readonly ICountryManager _manager;
        private IFaithManager _faithManager;
        private IPolityManager _polityManager;

        public CountryController(ICountryManager manager,IFaithManager faithManager,IPolityManager polityManager)
        {
            _manager = manager;
            _faithManager = faithManager;
            _polityManager = polityManager;
            
        }
        [HttpGet]
        public async Task<ViewResult> ShowAll(Guid id)
        {
            var entity = await _manager.GetByID(id);
            return View(entity);
        }

        [HttpGet]
        public async Task<ViewResult> ShowCountry()
        {
            var entity = await _manager.GetAll();
            return View(entity);
        }
        #region AddCountry
        [HttpGet]
        public ViewResult AddCountry()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddCountry(Country country, string FaithName,string PolityName)
        {
           
            Faith faith = await _faithManager.GetFaithByName(FaithName);
            if (faith == null) 
            {
                faith = await _faithManager.AddFaith(new Faith { Name = FaithName });
            }
            Polity polity = await _polityManager.GetPolityByName(PolityName);
            if (polity == null)
            {
                polity = await _polityManager.AddPolity(new Polity { Name = PolityName });
            }
            country.faith = faith;
            country.Polity = polity;
            

            Country cntr = await _manager.AddCountry(country);
            return RedirectToAction("ShowCountry","Country", new { Id = cntr.Id});
        }
        #endregion

        #region UpdateCountry

        [HttpGet]
        public async Task<ViewResult> UpdateCountry(Guid id)
        {
            var entity = await _manager.GetByID(id);
            return View(entity);
        }

        [HttpPost]
        public async Task<ActionResult> UpdateCountry(Country country, string FaithName,string PolityName)
        {
            Faith faith = await _faithManager.GetFaithByName(FaithName);
            if (faith == null)
            {
                faith = await _faithManager.AddFaith(new Faith { Name = FaithName });
            }
            Polity polity = await _polityManager.GetPolityByName(PolityName);
            if (polity == null)
            {
                polity = await _polityManager.AddPolity(new Polity { Name = PolityName });
            }
            country.Polity = polity;
            country.faith = faith;

            Country cntr = await _manager.UpdateCountry(country);
            return RedirectToAction("ShowCountry", "Country", new { Id = cntr.Id });
        }

        #endregion

       
    }
}
