using CodeStorageMVC.Models;
using CodeStorageMVC.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CodeStorageMVC.Controllers
{
    public class CodeController : Controller
    {
        private readonly CodeService _codeService;

        public CodeController(CodeService codeService)
        {
            _codeService = codeService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RedirectToCodePage(string key)
        {
            return RedirectToAction("ViewCode", new { key });
        }

        public async Task<IActionResult> ViewCode(string key)
        {
            var codeEntry = await _codeService.GetByKeyAsync(key);
            return View(codeEntry);
        }

        public IActionResult Admin()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCode(CodeEntry codeEntry)
        {
            await _codeService.AddCodeAsync(codeEntry);
            return RedirectToAction("Admin");
        }
    }
}
