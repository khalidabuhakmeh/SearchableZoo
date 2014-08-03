using System.Linq;
using System.Web.Mvc;
using MvcFlash.Core.Extensions;
using PagedList;
using Raven.Client;
using SearchableZoo.Models;
using SearchableZoo.Models.Search;
using SearchableZoo.Models.ViewModels.Keepers;
using Keeper = SearchableZoo.Models.Objects.Keeper;

namespace SearchableZoo.Controllers
{
    public class KeepersController : ApplicationController
    {
        // GET: Keepers
        public ActionResult Index(SearchModel search)
        {
            using (var db = new ZooDbContext())
            {
                var model = new IndexModel(search);

                if (search.HasQuery)
                {
                    using (var session = MvcApplication.DocumentStore.OpenSession())
                    {
                        model.Keepers =
                        session.Query<KeeperIndex.Result, KeeperIndex>()
                            .OrderBy(x => x.KeeperId)
                            .Search(x => x.Search, model.Search.Query)
                            .AsProjection<KeeperViewModel>()
                            .ToPagedList(model.Search.Page, model.Search.Size);
                    }
                }
                else
                {
                    model.Keepers = db.Keepers
                        .OrderBy(x => x.Id)
                        .Select(x => new KeeperViewModel
                        {
                            KeeperId = x.Id,
                            FirstName = x.FirstName,
                            LastName = x.LastName,
                            Sex = x.Sex
                        }).ToPagedList(model.Search.Page, model.Search.Size);
                }
                return View(model);
            }
        }

        public ActionResult New()
        {
            return View(new EditModel());
        }

        public ActionResult Create(EditModel input)
        {
            if (ModelState.IsValid)
            {
                using (var db = new ZooDbContext())
                {
                    var keeper = new Keeper
                    {
                        FirstName = input.FirstName,
                        LastName = input.LastName,
                        Sex = input.Sex,
                        Speciality = input.Speciality,
                        YearsExperience = input.YearsExperience
                    };

                    db.Keepers.Add(keeper);
                    db.SaveChanges();
                }
                Flash.Success("Hooray!", "This one's a keeper!");
                return RedirectToAction("index");
            }

            return View("New", input);
        }

        public ActionResult Edit(int id)
        {
            using (var db = new ZooDbContext())
            {
                var keeper = db.Keepers.Find(id);
                var model = new EditModel(keeper);

                return View(model);
            }
        }

        public ActionResult Update(EditModel input)
        {
            if (ModelState.IsValid)
            {
                using (var db = new ZooDbContext())
                {
                    var keeper = db.Keepers.Find(input.Id);
                    keeper.FirstName = input.FirstName;
                    keeper.LastName = input.LastName;
                    keeper.Sex = input.Sex;
                    keeper.Speciality = input.Speciality;
                    keeper.YearsExperience = input.YearsExperience;
                    db.SaveChanges();
                }
                Flash.Success("Hooray!", "This one's a keeper!");
                return RedirectToAction("index");
            }

            return View("Edit", input);
        }

        public ActionResult Destroy(int id)
        {
            using (var db = new ZooDbContext())
            {
                var keeper = db.Keepers.Find(id);
                db.Keepers.Remove(keeper);
                db.SaveChanges();
            }

            Flash.Success("S'sad", "your keeper was successfully removed");
            return RedirectToAction("index");
        }
    }
}