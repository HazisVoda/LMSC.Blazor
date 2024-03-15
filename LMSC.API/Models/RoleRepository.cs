using LMSC.Models;

namespace LMSC.API.Models
{
    public class RoleRepository : IRoleRepository
    {
        private readonly AppDbContext appDbContext;

        public RoleRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public IEnumerable<Role> GetRoles()
        {
            return appDbContext.Roles;
        }

        public Role GetRole(int roleId)
        {
            return appDbContext.Roles.FirstOrDefault(r => r.RoleID == roleId);
        }
    }
}
