﻿using Shop.Businness.Services.Interfaces;
using Shop.Core.Utilities.Results.Abstract;
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
        public async Task<IResult> CreateAsync(PostOrderDTO dto)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<GetOrderDTO>> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IResult> RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IResult> UpdateAsync(int id, PostOrderDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
