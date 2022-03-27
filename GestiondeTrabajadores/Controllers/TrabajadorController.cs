using GestiondeTrabajadores.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;


namespace GestiondeTrabajadores.Controllers
{
    public class TrabajadorController : Controller
    {
        private readonly TrabajadoresPruebaContext _context;

        public TrabajadorController(TrabajadoresPruebaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();           
        }

        public async Task<IActionResult> Crear(int id)
        {
            List<Departamento> lstDepartamentos = null;

            lstDepartamentos = (from d in _context.Departamentos
                                select new Departamento
                                {
                                    Id = d.Id,
                                    NombreDepartamento = d.NombreDepartamento,
                                }).ToList();


            List<SelectListItem> selectListItems = lstDepartamentos.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.NombreDepartamento.ToString(),
                    Value = d.Id.ToString(),
                    Selected = false

                };
            });

            ViewBag.listaDepartamentos = selectListItems;
      
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> obtenerTodos()
        {
            var todos = await _context.Trabajadores.ToListAsync();
            return Json(new { data = todos });
        }


        [HttpPost]
        [ValidateAntiForgeryToken] // Segurity Form
        public async Task<IActionResult> Crear(Trabajadore trabajador)
        {
            if (ModelState.IsValid)
            {
                await _context.Trabajadores.AddAsync(trabajador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
                Console.WriteLine("Sleep for 2 seconds.");
                Console.WriteLine(trabajador);
                Thread.Sleep(9000);
            }
            ;
            Console.WriteLine("Sleep for 2 seconds.");
            Console.WriteLine(trabajador);
            Thread.Sleep(1000);

            return View(trabajador);

        }










        [HttpGet]
        public JsonResult GetProvincias(int IdDepa)
        {
           
            var provincias = _context.Provincia.Where(x => x.IdDepartamento== IdDepa).ToList();
            ViewBag.lstProvincias = provincias;
            return Json(provincias);            
        }

        public JsonResult GetDistritos(int IdProvincia)
        {

            var distritos = _context.Distritos.Where(x => x.IdProvincia == IdProvincia).ToList();
            return Json(distritos);
        }

        
    }
}
