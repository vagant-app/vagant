using System.Collections.Generic;
using Vagant.Domain.Entities;

namespace Vagant.Domain.Services
{
    public interface IUserService
    {
        IEnumerable<ApplicationUser> GetAll();

        ApplicationUser GetById(string id);
    }
}
