using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CadastroSoftDelete.Data;
using CadastroSoftDelete.Models;
using System.Diagnostics;
using CadastroSoftDelete.Repository;

namespace CadastroSoftDelete.Controllers{
    public class EmployeeController : Controller{
        private readonly ApplicationDbContext _context;
        private readonly Iemployee _employee;

        public EmployeeController(ApplicationDbContext context, Iemployee employee)
        {
            _context = context;
            _employee = employee;
        }

        public IActionResult Index(){
           // var employees = _context.Employees.Where(x=>x.RecStatus=='A').ToList();
            var employees=_employee.ListEmployee();
            return View(employees);
        }

        [HttpGet]
        public IActionResult New(){
            return View();
        }

        [HttpPost]
        public IActionResult New(Employee employee){
            try { 
            if (!ModelState.IsValid)
            {


                _employee.NewEmployee(employee);
                TempData["sucess"] = "Create Emploee sucess";



                return RedirectToAction("Index");
            }
                return View(employee);
            }
            
            catch(System.Exception erro)
            {
                TempData["Erro"] = $" Error Create {erro.Message}";
                return RedirectToAction("index");

            }
            



        }

        [HttpGet]
        public IActionResult Delete(int? id){

            _employee.Remove(id);
            return RedirectToAction("Index");
        }
        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
        public IActionResult Details(int? id)
        {
            var busca= _employee.Detail(id);
            return View(busca);

        }
        public IActionResult Update(int id)

        {
             var buscar = _employee.IdLoc(id);
            
            return View(buscar);
        }
        [HttpPost]
        public IActionResult Update(Employee employee)
        {
            if (ModelState.IsValid) { 
            _employee.Update(employee);
                TempData["MensagemSucesso"] = "Contato alterado com sucesso!";
                return RedirectToAction("Index");
            }
            return View(employee);

        }
    }
}
    
