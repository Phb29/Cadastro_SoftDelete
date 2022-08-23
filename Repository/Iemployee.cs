using CadastroSoftDelete.Models;

namespace CadastroSoftDelete.Repository
{
    public interface Iemployee
    {
        List<Employee> ListEmployee();
        Employee NewEmployee(Employee employee);
        Employee IdLoc(int? id);
        Employee Detail(int? id);
        Employee Remove(int? id);
        Employee Update(Employee employee); 
    }
}
