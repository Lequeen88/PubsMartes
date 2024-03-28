using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PubsMartes.Application.Contract;
using PubsMartes.Application.Dtos.Jobs;

namespace PubsMartes.Web.Controllers
{
    public class JobController : Controller
    {
        private readonly IConsumeApiService _consumeApiService;

        public JobController(IConsumeApiService consumeApiService)
        {
            _consumeApiService = consumeApiService;
        }

        // GET: JobController
        public async Task<ActionResult> Index()
        {
            var result = await _consumeApiService.GetAllJobs();
            return View(result.data);
        }

        // GET: JobController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var job = await _consumeApiService.GetJobById(id);
            return View(job);
        }

        // GET: JobController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: JobController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(JobsDtoAdd model)
        {
            try
            {
                await _consumeApiService.CreateJob(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: JobController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var job = await _consumeApiService.GetJobById(id);
            return View(job);
        }

        // POST: JobController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, JobsDtoUpdate collection)
        {
            try
            {
                await _consumeApiService.EditJob(id, collection);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: JobController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var jobDelete = await _consumeApiService.GetDeleteModel(id);
            return View(jobDelete);
        }

        // POST: JobController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, JobDtoRemove collection)
        {
            try
            {
                collection.JobID = id;
                await _consumeApiService.Delete(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
