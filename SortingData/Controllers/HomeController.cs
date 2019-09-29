using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SortingData.Controllers
{
    public class HomeController : Controller
    {
        [UseLayout("_BlankLayout")]
        public ActionResult Index()
        {
            //Populate list name from file
            var listName = System.IO.File.ReadLines("D:/KST/SortingData/name-sorter/unsorted-names-list.txt").ToList();
            var sortedData = SortedData(listName);
            ViewBag.SortedData = sortedData;

            string path = @"D:/KST/SortingData/name-sorter/sorted-names-list.txt";
            string sortedTextFile = String.Join("\n", sortedData);

            //Generate sorted file
            System.IO.File.WriteAllText(path, sortedTextFile);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public List<string> SortedData(List<string> inputList)
        {
            var sortedData = new List<string>();
            var sortedDataTemp = new List<string>();

            foreach (var data in inputList)
            {
                var dataArray = data.Split(' ');
                //Backwards name
                var backwardsName = string.Join(" ", dataArray.Reverse());
                sortedDataTemp.Add(backwardsName);
            }

            //Sort backwards name
            sortedDataTemp = sortedDataTemp.OrderBy(s => s).ToList();

            foreach (var data in sortedDataTemp)
            {
                var dataArray = data.Split(' ');
                //Forward name
                var forwardName = string.Join(" ", dataArray.Reverse());
                sortedData.Add(forwardName);
            }
            return sortedData;
        }
    }
}