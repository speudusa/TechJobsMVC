using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobsMVC.Models;
using TechJobsMVC.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsMVC.Controllers
{
    public class SearchController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.columns = ListController.ColumnChoices;
            return View();
        }
  
        public IActionResult Results(string searchType, string searchTerm)
        {
            List<Job> jobs;
            ViewBag.columns = ListController.ColumnChoices;

            if (string.IsNullOrEmpty(searchTerm))
            {
                jobs = JobData.FindAll();               
            }         
            else
            {
                jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
                ViewBag.title = "Jobs with " + ListController.ColumnChoices[searchType] + ": " + searchTerm;
            }
            ViewBag.jobs = jobs;

            return View("Index"); 
        }

    }
}
