using System.Collections.Generic;
using Vagant.Domain.Entities;
using Vagant.Domain.Services;
using Vagant.Domain.UnitOfWork;

namespace Vagant.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IAppUnitOfWork _uow;

        public UserService(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        public IEnumerable<ApplicationUser> GetAll()
        {
            var userRepository = _uow.GetRepository<ApplicationUser>();
            return userRepository.GetAll();
        }

        public ApplicationUser GetById(string id)
        {
            var userRepository = _uow.GetRepository<ApplicationUser>();
            return userRepository.GetByKey(id);
        }
    }
}
