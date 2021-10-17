using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using System.Linq;


namespace HairSalon.Controllers
{
  public class StylistsController : Controller
  {
    private readonly HairSalonContext _db;

    public StylistsController(HairSalonContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Stylists.ToList());
    }
    [HttpGet]
    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Create(Stylist stylist)
    {
        _db.Stylists.Add(stylist);
        _db.SaveChanges();
        return RedirectToAction("Index");

    }

    [HttpGet]
    public ActionResult Details(int id)
    {
        var thisStylist = _db.Stylists//gives a list of client objects from the database
            .Include(stylist => stylist.JoinEntities)//this loads the join properties of each client
            .ThenInclude(join => join.Client)//this loads the actual stylist objects related to each client
            .FirstOrDefault(stylist => stylist.StylistId == id);
        return View(thisStylist);
    }
    

    [HttpGet]
    public ActionResult Edit(int id)
    {
        var thisStylist = _db.Stylists.FirstOrDefault(stylist => stylist.StylistId == id);
        return View(thisStylist);
    }

    [HttpPost]
    public ActionResult Edit(Stylist stylist)
    {
        _db.Entry(stylist).State = EntityState.Modified;
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public ActionResult Delete(int id)
    {
        var thisStylist = _db.Stylists.FirstOrDefault(stylist => stylist.StylistId == id);
        return View(thisStylist);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
        var thisStylist = _db.Stylists.FirstOrDefault(stylist => stylist.StylistId == id);
        _db.Stylists.Remove(thisStylist);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
  }
}