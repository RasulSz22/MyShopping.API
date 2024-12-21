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
        GetOrderDTO GetOrderById(int id);
        GetOrderDTO CreateOrder(GetOrderDTO order);
        void UpdateOrder(int id, GetOrderDTO order);
        void DeleteOrder(int id);
    }

}
