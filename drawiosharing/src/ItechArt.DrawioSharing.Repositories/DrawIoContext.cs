using System.Data.Entity;

namespace ItechArt.DrawioSharing.Repositories
{
    public class DrawIoContext : DbContext
    {
        public DrawIoContext()
            : base("DBConnection")
        {

        }
    }
}