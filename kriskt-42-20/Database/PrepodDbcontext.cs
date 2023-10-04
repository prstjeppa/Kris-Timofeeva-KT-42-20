using kriskt_42_20.Database.Configurations;
using kriskt_42_20.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace kriskt_42_20.Database
{
    public class PrepodDbcontext : DbContext
    {
        //Добавляем таблицы
        DbSet<Kafedra> Kafedra { get; set; }
        DbSet<Prepod> Prepod { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Добавляем конфигурации к таблицам
            modelBuilder.ApplyConfiguration(new PrepodConfiguration());
            modelBuilder.ApplyConfiguration(new KafedraConfiguration());
        }
        public PrepodDbcontext(DbContextOptions<PrepodDbcontext> options) : base(options)
        {
        }
    }
}
