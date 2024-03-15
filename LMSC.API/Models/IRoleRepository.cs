using LMSC.Models;

namespace LMSC.API.Models
{
    public interface IRoleRepository
    {
        IEnumerable<Role> GetRoles();
        Role GetRole(int roleId);
    }
}
