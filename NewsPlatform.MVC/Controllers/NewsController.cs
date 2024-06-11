using Microsoft.AspNetCore.Mvc;
using NewsPlatform.Application.DTOs.NewsDTOs;
using NewsPlatform.Application.Interfaces;

namespace NewsPlatform.MVC.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsAppService _newsAppService;

        public NewsController(INewsAppService newsAppService)
        {
            _newsAppService = newsAppService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int? minPositivityRate)
        {
            var returnNewsDtoList = await _newsAppService.GetAllNews(minPositivityRate);

            return View(returnNewsDtoList);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddNewsDTO addNewsDTO)
        {
            var returnNewsDto = await _newsAppService.AddNews(addNewsDTO);

            return RedirectToAction("Details", new { id = returnNewsDto.Id });
        }


        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var returnNewsDto = await _newsAppService.GetNewsById(id);

            return View(returnNewsDto);
        }
    }
}
