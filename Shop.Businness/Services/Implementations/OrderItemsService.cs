using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shop.Businness.Responses;
using Shop.Businness.Services.Interfaces;
using Shop.Core.Entities.Models;
using Shop.Core.Utilities.Results.Abstract;
using Shop.Core.Utilities.Results.Concrete.ErrorResults;
using Shop.Core.Utilities.Results.Concrete.SuccessResults;
using Shop.DataAccess.Repositories.Implementations;
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
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public OrderItemsService(IOrderItemRepository orderItemRepository, IProductRepository productRepository, IMapper mapper, IOrderRepository orderRepository)
        {
            _orderItemRepository = orderItemRepository;
            _productRepository = productRepository;
            _mapper = mapper;
            _orderRepository = orderRepository;
        }

        public async Task<List<GetOrderItemDTO>> GetAllAsync()
        {
            var orderItems = await _orderItemRepository.GetListAsync(x => !x.IsDeleted, include: x => x.Include(o => o.Product));
            return orderItems.Select(x => _mapper.Map<GetOrderItemDTO>(x)).ToList();
        }

        public async Task<IResult> CreateAsync(PostOrderItemDTO dto)
        {
            var product = await _productRepository.GetAsync(x => x.Id == dto.ProductId);
            if (product == null)
            {
                return new ErrorResult("Product not found");
            }

            // Siparişin (Order) ID'sini almak gerekebilir
            //var order = await _orderRepository.GetAsync(x => x.Id == dto.OrderId);
            //if (order == null)
            //{
            //    return new ErrorResult("Order not found");
            //}

            var orderItem = new OrderItem
            {
                ProductId = dto.ProductId,
                UnitPrice = product.Price, // Product Price kullanılarak ekleniyor
              //  OrderId = dto.OrderId,     // OrderId'yi ekliyoruz
            };

            await _orderItemRepository.AddAsync(orderItem);

            return new SuccessResult("OrderItem successfully created");
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
            _mapper.Map(dto, orderItem);
            await _orderItemRepository.UpdateAsync(orderItem);
            return new SuccessResult("Order item updated successfully");
        }
    }
}
