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
            ViewBag.Message = "Query One: How many of the top 10(score) titles are PC games?";
            //SELECT TOP 10 IGN_Table.Score, NA_Sales, EU_Sales, Japan_Sales, Other_Sales, Global_Sales FROM IGN_Table JOIN VGSales_Table ON IGN_Table.Title = VGSales_Table.Title WHERE VGSales_Table.Platform = “PC”;

            var query1 = (from IGN_Table in model.IGN_Table
                          join VGSales_Table in model.VGSales_Table
                          on IGN_Table.Title equals VGSales_Table.Title
                          where IGN_Table.Platform == "PC"
                          orderby IGN_Table.Score descending
                          select IGN_Table).Take(10);

            List<IGN_Table> IGNList = query1.ToList();

            return View(IGNList);
        }


        public ActionResult Q2()
        {

            RainerEntities model = new RainerEntities();
            ViewBag.Message = "Query Two: What are the platform(s) for top 5 selling games Globally?";
            //SELECT TOP 5 IGN_Table.Platform, NA_Sales, EU_Sales, Japan_Sales, Other_Sales, Global_Sales FROM VGSales_Table JOIN IGN_Table ON.VGSales_TableTitle = IGN_Table.Title JOIN SteamSpy_Table ON IGN_Table.title = SteamSpy_Table.Title;

            var query2 = (from IGN_Table in model.IGN_Table
                          join VGSales_Table in model.VGSales_Table on IGN_Table.Title equals VGSales_Table.Title
                          join Steamspy_Table in model.Steamspy_Table on VGSales_Table.Title equals Steamspy_Table.Title
                          orderby VGSales_Table.Global_Sales descending
                          select IGN_Table).Take(5);

            List<IGN_Table> IGNList = query2.ToList();

            return View(IGNList);
        }


        public ActionResult Q3()
        {

            RainerEntities model = new RainerEntities();
            ViewBag.Message = "Query Three: What are the top selling game publishers Globally?";
            //SELECT TOP 3 Publisher, Publisher(s), NA_Sales FROM VGSales_Table JOIN SteamSpy_Table ON VGSales_Table.Title = SteamSpy_Table.Title;

            var query3 = (from VGSales_Table in model.VGSales_Table
                          join Steamspy_Table in model.Steamspy_Table on VGSales_Table.Title equals Steamspy_Table.Title
                          orderby VGSales_Table.NA_Sales descending
                          select VGSales_Table).Take(10);

            List<VGSales_Table> VGList = query3.ToList();

            return View(VGList);
        }

        public ActionResult Q4()
        {

            RainerEntities model = new RainerEntities();
            ViewBag.Message = "Query 4: Of Top 10 games in NA What were the different ratings?";
            //SELECT TOP 10 VGSales_Table.Title, NA_Sales, SteamSpy_Table.Score, IGN_Table.Score from VGSales_Table JOIN SteamSpy_Table ON VGSales_Table.Title = SteamSpy_Table.Title JOIN IGN_Table ON SteamSpy_Table.Title = IGN_Table.Title;

            var query4 = (from IGN_Table in model.IGN_Table
                          join VGSales_Table in model.VGSales_Table on IGN_Table.Title equals VGSales_Table.Title
                          join Steamspy_Table in model.Steamspy_Table on VGSales_Table.Title equals Steamspy_Table.Title
                          orderby Steamspy_Table.Average_Score_Rank descending
                          select Steamspy_Table).Take(10);

            List<Steamspy_Table> SteamList = query4.ToList();

            return View(SteamList);
        }

        public ActionResult Q5()
        {

            RainerEntities model = new RainerEntities();
            ViewBag.Message = "Query 5: How many of the top 10 (# sold) titles are Valve games?";
            //SELECT TOP 10 Title, NA_Sales, EU_Sales, Japan_Sales, Other_Sales, Global_Sales  FROM VGSales_Table JOIN SteamSpy_Table ON VGSales_Table.Title = SteamSpy_Table.Title WHERE Publisher LIKE “Valve”;

            var query5 = (from Steamspy_Table in model.Steamspy_Table
                          join VGSales_Table in model.VGSales_Table on Steamspy_Table.Title equals VGSales_Table.Title
                          where VGSales_Table.Publisher.Contains("Valve")
                          orderby VGSales_Table.Global_Sales descending
                          select VGSales_Table).Take(10);

            List<VGSales_Table> VGList = query5.ToList();

            return View(VGList);
        }

        public ActionResult Q6()
        {

            RainerEntities model = new RainerEntities();
            ViewBag.Message = "Query 6:  What genre has sold the most copies?";
            //SELECT VGSales_Table.Genre, COUNT (VGSales_Table.Genre) AS Genre_Popularity, NA_Sales, EU_Sales, Japan_Sales, Other_Sales, Global_Sales  FROM VGSales_Table GROUP BY VGSales_Table.Genre ORDER BY Genre_Popularity DESC LIMIT 1;


            var query6 = (from VGSales_Table in model.VGSales_Table
                          //group vg.Genre by vg.Genre into Genre_Popularity
                          //orderby VGSales_Table.Genre.Count() descending
                          select VGSales_Table).Take(1);

                          //select VGSales_Table).GroupBy(VGSales_Table => VGSales_Table.Genre).Select(grp => new { Genre = grp.Key, Count = grp.Count() }).OrderBy(x => x.Genre);

            List<VGSales_Table> VGList = query6.ToList();

            return View(VGList);
        }

        public ActionResult Q7()
        {

            RainerEntities model = new RainerEntities();
            ViewBag.Message = "Query 7:  What PC games were released in March across all tables?";
            //SELECT IGN_Table.Title, Month From IGN_Table JOIN SteamSpy_Table ON IGN_Table.Title = SteamSpy_Table.Title JOIN VGsales_Table ON SteamSpy_Table.Title = VGSales_Table.Title WHERE Month = “5” AND IGN.Title = SteamSpy_Table.Title AND SteamSpy_Table.Title = VGSales_Table.Title;

            var query7 = (from IGN_Table in model.IGN_Table
                          join VGSales_Table in model.VGSales_Table on IGN_Table.Title equals VGSales_Table.Title
                          join Steamspy_Table in model.Steamspy_Table on VGSales_Table.Title equals Steamspy_Table.Title
                          where Steamspy_Table.Month == 3
                          select IGN_Table).Take(10);

            List<IGN_Table> IGNList = query7.ToList();

            return View(IGNList);
        }

        public ActionResult Q8()
        {

            RainerEntities model = new RainerEntities();
            ViewBag.Message = "Query 8: What is the Top 5  rated IGN  games sold ?";
            //SELECT * FROM IGN_Table ORDER BY Score LIMIT 5;

            var query8 = (from IGN_Table in model.IGN_Table
                          orderby IGN_Table.Score descending
                          select IGN_Table).Take(5);

            List<IGN_Table> IGNList = query8.ToList();

            return View(IGNList);
        }
        

    }
}