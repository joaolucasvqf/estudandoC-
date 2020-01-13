using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MinhasTarefasAPI.Models;

namespace MinhasTarefasAPI.Database
{
    public class MinhasTarefasContext : IdentityDbContext<IdentityUser>
    {
        public MinhasTarefasContext(DbContextOptions<MinhasTarefasContext> options) : base(options)
        {

        }
        public Microsoft.EntityFrameworkCore.DbSet<Tarefa> Tarefas { get; set; }
    }
}
