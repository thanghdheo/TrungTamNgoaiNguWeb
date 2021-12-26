using Tour_MVC.Models;

namespace Tour_MVC.Repository
{
    public class Repository
    {
        public static bool SaveChanged(EnglishDbContext context)
        {
            try
            {
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
