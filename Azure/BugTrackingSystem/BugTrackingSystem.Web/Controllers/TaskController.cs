using System.Web.Mvc;
using BugTrackingSystem.Service.Models;
using BugTrackingSystem.Service.Services;

namespace BugTrackingSystem.Web.Controllers
{
    public class TaskController : Controller
    {
        private readonly IBugService _bugService;

        public TaskController(IBugService bugService)
        {
            _bugService = bugService;
        }
        //
        // GET: /Task/
        public ActionResult Task(int bugId = 1)
        {
            var info = _bugService.GetFullBugById(bugId);
            //_bugService.UpdateBugPriority(1, BugPriority.Critical);
            //_bugService.UpdateBugStatus(1, BugStatus.ToDo);
            return View(info);
        }
    }
}