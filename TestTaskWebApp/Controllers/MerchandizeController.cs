using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestTaskWebApp.Models;

namespace TestTaskWebApp.Controllers
{
    public class MerchandizeController : Controller
    {
        // GET: Merchandize
        public ActionResult ListItems(long? clientId)
        {
            if (clientId.HasValue && clientId.Value > 0)
			{
                using(EntityContext ctx = new EntityContext())
				{
                    Client client = ctx.Clients.Find(clientId);
                    if (client != null)
					{
                        IEnumerable<Merchandize> goods = ctx.Merchandize.Where(m => m.ClientId == client.Id).ToList();
                        MerchandizeListViewModel mlvm = new MerchandizeListViewModel() { ClientId = clientId.Value, Merchandize = goods };
                        return PartialView(mlvm);
					}
				}
			}
            return Json(new { error = "true" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Add(Merchandize merch)
		{
            if (merch != null)
			{
                using (EntityContext ctx = new EntityContext())
				{
                    ctx.Merchandize.Add(merch);
                    ctx.SaveChanges();
                    return Json(merch);
				}
			}
            return Json(new { error = "true" });
		}

        [HttpDelete]
        public ActionResult Remove(Merchandize merch)
		{
            if (merch != null)
			{
                using (EntityContext ctx = new EntityContext())
				{
                    ctx.Merchandize.Remove(merch);
                    ctx.SaveChanges();
				}
			}
            return Json(merch, JsonRequestBehavior.AllowGet);
		}

        public ActionResult Details(long? id, long? userId)
        {
            using (EntityContext ctx = new EntityContext())
            {
                Merchandize c = ctx.Merchandize.FirstOrDefault(com => com.Id == id) ?? new Merchandize();
                if (c.ClientId <= 0 && userId.HasValue)
                    c.ClientId = userId.Value;
                return PartialView(c);
            }
        }

        [HttpPost]
        public JsonResult Edit(Merchandize merch)
        {
            if (ModelState.IsValid)
            {
                if (merch != null)
                {
                    using (EntityContext ctx = new EntityContext())
                    {
                        Merchandize merchDb = ctx.Merchandize.FirstOrDefault(c => c.Id == merch.Id);
                        if (merchDb != null)
                        {
                            merchDb.Price = merch.Price;
                            merchDb.Name = merch.Name;
                        }
                        else
                        {
                            ctx.Merchandize.Add(merch);
                        }
                        ctx.SaveChanges();
                        return Json(merch);
                    }
                }
            }
            return Json(new { error = "true" });
        }
    }
}