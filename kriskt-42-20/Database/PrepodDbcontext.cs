using Microsoft.EntityFrameworkCore;

namespace kriskt_42_20.Database
{
    public class PrepodDbcontext : DbContext
    {
        public PrepodDbcontext(DbContextOptions<PrepodDbcontext> options) : base(options)
        {
        }
    }
}
