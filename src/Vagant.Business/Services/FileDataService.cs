using System.Collections.Generic;
using System.Linq;
using Vagant.Domain.Entities;
using Vagant.Domain.Services;
using Vagant.Domain.UnitOfWork;

namespace Vagant.Business.Services
{
    public class FileDataService : IFileDataService
    {
        private readonly IAppUnitOfWork _uow;

        public FileDataService(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        public void Create(FileData entity)
        {
            var fileDataRepository = _uow.GetRepository<FileData>();
            fileDataRepository.Create(entity);
            _uow.Commit();
        }

        public IEnumerable<FileData> Get(IEnumerable<int> ids)
        {
            var fileDataRepository = _uow.GetRepository<FileData>();
            return fileDataRepository.Get(x => ids.Contains(x.Id));
        }

        public FileData Get(int id)
        {
            var fileDataRepository = _uow.GetRepository<FileData>();
            return fileDataRepository.GetByKey(id);
        }
    }
}
