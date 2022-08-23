using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CadastroSoftDelete.Data;

namespace CadastroSoftDelete.Controllers
{
    public class DeletedRecordController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DeletedRecordController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(){
            var deletedRecords = _context.Employees.Where(x=>x.RecStatus=='D').ToList();
            return View(deletedRecords);
        }

        public async Task<IActionResult> Recover(int id){
            var deletedRecord = _context.Employees.FirstOrDefault(x=>x.Id == id);
            deletedRecord.RecStatus = 'A';
            _context.Employees.Update(deletedRecord);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}