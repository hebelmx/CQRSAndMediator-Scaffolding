using Application.Persistence;

namespace TestApplication.Helpers
{
    public static class Utilities
    {
        public static void InitializeDbForTests(ApplicationDbContext db)
        {
            //add entities
            db.SaveChanges();
        }

        public static void ReinitializeDbForTests(ApplicationDbContext db)
        {
            // remove entities
            InitializeDbForTests(db);
        }
    }
}