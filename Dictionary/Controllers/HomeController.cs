using Dictionary.Data;
using Dictionary.Entities;
using Dictionary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Dictionary.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;
        

        public HomeController(ApplicationDbContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index(bool wordWasAdded, bool wordWasRemoved)
        {
            var model = new IndexHomeModel();
            model.WordWasAdded = wordWasAdded;
            model.WordWasRemoved = wordWasRemoved;
            var allWords = _context.Words.ToList()
                .Select(_ => new WordModel(_))
                .ToList();
            var ids = _context.UserWordMappings
                .Where(_ => _.UserId == User.UserId())
                .Select(_ => _.WordId);
            model.UserWords = allWords
                .Where(_ => ids.Contains(_.Id))
                .ToList();
            model.WordsToLearn = allWords
                .Where(_ => !ids.Contains(_.Id))
                .ToList();

            var totalWords = allWords.Count;
            model.RateOfTest = (int)(((double)model.UserWords.Count) / totalWords * 100);
            model.IsTestAvaible = ((double)model.UserWords.Count) / totalWords > 0.75;

            return View(model);
        }

        public async Task<IActionResult> AddWord(int? id)
        {
            var userWordMapping = new UserWordMapping
            {
                UserId = User.UserId(),
                WordId = (int)id
            };
            _context.UserWordMappings.Add(userWordMapping);
            await _context.SaveChangesAsync();

            return  RedirectToAction(nameof(Index), new { wordWasAdded = true });
        }

        // POST: Index/DeleteConfirmed/5
        public async Task<IActionResult> Delete(int id)
        {
            var word = _context.UserWordMappings.FirstOrDefault(_ => _.WordId == id && _.UserId == User.UserId());
            _context.UserWordMappings.Remove(word);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index), new { wordWasRemoved = true });
        }

        public IActionResult TestingPage()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
