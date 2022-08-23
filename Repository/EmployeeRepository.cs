using CadastroSoftDelete.Data;
using CadastroSoftDelete.Models;

namespace CadastroSoftDelete.Repository
{
    public class EmployeeRepository : Iemployee
    {
        ApplicationDbContext _context;
        public EmployeeRepository(ApplicationDbContext contex)
        {
            _context = contex;
        }

        public Employee IdLoc(int? id)
        {
            return _context.Employees.FirstOrDefault(x => x.Id == id);
        }

        public Employee Detail(int? id)
        {
            if(id == null)
            {
                throw new Exception("not found");
            }
            var busca = IdLoc(id);
            if (busca == null)
            {
                throw new Exception("not found");
            }
            return busca;
            
        }

        

        public List<Employee> ListEmployee()
        {
            return _context.Employees.Where(x => x.RecStatus == 'A').ToList();
//Lebrando que tem que ser assim relacionadno o Rectatus se não ele n exclui os 10 pimeiros
        }

        public Employee NewEmployee(Employee employee)
        {
            var nome = _context.Employees.SingleOrDefault(n => n.FirstName == employee.FirstName);
            if (nome != null)
            {
                 throw new Exception("Name Invalid");
            }
           _context.Employees.Add(employee);
            _context.SaveChanges();
            return employee;
        }

        public Employee Remove(int? id)
        {

            var delete =_context.Employees.FirstOrDefault(d => d.Id == id);
            _context.Remove(delete);
            _context.SaveChanges();
            return delete;
                 
        }

        public Employee Update(Employee employee)
        {
            var id=IdLoc(employee.Id);
            id.FirstName = employee.FirstName;
            id.LastName = employee.LastName;
            id.Age = employee.Age;
            _context.Update(id);
            _context.SaveChanges();
            return id;
        }
    }
}
