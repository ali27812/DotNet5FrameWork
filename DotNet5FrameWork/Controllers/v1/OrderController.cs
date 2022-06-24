////using Microsoft.AspNetCore.Mvc;
////using System;
////using System.Collections.Generic;
////using System.Linq;
////using System.Threading.Tasks;
//using AutoMapper;
//using Common.Exceptions;
//using Data.Contracts;
//using DotNet5FrameWork.Models;
//using Entites;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Services.Services;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading;
//using System.Threading.Tasks;
//using WebFramework.Api;
//using WebFramework.Filters;


//namespace DotNet5FrameWork.Controllers.v1
//{
//    //[ApiVersion("1")]
//    [Route("api/v1/[controller]")]// api/v1/test
//    public class OrderController : BaseController
//    {
//        private readonly IOrderRepository orderRepository;
//        private readonly IJwtService jwtService;
//        public OrderController(IOrderRepository orderRepository, IJwtService jwtService)
//        {
//            this.orderRepository = orderRepository;
//            this.jwtService = jwtService;
//        }

//        [HttpGet]
//        public virtual async Task<ApiResult<List<Order>>> Get(CancellationToken cancellationToken)
//        {
//            var orders = await orderRepository.TableNoTracking.ToListAsync(cancellationToken);
//            return Ok(orders);
//        }

//        [HttpPost]
//        [Route("GetById")]
//        public virtual async Task<ActionResult<List<Order>>> GetById(GetIdModel idModel, CancellationToken cancellationToken)
//        {
//            var order = await orderRepository.TableNoTracking.Where(t => t.IdOrder == idModel.Id).ToListAsync(cancellationToken);
//            if (order == null)
//                return NotFound();
//            return order;
//        }
//        [HttpPost]
//        [Route("GetBySpecialCode")]
//        public virtual async Task<ApiResult<Order>> GetBySpecialCode(GetSpecialCodeModel specialCodeModel, CancellationToken cancellationToken)
//        {
//            var order = await orderRepository.GetBySpecialCode(specialCodeModel.SpecialCode, cancellationToken);
//            if (order == null)
//                return NotFound();
//            return order;
//        }


//        [HttpPost]
//        [Route("CreateOrder")]
//        public virtual async Task<ApiResult<Order>> CreateOrder(OrderDto orderDto, CancellationToken cancellationToken)
//        {

//            //var order = Mapper.Map<Order>(orderDto);
//            var order = orderDto.ToEntity();
//            await orderRepository.AddAsync(order, cancellationToken);
//            return order;


//        }

//        [HttpPost]
//        [Route("UpdateOrderBySpecialCode")]
//        public virtual async Task<ApiResult> UpdateOrderBySpecialCode(OrderDto orderDto, CancellationToken cancellationToken)
//        {
//            var updateOrder = await orderRepository.GetBySpecialCode(orderDto.SpecialCode, cancellationToken);
//            //Mapper.Map(orderDto, updateOrder);
//            updateOrder = orderDto.ToEntity(updateOrder);
//            await orderRepository.UpdateAsync(updateOrder, cancellationToken);
//            return Ok();
//        }

//        [HttpDelete]
//        public virtual async Task<ApiResult> Delete(int id, CancellationToken cancellationToken)
//        {
//            var order = await orderRepository.GetByIdAsync(cancellationToken, id);
//            await orderRepository.DeleteAsync(order, cancellationToken);

//            return Ok();
//        }
//    }
//}
