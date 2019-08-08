using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capa_Datos;
using Capa_Entidad;
using Capa_Negocio;

namespace CRUD.Controllers
{
    public class PersonaController : Controller
    {
        //
        // GET: /Persona/

        public ActionResult Index()
        {
            // FINALMENTE INSTANCIAMOS EL OBJETO QUE TRAE EL METODO
    

            List<Persona> listado = N_Persona.ObtenerPersona();

            return View(listado);
        }

        //
        // GET: /Persona/Details/5

        public ActionResult Details(int id)
        {
             Persona modelo = N_Persona.listarxId(id);
            return View(modelo);
        
        }

        //
        // GET: /Persona/Create

        public ActionResult Create()
        {
            return View("Create");
        }

        //
        // POST: /Persona/Create

        [HttpPost]
        public ActionResult Create(Persona request)
        {
            try
            {
                 N_Persona.RegistrarPersona(request);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Persona/Edit/5

        public ActionResult Edit(int id)
        {
            Persona modelo = N_Persona.listarxId(id);
            return View(modelo);
        }

        //
        // POST: /Persona/Edit/5

        [HttpPost]
        public ActionResult Edit(Persona request)
        {
            try
            {
                // TODO: Add update logic here
                N_Persona.ActualizarPersona(request);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Persona/Delete/5

        public ActionResult Delete(int id)
        {
            Persona modelo = N_Persona.listarxId(id);
            return View(modelo);
        }

        //
        // POST: /Persona/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                N_Persona.EliminiarPersona(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
