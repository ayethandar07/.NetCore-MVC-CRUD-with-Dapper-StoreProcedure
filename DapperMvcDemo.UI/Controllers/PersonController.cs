using DapperMvcDemo.Data.Models.Domain;
using DapperMvcDemo.Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DapperMvcDemo.UI.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonRepository _personRepository;

        public PersonController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Person person)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return View(person);
                }

                bool addPersonResult = await _personRepository.AddAsync(person);
                if(addPersonResult)
                    TempData["msg"] = "Successfully added";
                else
                    TempData["msg"] = "Could not added";

            }
            catch (Exception)
            {
                TempData["msg"] = "Could not added";
            }
            return RedirectToAction(nameof(Add));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Person person)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetById()
        {
            return View();
        }

        //[HttpPost]
        public async Task<IActionResult> DisplayAll()
        {
            var people = await _personRepository.GetAllAsync();
            return View(people);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var deleteResult = await _personRepository.DeleteAsync(id);
            return RedirectToAction(nameof(DisplayAll));
        }

    }
}
