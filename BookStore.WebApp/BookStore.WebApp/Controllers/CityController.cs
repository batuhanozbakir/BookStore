﻿using BookStore.WebApp.Context;
using BookStore.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookStore.WebApp.Context.Entities.Concrete;
using AutoMapper;
namespace BookStore.WebApp.Controllers
{
    public class CityController : Controller
    {
        private readonly BookStoreDbContext _dbContext;      
        private IMapper _mapper;
        public CityController(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            List<City> cities = _dbContext.Cities.Where(c=>c.IsDeleted == false).ToList();
            List<CityViewModel> model = _mapper.Map<List<CityViewModel>>(cities);
            return View(model);
        }

        public IActionResult Add()
        {
            CityViewModel model = new CityViewModel();
            
            List<City> cities = _dbContext.Cities.ToList();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(CityViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            City city = _mapper.Map<City>(model);

            _dbContext.Cities.Add(city);
            _dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
        
        City city = _dbContext.Cities.Where(c=>c.Id == id).FirstOrDefault();

            CityViewModel model = _mapper.Map<CityViewModel>(city);

        return View(model); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(CityViewModel model)
        {
            
            City city = _mapper.Map<City>(model);

            _dbContext.Cities.Update(city);
            _dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

    
        public IActionResult Remove(int id)
        {
          City city = _dbContext.Cities.Where(c => c.Id == id && c.IsDeleted == false).FirstOrDefault();

            if(city != null)
            {
                city.IsDeleted = true;
                city.Deleted = DateTime.Now;

                _dbContext.Remove(city);

                _dbContext.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
