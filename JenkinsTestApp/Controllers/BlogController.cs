using Microsoft.AspNetCore.Mvc;

namespace JenkinsTestApp.Controllers;
public class BlogController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Foo()
    {
        return View();
    }
}
