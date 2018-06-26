using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MonsterDB.Models;
using MonsterDB.DAL;
using LinqToExcel;
using System.IO;
using System.Threading;

namespace MonsterDB.Controllers
{
    public class MonsterController : Controller
    {
        // Original context to premade database
        //private MonDBEntities db = new MonDBEntities();

        private MonsterContext db = new MonsterContext();


        // GET Import
        public ActionResult Import()
        {
            return View();
        }

        // POST Import
        // The main import page to import a .xls or .xlsx Excel file
        // And add its rows to the monster database 
        [HttpPost]
        public ActionResult Import(HttpPostedFileBase file)
        {
            // Currently only works with .xls files (xlxs if Excel is properly installed?)            
            if (file != null && file.ContentLength > 0 && 
               (file.FileName.EndsWith(".xls") || file.FileName.EndsWith(".xlsx")) )
            {
                // Getting file path of uploaded file with System.IO 
                string path = Path.Combine(Server.MapPath("~/App_Data/"),
                              Path.GetFileName(file.FileName));
                try
                {
                    /* Old file pathing            
                    string fileName = Path.GetFileName(file.FileName);
                    string targetPath = Server.MapPath("~/App_Data/");
                    file.SaveAs(targetPath + fileName);
                    string path = targetPath + fileName;
                    */
                    
                    file.SaveAs(path);
                    ViewBag.Message = "File uploaded successfully";

                    // LinqToExcel package to read Excel files
                    var excel = new ExcelQueryFactory();
                    excel.FileName = path;
                    var monsters = from x in excel.Worksheet<Monster>()
                                   select x;

                    // Iterating through read excel file and adding each row as a new monster
                    // into the monster database
                    foreach (var x in monsters)
                    {
                        Monster newMonster = new Monster();

                        newMonster.Monster_ID = x.Monster_ID;
                        newMonster.Monster_Name = x.Monster_Name;
                        newMonster.Monster_HP = x.Monster_HP;
                        newMonster.Monster_Race = x.Monster_Race;
                        newMonster.Monster_Property = x.Monster_Property;
                        db.Monsters.Add(newMonster);
                        db.SaveChanges();
                    }

                    // Delete the file from server after it has added entries to db
                    if (System.IO.File.Exists(path)) System.IO.File.Delete(path);
                    
                }
                catch (Exception ex)
                {
                    // If some other error, displays error message and deletes file from server
                    ViewBag.Message = "Error: " + ex.Message;
                    if (System.IO.File.Exists(path)) System.IO.File.Delete(path);
                    //return RedirectToAction("Index");
                }                

            }
            else if (file == null)
            {
                ViewBag.Message = "You have not specified a file";
            }
            else
            {
                ViewBag.Message = "Please input an Excel file";
            }
            
            //return RedirectToAction("Index");
            return View();
        }

        // GET: Monster
        /* Original Index method
        public ActionResult Index()
        {
            return View(db.Monsters.ToList());
        }
        */

        public ViewResult Index(string sortOrder, string searchString)
        {
            // Have sorting in columns controlled by hyperlink in column name
            ViewBag.IdSortParm = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
            ViewBag.NameSortParm = sortOrder == "name" ? "name_desc" : "name";
            ViewBag.HPSortParm = sortOrder == "hp" ? "hp_desc" : "hp";
            ViewBag.RaceSortParm = sortOrder == "race" ? "race_desc" : "race";
            ViewBag.PropertySortParm = sortOrder == "prop" ? "prop_desc" : "prop";

            var monsters = from s in db.Monsters
                           select s;

            // If something is in the search string, search in Name, Property, and Race columns
            if (!String.IsNullOrEmpty(searchString))
            {
                monsters = monsters.Where(s => s.Monster_Name.Contains(searchString)
                                        || s.Monster_Property.Contains(searchString)
                                        || s.Monster_Race.Contains(searchString));
            }

            switch (sortOrder)
            {
                // Name Sort
                case "name_desc":
                    monsters = monsters.OrderByDescending(s => s.Monster_Name); break;
                case "name":
                    monsters = monsters.OrderBy(s => s.Monster_Name); break;

                // HP Sort
                case "hp_desc":
                    monsters = monsters.OrderByDescending(s => s.Monster_HP); break;
                case "hp":
                    monsters = monsters.OrderBy(s => s.Monster_HP); break;               

                // Race Sort
                case "race_desc":
                    monsters = monsters.OrderByDescending(s => s.Monster_Race); break;
                case "race":
                    monsters = monsters.OrderBy(s => s.Monster_Race); break;

                // Property Sort
                case "prop_desc":
                    monsters = monsters.OrderByDescending(s => s.Monster_Property); break;
                case "prop":
                    monsters = monsters.OrderBy(s => s.Monster_Property); break;

                // ID sort and default
                case "id_desc":
                    monsters = monsters.OrderByDescending(s => s.Monster_ID);
                    break;
                default:
                    monsters = monsters.OrderBy(s => s.Monster_ID);
                    break;
            }

            return View(monsters.ToList());
        }




        // GET: Monster/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Monster monster = db.Monsters.Find(id);
            if (monster == null)
            {
                return HttpNotFound();
            }
            return View(monster);
        }

        // GET: Monster/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Monster/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Monster_ID,Monster_Name,Monster_HP,Monster_Race,Monster_Property")] Monster monster)
        {
            if (ModelState.IsValid)
            {
                db.Monsters.Add(monster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(monster);
        }

        // GET: Monster/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Monster monster = db.Monsters.Find(id);
            if (monster == null)
            {
                return HttpNotFound();
            }
            return View(monster);
        }

        // POST: Monster/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Monster_ID,Monster_Name,Monster_HP,Monster_Race,Monster_Property")] Monster monster)
        {
            if (ModelState.IsValid)
            {                
                db.Entry(monster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(monster);
        }

        // GET: Monster/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Monster monster = db.Monsters.Find(id);
            if (monster == null)
            {
                return HttpNotFound();
            }
            return View(monster);
        }

        // POST: Monster/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Monster monster = db.Monsters.Find(id);
            db.Monsters.Remove(monster);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
