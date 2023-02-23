using AccesoDatosCore.Models;
using AccesoDatosCore.Repositorys;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace AccesoDatosCore.Controllers
{
    public class EmpleadosController : Controller
    {
        RepositoryEmpleados repo;
        public EmpleadosController(RepositoryEmpleados repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            List<Empleado> Empleados = this.repo.GetEmpleados();
            return View(Empleados);
        }
        public IActionResult EmpleadosSalario()
        {   
            List<Empleado> empleados = repo.GetEmpleados();
            return View(empleados);
        }
        [HttpPost]
        public IActionResult EmpleadosSalario(int salario)
        {
            List<Empleado> empleados = repo.GetEmpleadosSalario(salario);
            return View(empleados);
        }
        public IActionResult Details(int idempleado)
        {
            Empleado empleado = this.repo.FindEmpleado(idempleado);
            return View(empleado);
        }
        public IActionResult IncrementarSalarioEmpleado()
        {
            List<Empleado> empleados = this.repo.GetEmpleados();
            ViewData["EMPELADOS"] = empleados;
            return View();
        }
        [HttpPost]
        public IActionResult IncrementarSalarioEmpleado(int idempleado, int incremento)
        {
            this.repo.IncrementarSalarioEmpleado(idempleado, incremento);
            Empleado empleado = this.repo.FindEmpleado(idempleado);
            List<Empleado> empleados = this.repo.GetEmpleados();
            ViewData["EMPLEADOS"] = empleados;
            return View(empleado);
        }

    }
}
