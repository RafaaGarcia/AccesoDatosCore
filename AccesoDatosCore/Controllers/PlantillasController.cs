using AccesoDatosCore.Models;
using AccesoDatosCore.Repositorys;
using Microsoft.AspNetCore.Mvc;

namespace AccesoDatosCore.Controllers
{
    public class PlantillasController : Controller
    {
        RepositoryPlantilla repo;
        public PlantillasController(RepositoryPlantilla repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            List<Plantilla> plantilla = this.repo.GetPlantilla();
            return View(plantilla);
        }
        [HttpPost]
        public IActionResult Index(string funcion)
        {
            List<Plantilla> plantilla = this.repo.GetPlantillaFuncion(funcion);
            return View(plantilla);
        }
        
    }
}
