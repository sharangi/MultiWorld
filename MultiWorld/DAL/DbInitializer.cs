namespace MultiWorld.DAL
{
    public class DbInitializer
    {
        public static void Initialize(MultiWorldDbContext context)
        {
            context.Database.EnsureCreated();

            // Seed database with initial data here
        }
    }
}
