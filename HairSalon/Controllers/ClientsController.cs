using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HairSalon.Controllers
{
  public class ClientsController : Controller
  {
    private readonly HairSalonContext _db;

    public ClientsController(HairSalonContext db)
    {
      _db = db;
    } 

    public ActionResult Index()
    {
      return View(_db.Clients.ToList());
    }

    public ActionResult Details(int id)
    {
        var thisClient = _db.Clients//gives a list of client objects from the database
            .Include(client => client.JoinEntities)//this loads the join properties of each client
            .ThenInclude(join => join.Stylist)//this loads the actual stylist objects related to each client
            .FirstOrDefault(client => client.ClientId == id);
        return View(thisClient);
    }

    [HttpGet]
    public ActionResult Create()
    {
      ViewBag.StylistId = new SelectList(_db.Stylists, "StylistId", "Name");
        return View();
    }

    [HttpPost]
    public ActionResult Create(Client client, int StylistId)
    {
        _db.Clients.Add(client);
        _db.SaveChanges();
        if (StylistId != 0)
        {
          _db.ClientStylist.Add(new ClientStylist() { StylistId = StylistId, ClientId = client.ClientId});
        }
        return RedirectToAction("Index");
    }
    [HttpGet]
    public ActionResult Edit(int id)
    {
        var thisClient = _db.Clients.FirstOrDefault(client => client.ClientId == id);
        ViewBag.StylistId = new SelectList(_db.Stylists, "StylistId", "Name");
        return View(thisClient);
    }

    [HttpPost]
    public ActionResult Edit(Client client, int StylistId)
    {
      if (StylistId != 0)
      {
        _db.ClientStylist.Add(new ClientStylist() { StylistId = StylistId, ClientId = client.ClientId});
      }
        _db.Entry(client).State = EntityState.Modified;
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public ActionResult AddStylist(int id)
    {
        var thisClient = _db.Clients.FirstOrDefault(client => client.ClientId == id);
        ViewBag.StylistId = new SelectList(_db.Stylists, "StylistId", "Name");
        return View(thisClient);
    }

    [HttpPost]
    public ActionResult AddStylist(Client client, int StylistId)
    {
        if (StylistId != 0)
        {
        _db.ClientStylist.Add(new ClientStylist() { StylistId = StylistId, ClientId = client.ClientId });
        }
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
  }
}