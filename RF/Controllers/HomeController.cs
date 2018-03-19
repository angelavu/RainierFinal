using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hw7.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Q1()
        {

            RainerEntities model = new RainerEntities();
            ViewBag.Message = "Query 1: What are the top 10 PC Games by score?";

            var query1 = (from IGN_Table in model.IGN_Table
                          where IGN_Table.Platform == "PC"
                          orderby IGN_Table.Score descending
                          select IGN_Table
                          ).Take(10);

            List<IGN_Table> IGNList = query1.ToList();

            return View(IGNList);
        }


        public ActionResult Q2()
        {

            RainerEntities model = new RainerEntities();
            ViewBag.Message = "Query 2: What are the platform(s) for top 5 selling games globally?";

            var query2 = (from VGSales_Table in model.VGSales_Table
                          orderby VGSales_Table.Global_Sales descending
                          select VGSales_Table).Take(5);

            List<VGSales_Table> VGList = query2.ToList();

            return View(VGList);
        }


        public ActionResult Q3()
        {

            RainerEntities model = new RainerEntities();
            ViewBag.Message = "Query 3: Who are the top 5 selling game publishers and what is the sales everywhere for their number one game?";

            var query3 = (from VGSales_Table in model.VGSales_Table
                         join Steamspy_Table in model.Steamspy_Table on VGSales_Table.GameID equals Steamspy_Table.GameID
                         orderby VGSales_Table.Global_Sales descending, VGSales_Table.NA_Sales descending, VGSales_Table.EU_Sales descending
                         select VGSales_Table).Take(5);

            List<VGSales_Table> VGList = query3.ToList();

            return View(VGList);
        }

        public ActionResult Q4()
        {

            RainerEntities model = new RainerEntities();
            ViewBag.Message = "Query 4: Of Top 10 PC games in NA what were the different ratings?";

            var query4 = (from Steamspy_Table in model.Steamspy_Table
                          join VGSales_Table in model.VGSales_Table on Steamspy_Table.GameID equals VGSales_Table.GameID
                          join IGN_Table in model.IGN_Table on Steamspy_Table.GameID equals IGN_Table.GameID
                          orderby VGSales_Table.NA_Sales descending, IGN_Table.Score descending
                          select Steamspy_Table
                          ).Take(5);

            List<Steamspy_Table> SteamList = query4.ToList();

            return View(SteamList);
        }

        public ActionResult Q5()
        {

            RainerEntities model = new RainerEntities();
            ViewBag.Message = "Query 5: How many titles are Ubisoft games?";

            var query5 = (from VGSales_Table in model.VGSales_Table
                          where VGSales_Table.Publisher.Contains("Ubisoft")
                          orderby VGSales_Table.Global_Sales descending
                          select VGSales_Table).Take(15);

            List<VGSales_Table> VGList = query5.ToList();

            return View(VGList);
        }

        public ActionResult Q6()
        {

            RainerEntities model = new RainerEntities();
            ViewBag.Message = "Query 6: What game has sold the most copies?";

            var query6 = (from VGSales_Table in model.VGSales_Table
                          orderby VGSales_Table.Global_Sales descending
                          select VGSales_Table).Take(1);
           
            List<VGSales_Table> VGList = query6.ToList();

            return View(VGList);
        }

        public ActionResult Q7()
        {

            RainerEntities model = new RainerEntities();
            ViewBag.Message = "Query 7: What games were released in March (all tables)?";

            var query7 = (from IGN_Table in model.IGN_Table
                          join VGSales_Table in model.VGSales_Table on IGN_Table.GameID equals VGSales_Table.GameID
                          join Steamspy_Table in model.Steamspy_Table on VGSales_Table.Title equals Steamspy_Table.Title
                          where Steamspy_Table.Month == 3
                          select IGN_Table).Take(10);

            List<IGN_Table> IGNList = query7.ToList();

            return View(IGNList);
        }

        public ActionResult Q8()
        {

            RainerEntities model = new RainerEntities();
            ViewBag.Message = "Query 8: What are the Top 5 rated IGN games?";

            var query8 = (from IGN_Table in model.IGN_Table
                          orderby IGN_Table.Score descending
                          select IGN_Table).Take(5);

            List<IGN_Table> IGNList = query8.ToList();

            return View(IGNList);
        }


    }
}