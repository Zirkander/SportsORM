using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsORM.Models;


namespace SportsORM.Controllers
{
    public class HomeController : Controller
    {

        private static Context _context;

        public HomeController(Context DBContext)
        {
            _context = DBContext;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.BaseballLeagues = _context.Leagues
                .Where(l => l.Sport.Contains("Baseball"))
                .ToList();
            return View();
        }

        [HttpGet("level_1")]
        public IActionResult Level1()
        {
            ViewBag.Womens = _context.Leagues.Where(l => l.Name.Contains("Women")).ToList();

            ViewBag.Hockey = _context.Leagues.Where(l => l.Name.Contains("Hockey")).ToList();

            ViewBag.NoFootball = _context.Leagues.Where(l =>! l.Name.Contains("Football")).ToList();

            ViewBag.Conference = _context.Leagues.Where(l => l.Name.Contains("Conference")).ToList();

            ViewBag.Atlantic = _context.Leagues.Where(l => l.Name.Contains("Atlantic")).ToList();

            ViewBag.Dallas = _context.Teams.Where(t => t.Location.Contains("Dallas")).ToList();

            ViewBag.Raptors = _context.Teams.Where(t => t.TeamName.Contains("Raptors")).ToList();

            ViewBag.Cities = _context.Teams.Where(t => t.TeamName.Contains("City")).ToList();

            ViewBag.T = _context.Teams.Where(t => t.TeamName.StartsWith("T")).ToList();

            ViewBag.Teams = _context.Teams.OrderBy(t => t.Location).ToList();

            ViewBag.TeamsR = _context.Teams.OrderByDescending(team => team.TeamName).ToList();

            ViewBag.Cooper = _context.Players.Where(n => n.LastName.Contains("Cooper")).ToList();

            ViewBag.Joshua = _context.Players.Where(n => n.FirstName.Contains("Joshua")).ToList();

            ViewBag.NoJosh = _context.Players.Where(n => n.LastName.Contains("Cooper") && n.FirstName != "Joshua").ToList();

            ViewBag.AlexOrWyatt = _context.Players.Where(n => n.FirstName.Contains("Alexander") || n.FirstName == "Wyatt").ToList();

            return View();
        }

        [HttpGet("level_2")]
        public IActionResult Level2()
        {
            return View();
        }

        [HttpGet("level_3")]
        public IActionResult Level3()
        {
            return View();
        }

    }
}