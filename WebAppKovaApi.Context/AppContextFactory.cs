using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace WebAppKovaApi.Context
{
    public class AppContextFactory : IDesignTimeDbContextFactory<AppContext>
    {
        public AppContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<AppContext>();
            optionBuilder.UseSqlServer(@"Server=(localdb)\MSSqlLocalDb;Database=AppTest;Integrated Security=True;Connect Timeout=30;Trusted_Connection=True;");
            return new AppContext(optionBuilder.Options);
        }
    }
}
