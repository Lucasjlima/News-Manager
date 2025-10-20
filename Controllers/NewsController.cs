using Microsoft.AspNetCore.Mvc;
using News_Manager.Models;
using News_Manager.Repositories;

namespace News_Manager.Controllers;

public class NewsController : Controller
{
    private readonly INewsRepository _repo;

    public NewsController(INewsRepository repo)
    {
        _repo = repo;
    }

    // GET: /News
    public IActionResult Index(string search)
    {
        var model = _repo.Search(search);
        ViewData["Search"] = search;
        return View(model);
    }

    // GET: /News/Details/5
    public IActionResult Details(int id)
    {
        var news = _repo.GetById(id);
        if (news == null) return NotFound();
        return View(news);
    }

    // GET: /News/Create
    public IActionResult Create()
    {
        return View(new News { PublishDate = DateTime.Today });
    }

    // POST: /News/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(News news)
    {
        if (!ModelState.IsValid) return View(news);
        _repo.Add(news);
        return RedirectToAction(nameof(Index));
    }

    // GET: /News/Edit/5
    public IActionResult Edit(int id)
    {
        var news = _repo.GetById(id);
        if (news == null) return NotFound();
        return View(news);
    }

    // POST: /News/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, News news)
    {
        if (id != news.Id) return BadRequest();
        if (!ModelState.IsValid) return View(news);
        _repo.Update(news);
        return RedirectToAction(nameof(Index));
    }

    // GET: /News/Delete/5  -> confirmação
    public IActionResult Delete(int id)
    {
        var news = _repo.GetById(id);
        if (news == null) return NotFound();
        return View(news);
    }

    // POST: /News/DeleteConfirmed/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        _repo.Remove(id);
        return RedirectToAction(nameof(Index));
    }
}

