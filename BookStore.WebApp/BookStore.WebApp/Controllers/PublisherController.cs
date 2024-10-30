using AutoMapper;
using BookStore.WebApp.Context;
using BookStore.WebApp.Context.Entities.Concrete;
using BookStore.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore.WebApp.Controllers
{
    public class PublisherController : Controller
    {
        private IMapper _mapper;
        private BookStoreDbContext _dbContext;

        public PublisherController(IMapper mapper, BookStoreDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            List<Publisher> publisherList = _dbContext.Publishers.Include(p =>p.City).ToList();
            List<PublisherViewModel> model = _mapper.Map<List<PublisherViewModel>>(publisherList);

            return View(model);
        }

        public IActionResult Add()
        {
            PublisherViewModel model = new PublisherViewModel();

            List<City> cities = _dbContext.Cities.ToList();

            List<CityViewModel> cityList = _mapper.Map<List<CityViewModel>>(cities);

            ViewBag.CityList = cityList;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(PublisherViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            Publisher publisher = _mapper.Map<Publisher>(model);

            _dbContext.Publishers.Add(publisher);
            _dbContext.SaveChanges();


            return RedirectToAction(nameof(Index));
        }
    }
}
