using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ASP.NET_AJAX.Models;

namespace ASP.NET_AJAX.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        ViewBag.CurrentYear = DateTime.Now.Year;
        return View(new UserModel());
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult About()
    {
        ViewData["Message"] = "Веб-приложение для заполнения заявки и просмотра анкеты человека.";
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult SubmitApplication(UserModel model)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.CurrentYear = DateTime.Now.Year;
            return View("Index", model);
        }

        if (model.BirthYear > DateTime.Now.Year)
        {
            ModelState.AddModelError(nameof(model.BirthYear), "Год рождения не может быть больше текущего года");
            ViewBag.CurrentYear = DateTime.Now.Year;
            return View("Index", model);
        }

        int age = DateTime.Now.Year - model.BirthYear!.Value;
        var result = new ApplicationResultModel
        {
            Name = model.Name,
            Email = model.Email,
            Phone = model.Phone,
            City = model.City,
            BirthYear = model.BirthYear.Value,
            Age = age,
            Education = model.Education,
            Comment = model.Comment,
            SubmittedAt = DateTime.Now
        };

        HttpContext.Session.SetString("UserName", model.Name);
        HttpContext.Session.SetInt32("Age", age);
        return View("ApplicationSuccess", result);
    }




    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
