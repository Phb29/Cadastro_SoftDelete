
using Microsoft.EntityFrameworkCore;
using CadastroSoftDelete.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CadastroSoftDelete.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }


        


        public override int SaveChanges(){

            foreach (var entry in ChangeTracker.Entries())
            {
                //changeTracker.Entries ele serve pra vc tranfomar em update dele etc do banco
                var delete = entry.Entity;

                if(entry.State == EntityState.Deleted && delete is ISoftDelete){
                    entry.State = EntityState.Modified;
                    //EntityState Armazena Informação do Context do savechange
                    //

                    delete.GetType().GetProperty("RecStatus").SetValue(delete, 'D'); //busca uma propriedade especifica
                }
            }

            return base.SaveChanges();
        }
    }
}
