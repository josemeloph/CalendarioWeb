using CalendarioWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarioWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(Calendario cal)
        {
            Calendario calendario = new Calendario() { Data = DateTime.Now };
            calendario.GerarCalendario();
            return View(calendario);
        }

        [HttpPost]
        public IActionResult ProximoMes(DateTime data, int dia)
        {
            int mes = data.Month;
            int ano = data.Year;
            if (mes == 12)
            {
                mes = 1;
                ano ++;
            }
            else mes++;
            int qteDias = DateTime.DaysInMonth(ano ,mes);
            data = dia > qteDias ? new DateTime(ano, mes, qteDias) : new DateTime(ano, mes, dia);
            Calendario cal = new Calendario { Data = data };
            cal.GerarCalendario();
            ViewData["semana"] = cal.Data.ToString("ddd");
            ViewData["dia"] = cal.Data.Day;
            return View("Index", cal);
        }

        [HttpPost]
        public IActionResult MesAnterior(DateTime data, int dia)
        {
            int mes = data.Month;
            int ano = data.Year;
            if (mes == 1)
            {
                mes = 12;
                ano--;
            }
            else mes--;
            int qteDias = DateTime.DaysInMonth(ano, mes);
            data = dia > qteDias ? new DateTime(ano, mes, qteDias) : new DateTime(ano, mes, dia);
            Calendario cal = new Calendario { Data = data };
            cal.GerarCalendario();
            return View("Index", cal);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
