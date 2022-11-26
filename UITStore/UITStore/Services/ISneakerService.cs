using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UITStore.Models;

namespace UITStore.Services
{
    public interface ISneakerService
    {
        Task<SneakerModel> GetSneaker();
        Task<ResponseUpdateSneaker> GetSneakerById(Guid id);
        Task<SneakerModel> SneakerFilter(int size, string type, string filter);
        Task<ResponseUpdateSneaker> UpdateSneaker(Sneakers sneakers);
    }
}
