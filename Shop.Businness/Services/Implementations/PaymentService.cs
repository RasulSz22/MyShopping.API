﻿using AutoMapper;
using Shop.Businness.Services.Interfaces;
using Shop.Core.Entities.Enums;
using Shop.Core.Entities.Models;
using Shop.Core.Utilities.Results.Abstract;
using Shop.Core.Utilities.Results.Concrete.ErrorResults;
using Shop.Core.Utilities.Results.Concrete.SuccessResults;
using Shop.DataAccess.Repositories.Interfaces;
using Shop.DTO.GetDTO;
using Shop.DTO.PostDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Businness.Services.Implementations
{
    public class PaymentService : IPaymentService
    {
        public Task<IResult> CreateAsync(PostPaymentDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<GetPaymentDTO>> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> UpdateAsync(int id, PostPaymentDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}