using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Dynamic;
using blender.Models;
using blender.features;

namespace blender.Models
{
    public class recipesController : Controller
    {
        private blenderEntities db = new blenderEntities();


        // GET: recipes
        public ActionResult Index()
        {
            var recipes = db.recipes.Include(r => r.skill_level1);
            List<_recipe> _recipes = new List<_recipe>();
            foreach (recipe recipe in recipes)
            {
                _recipes.Add(new _recipe(recipe));
            }
            return View(_recipes.ToList());
        }

        // GET: recipes/Details/5
        public ActionResult Details(int? id, int? serves)
        {
            //int servings = Int32.Parse(servs); // for scaling the recipe
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            recipe recipe = db.recipes.Find(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }

            _recipe _recipe = new _recipe(recipe);


            if (serves == null)
            {
                serves = _recipe.serves;
            }
            int servz = (int)serves;
            _recipe.scale(servz);

            ViewData["_requires"] = _recipe._requires;

            return View(_recipe);
        }

        // GET: recipes/Create
        public ActionResult Create()
        {
            ViewBag.skill_level = new SelectList(db.skill_level, "name", "name"); // gives me a list of skill levels
            ViewBag.categories = new SelectList(db.categories, "name", "name"); // gives me a select list of all categories
            ViewBag.ingredients = new SelectList(db.ingredients, "name", "name");
            ViewBag.units = new SelectList(db.units, "name", "name");
            _recipe _recipe = new _recipe(); // a _recipe model to carry all our recipe data
            return View(_recipe); // get the page based on this object model
        }

        // POST: recipes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = 
            "recipe_id,name,instructions,serves,prep_mins,cook_mins,calories," +
            "skill_level,categories,visual,_requires")] _recipe _recipe) // we get all the above specified data
        {
            if (ModelState.IsValid)
            {   // transform the _recipe transfer class into a real recipe w/ it's associations
                recipe recipe = new recipe(_recipe); 
                db.recipes.Add(recipe);
                db.SaveChanges(); // save it all
                return RedirectToAction("Index"); // let's go somewhere else
            }
            ViewBag.skill_level = new SelectList(db.skill_level, "name", "name"); // gives me a list of skill levels
            ViewBag.categories = new SelectList(db.categories, "name", "name"); // gives me a select list of all categories
            ViewBag.ingredients = new SelectList(db.ingredients, "name", "name");
            ViewBag.units = new SelectList(db.units, "name", "name");
            return View(_recipe);
        }

        // GET: recipes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            recipe recipe = db.recipes.Find(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            
            _recipe _recipe = new _recipe(recipe);
            ViewBag.skill_level = new SelectList(db.skill_level, "name", "name", recipe.skill_level);
            // this is how to get a list with pre-selected values on it
            ViewBag.categories = new MultiSelectList(db.categories.ToList(), "name", "name", _recipe.categories);
            ViewBag.ingredients = new SelectList(db.ingredients, "name", "name");
            ViewBag.units = new SelectList(db.units, "name", "name");
            return View(_recipe);
        }

        // POST: recipes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include =
            "recipe_id,name,instructions,serves,prep_mins,cook_mins,calories," +
            "skill_level,categories,image_url,_requires")] _recipe _recipe)
        {
            if (ModelState.IsValid)
            {   // so this is how we do it:
                recipe recipe = db.recipes.Find(_recipe.recipe_id); // grab the actual recipe from the database
                recipe.recipe_category.Clear(); // take out the object's categories and requires
                recipe.requires.Clear();
                recipe.update(_recipe); // update the entire recipe object from the _recipe transfer object

                // bellow we just make sure to eliminate any association tuples for the recipe
                // that are still in the database
                foreach (recipe_category recat in db.recipe_category.Where(rc => rc.recipe_id == _recipe.recipe_id))
                    { db.recipe_category.Remove(recat); }
                foreach (require req in db.requires.Where(r => r.recipe_id == _recipe.recipe_id))
                    { db.requires.Remove(req); }

                db.Entry(recipe).State = EntityState.Modified; // let the context know we changed stuff in the object representation
                db.SaveChanges(); // save it all
                return RedirectToAction("Index");
            }
            ViewBag.skill_level = new SelectList(db.skill_level, "name", "name");
            ViewBag.categories = new SelectList(db.categories, "name", "name");
            ViewBag.ingredients = new SelectList(db.ingredients, "name", "name");
            ViewBag.units = new SelectList(db.units, "name", "name");
            return View(_recipe);
        }

        // GET: recipes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            recipe recipe = db.recipes.Find(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }

            _recipe _recipe = new _recipe(recipe);

            ViewData["_requires"] = _recipe._requires;

            return View(_recipe);
        }

        // POST: recipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            recipe recipe = db.recipes.Find(id);
            db.recipes.Remove(recipe);
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
