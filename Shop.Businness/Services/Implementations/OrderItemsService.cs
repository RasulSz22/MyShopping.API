using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shop.Businness.Responses;
using Shop.Businness.Services.Interfaces;
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
    public class OrderItemsService : IOrderItemsService
    {
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public OrderItemsService(IOrderItemRepository orderItemRepository, IProductRepository productRepository, IMapper mapper)
        {
            _orderItemRepository = orderItemRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<GetOrderItemDTO>> GetAllAsync()
        {
            var orderItems = await _orderItemRepository.GetListAsync(x => !x.IsDeleted, include: x => x.Include(o => o.Product));
            return orderItems.Select(x => _mapper.Map<GetOrderItemDTO>(x)).ToList();
        }

        public async Task<IResult> CreateAsync(PostOrderItemDTO dto)
        {
            var product = await _productRepository.GetAsync(p => p.Id == dto.OrderItems.ProductId && !p.IsDeleted);
            if (product == null)
            {
                return new ErrorResult($"Product with ID {dto.OrderItems.ProductId} not found.");
            }

            var orderItem = _mapper.Map<OrderItem>(dto.OrderItems);
            await _orderItemRepository.AddAsync(orderItem);
            return new SuccessResult("Order item successfully created");
        }

        public async Task<IDataResult<GetOrderItemDTO>> GetAsync(int id)
        {
            var orderItem = await _orderItemRepository.GetAsync(x => x.Id == id && !x.IsDeleted);
            if (orderItem == null)
            {
                return new ErrorDataResult<GetOrderItemDTO>("Order item not found");
            }
            var dto = _mapper.Map<GetOrderItemDTO>(orderItem);
            return new SuccessDataResult<GetOrderItemDTO>(dto, "Order item retrieved successfully");
        }

        public async Task<IResult> RemoveAsync(int id)
        {
            var orderItem = await _orderItemRepository.GetAsync(x => x.Id == id && !x.IsDeleted);
            if (orderItem == null)
            {
                return new ErrorResult("Order item not found");
            }
            orderItem.IsDeleted = true;
            await _orderItemRepository.UpdateAsync(orderItem);
            return new SuccessResult("Order item removed");
        }

        public async Task<IResult> UpdateAsync(int id, PostOrderItemDTO dto)
        {
            var orderItem = await _orderItemRepository.GetAsync(x => x.Id == id && !x.IsDeleted);
            if (orderItem == null)
            {
                return new ErrorResult("Order item not found");
            }
            _mapper.Map(dto.OrderItems, orderItem);
            await _orderItemRepository.UpdateAsync(orderItem);
            return new SuccessResult("Order item updated successfully");
        }
    }
}
