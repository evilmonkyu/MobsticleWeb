using MobsticleWeb.Data;
using MobsticleWeb.Logic;
using MobsticleWeb.Models.Mobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MobsticleWeb.Controllers
{
    [Authorize]
    public class MobsController : Controller
    {
        private IUnitOfWork _uof;
        private MobLogic _mobLogic;

        public MobsController(IUnitOfWork uof, MobLogic mobLogic)
        {
            _uof = uof;
            _mobLogic = mobLogic;
        }

        [HttpGet]
        public ViewResult Index()
        {
            var model = new IndexModel
            {
                Mobs = _uof.Mobs.GetMobs(User.Identity.Name).ToList()
            };
            return View(model);
        }

        [HttpGet]
        public ViewResult New()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> New(MobModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ErrorMessages = ModelState.SelectMany(x => x.Value.Errors.Select(y => y.ErrorMessage));
                return View(model);
            }

            var result = await _mobLogic.AddMob(model.Name, User.Identity.Name);

            if (result.Count() > 0)
            {
                ViewBag.ErrorMessages = result;
                return View();
            }

            return RedirectToAction("Edit", model.Name);
        }
    }
}