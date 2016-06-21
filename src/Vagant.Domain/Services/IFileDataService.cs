using System.Collections.Generic;
using Vagant.Domain.Entities;

namespace Vagant.Domain.Services
{
    public interface IFileDataService
    {
        void Create(FileData entity);

        FileData Get(int id);

        IEnumerable<FileData> Get(IEnumerable<int> ids);
    }
}
