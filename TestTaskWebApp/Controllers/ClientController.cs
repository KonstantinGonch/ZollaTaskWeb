using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestTaskWebApp.Models;

namespace TestTaskWebApp.Controllers
{
    public class ClientController : Controller
    {
        private static int ITEMS_PER_PAGE = 3;
        // GET: Client
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ClientList(int? pageNo)
		{
            int page = pageNo.HasValue ? (pageNo.Value > 0 ? pageNo.Value : 1) : 1;
            using(EntityContext ctx = new EntityContext())
			{
                IEnumerable<Client> clients = ctx.Clients.OrderBy(x => x.Name).Skip((page - 1) * ITEMS_PER_PAGE).Take(ITEMS_PER_PAGE).ToList();
               
                return View(clients);
			}
		}

        public ActionResult Details(int? id)
        {
            using (EntityContext ctx = new EntityContext())
            {
                Client c = ctx.Clients.FirstOrDefault(com => com.Id == id) ?? new Client();
                return PartialView(c);
            }
        }

        [HttpPost]
        public JsonResult Edit(Client client)
		{
            if (ModelState.IsValid)
            {
                if (client != null)
                {
                    using (EntityContext ctx = new EntityContext())
                    {
                        Client dbClient = ctx.Clients.FirstOrDefault(c => c.Id == client.Id);
                        if (dbClient != null)
                        {
                            dbClient.MapFromOther(client);
                        }
                        else
                        {
                            ctx.Clients.Add(client);
                        }
                        ctx.SaveChanges();
                        return Json(client);
                    }
                }
            }
            return Json(new { error = "true"});
		}

        public ActionResult Remove(int? id)
		{
            if (id.HasValue && id.Value > 0)
			{
                using(EntityContext ctx = new EntityContext())
				{
                    Client cl = ctx.Clients.FirstOrDefault(c => c.Id == id.Value);
                    if (cl != null)
					{
                        ctx.Clients.Remove(cl);
                        ctx.SaveChanges();
                        return Json(cl, JsonRequestBehavior.AllowGet);
					}
				}
			}
            return Json(new { error = "true" }, JsonRequestBehavior.AllowGet);
		}
    }
}