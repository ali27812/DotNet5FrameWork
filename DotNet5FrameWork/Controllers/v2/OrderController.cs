//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading;
//using System.Threading.Tasks;
//using DotNet5FrameWork.Models;
//using Data.Contracts;
//using Entites;
//using Microsoft.AspNetCore.Mvc;
//using Services.Services;
//using WebFramework.Api;

//namespace DotNet5FrameWork.Controllers.v2
//{
//    //[ApiVersion("2")]
//    [Route("api/v2/[controller]")]// api/v2/test
//    public class OrderController : v1.OrderController
//    {
//        public OrderController(IOrderRepository orderRepository, IJwtService jwtService) : base(orderRepository, jwtService)
//        {
//        }

//        public override Task<ApiResult<Order>> CreateOrder(OrderDto orderDto, CancellationToken cancellationToken)
//        {
//            return base.CreateOrder(orderDto, cancellationToken);
//        }

//        public override Task<ApiResult> Delete(int id, CancellationToken cancellationToken)
//        {
//            return base.Delete(id, cancellationToken);
//        }

//        public override Task<ApiResult<List<Order>>> Get(CancellationToken cancellationToken)
//        {
//            return base.Get(cancellationToken);
//        }

//        public override Task<ActionResult<List<Order>>> GetById(GetIdModel idModel, CancellationToken cancellationToken)
//        {
//            return base.GetById(idModel, cancellationToken);
//        }

//        public override Task<ApiResult<Order>> GetBySpecialCode(GetSpecialCodeModel specialCodeModel, CancellationToken cancellationToken)
//        {
//            return base.GetBySpecialCode(specialCodeModel, cancellationToken);
//        }

//        public override Task<ApiResult> UpdateOrderBySpecialCode(OrderDto orderDto, CancellationToken cancellationToken)
//        {
//            return base.UpdateOrderBySpecialCode(orderDto, cancellationToken);
//        }
//    }
//}
