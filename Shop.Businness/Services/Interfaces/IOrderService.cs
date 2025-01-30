using Shop.Core.Utilities.Results.Abstract;
using Shop.DTO.CreateDTO;
using Shop.DTO.GetDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Businness.Services.Interfaces
{
    public interface IOrderService
    {
        public Task CreateAsync(PostOrderDTO dto);
        public Task<IEnumerable<GetOrderDTO>> GetAll();
        public Task<GetOrderDTO> Get(int id);
        public Task Accept(int id);
        public Task Reject(int id);
        public Task Success(int id);
        public Task PreProduction(int id);
        public Task InProduction(int id);
        public Task Shipped(int id);
        public Task Delivered(int id);
    }

}
