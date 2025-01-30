using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Shop.Businness.Services.Interfaces;
using Shop.Core.Entities.Models;
using Shop.Core.Utilities.Results.Abstract;
using Shop.DataAccess.Repositories.Interfaces;
using Shop.DTO.CreateDTO;
using Shop.DTO.GetDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Businness.Services.Implementations
{
    public class OrderService : IOrderService
    {
        public Task Accept(int id)
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(PostOrderDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task Delivered(int id)
        {
            throw new NotImplementedException();
        }

        public Task<GetOrderDTO> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GetOrderDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task InProduction(int id)
        {
            throw new NotImplementedException();
        }

        public Task PreProduction(int id)
        {
            throw new NotImplementedException();
        }

        public Task Reject(int id)
        {
            throw new NotImplementedException();
        }

        public Task Shipped(int id)
        {
            throw new NotImplementedException();
        }

        public Task Success(int id)
        {
            throw new NotImplementedException();
        }
    }
}
