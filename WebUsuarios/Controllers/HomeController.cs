using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UsuariosBLL;
using UsuariosBLL.Dto;

namespace WebUsuarios.Controllers
{
    public class HomeController : Controller
    {
        public void CargarViewBag()
        {
            SelectListItem opcionFemenino = new SelectListItem
            {
                Text = "Femenino",
                Value = "F"
            };

            SelectListItem opcionMasculino = new SelectListItem
            {
                Text = "Masculino",
                Value = "M"
            };

            List<SelectListItem> lista = new List<SelectListItem>();
            lista.Add(opcionFemenino);
            lista.Add(opcionMasculino);
            ViewBag.lst = lista;

        }

        public ActionResult Index()
        {
            Serviciosusuarios servicio = new Serviciosusuarios();
            var usuarios= servicio.findAll();

            return View(usuarios);
        }

        [HttpGet]
        public ActionResult Create()
        {
            CargarViewBag();
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(UsuarioDto usuario)
        {
            Serviciosusuarios servicio = new Serviciosusuarios();
           var ok= servicio.create(usuario);
            return RedirectToAction("Index");
           
        }
        
        public ActionResult Delete(string id)
        {
            Serviciosusuarios servicio = new Serviciosusuarios();
            var registro = servicio.find(id);
            var ok = servicio.delete(registro);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            Serviciosusuarios servicio = new Serviciosusuarios();
            var registro = servicio.find(id);
            ViewBag.fecha = registro.FechaNacimento.ToString("yyyy-MM-dd");
            CargarViewBag();
            return View(registro);
        }

        [HttpPost]
        public ActionResult Edit(UsuarioDto usuario)
        {
            Serviciosusuarios servicio = new Serviciosusuarios();
            var ok = servicio.edit(usuario);
            return RedirectToAction("Index");

        }
    }
}