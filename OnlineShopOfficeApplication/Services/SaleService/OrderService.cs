using OnlineShopOfficeApplication.Dtos.SaleAppDto.OrderAppDto;
using OnlineShopOfficeApplication.Services.Contracts;
using ResponseFramework;
using Onlineshope.RepositoryDesignPttern.Contracts;
using Microsoft.AspNetCore.Identity;
using OnlineshopDmain.Aggregates.UserManagment;
using OnlineshopDmain.Aggregates.Sale;
using PublicTools.Tools;
using PublicTools.Resources;
using Onlineshope.RepositoryDesignPttern.Frameworks.Abstracts;


namespace OnlineShopOfficeApplication.Services.SaleService
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly UserManager<OnlineShopUser> _userManager;

        public OrderService(IOrderRepository orderRepository, IProductRepository productRepository, UserManager<OnlineShopUser> userManager)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _userManager = userManager;
        }

        public async Task<IResponse<GetOrderAppDto>> Get(Guid id)
        {
            if (id == null) return new Response<GetOrderAppDto>(MessageResource.Error_TheParameterIsNull);
            var Result = await _orderRepository.FindOrderByIdAsync(id);
            if (!Result.IsSuccess) return new Response<GetOrderAppDto>(MessageResource.Error_FailProcess);

            var orderDetail = Result.Result.OrderDetails.Select(item => new OrderDetailDto()
            {
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                UnitPrice = item.UnitPrice,
                OrderHeaderId = Result.Result.Id

            }).ToList();


            var order = new GetOrderAppDto()
            {
                Id = Result.Result.Id,
                Code = Result.Result.Code,
                Title = Result.Result.Title,
                EntityDescription = Result.Result.EntityDescription,
                Seller = Result.Result.Seller,
                Buyer = Result.Result.Buyer,
                IsActive = Result.Result.IsActive,
                DateCreatedLatin = Result.Result.DateCreatedLatin,
                DateCreatedPersian = Result.Result.DateCreatedPersian,
                IsModified = Result.Result.IsModified,
                DateModifiedLatin = Result.Result.DateModifiedLatin,
                DateModifiedPersian = Result.Result.DateModifiedPersian,
                IsDeleted = Result.Result.IsDeleted,
                DateSoftDeletedLatin = Result.Result.DateSoftDeletedLatin,
                DateSoftDeletedPersian = Result.Result.DateSoftDeletedPersian,
                OrderDetails = orderDetail
            };

            return new Response<GetOrderAppDto>(order);
        }

        public async Task<IResponse<List<GetOrderAppDto>>> GetAll()
        {
            var Result = await _orderRepository.SelectAllOrder();
            if (!Result.IsSuccess) return new Response<List<GetOrderAppDto>>(MessageResource.Error_FailProcess);
            //------------
            if (Result.Result == null) return new Response<List<GetOrderAppDto>>(MessageResource.Error_FailProcess);

            var allOrder = new List<GetOrderAppDto>();
           
            foreach (var order in Result.Result!) 
            {
                var getOrder = new GetOrderAppDto
                {
                    Id = order.Id,
                    Code = order.Code,
                    Title = order.Title,
                    EntityDescription = order.EntityDescription,
                    Seller = order.Seller,
                    Buyer = order.Buyer,
                    IsActive = order.IsActive,
                    DateCreatedLatin = order.DateCreatedLatin,
                    DateCreatedPersian = order.DateCreatedPersian,
                    IsModified = order.IsModified,
                    DateModifiedLatin = order.DateModifiedLatin,
                    DateModifiedPersian = order.DateModifiedPersian,
                    IsDeleted = order.IsDeleted,
                    DateSoftDeletedLatin = order.DateSoftDeletedLatin,
                    DateSoftDeletedPersian = order.DateSoftDeletedPersian,
                    OrderDetails = []
                };
            
                foreach(var orderDetail in order.OrderDetails)
                {
                    var orderDetailRow = new OrderDetailDto
                    {
                        OrderHeaderId= orderDetail.OrderHeaderId,
                        ProductId= orderDetail.ProductId,
                        UnitPrice= orderDetail.UnitPrice,
                        Quantity= orderDetail.Quantity
                    };
                getOrder.OrderDetails.Add(orderDetailRow);
                }

                allOrder.Add(getOrder);
            }

            return new Response<List<GetOrderAppDto>>(allOrder);


        }

        public async Task<IResponse<object>> Post(PostOrderAppDto model)
        {

            if (model == null) return new Response<object>(MessageResource.Error_TheParameterIsNull);
            if (model.SellerId == null) return new Response<object>(MessageResource.Error_TheParameterIsNull);
            if (model.BuyerId == null) return new Response<object>(MessageResource.Error_TheParameterIsNull);
          
            var seller = await _userManager.FindByIdAsync(model.SellerId);
            if (seller==null) return new Response<object>(MessageResource.Error_FailProcess);
           
            var buyer = await _userManager.FindByIdAsync(model.BuyerId);
            if (buyer == null) return new Response<object>(MessageResource.Error_FailProcess);

            if(seller == buyer)  return new Response<object>(MessageResource.Error_FailProcess); 

            Guid id = Guid.NewGuid();
            var orderDetail = model.OrderDetails.Select(item => new OrderDetail()
            {
            ProductId = item.ProductId,
            Quantity = item.Quantity,
            UnitPrice = item.UnitPrice,
            OrderHeaderId =id
            
            }).ToList();

            var order = new OrderHeader 
            { 
                Id =id,
                Code = model.Code,
                Title = model.Title,
                EntityDescription = model.EntityDescription,
                DateCreatedLatin = DateTime.Now,
                DateCreatedPersian = DateTime.Now.DateToPersian(),
                SellerId=model.SellerId,
                BuyerId=model.BuyerId  ,
                OrderDetails = orderDetail
                // OrderDetails = []
            };

            //foreach(var orderDetail in model.OrderDetails)
            //{
            //    var orderDetaiRow = new OrderDetail
            //    {
            //        OrderHeaderId=id,
            //        Quantity = orderDetail.Quantity,
            //        UnitPrice = orderDetail.UnitPrice,
            //        ProductId = orderDetail.ProductId
            //    };
            //    order.OrderDetails.Add(orderDetaiRow);
            //}

            var Result = await _orderRepository.InsertAsync(order);
            if (!Result.IsSuccess) return new Response<object>(MessageResource.Error_FailProcess);
            return new Response<object>(Result);



        }

        public async Task<IResponse<object>> Put(PutOrderAppDto model)
        {



            if (model == null) return new Response<object>(MessageResource.Error_TheParameterIsNull);
            if (model.SellerId == null) return new Response<object>(MessageResource.Error_TheParameterIsNull);
            if (model.BuyerId == null) return new Response<object>(MessageResource.Error_TheParameterIsNull);

            var seller = await _userManager.FindByIdAsync(model.SellerId);
            if (seller == null) return new Response<object>(MessageResource.Error_FailProcess);

            var buyer = await _userManager.FindByIdAsync(model.BuyerId);
            if (buyer == null) return new Response<object>(MessageResource.Error_FailProcess);

            if (seller == buyer) return new Response<object>(MessageResource.Error_FailProcess);



            var Result = await _orderRepository.FindOrderByIdAsync(model.Id);

            if (!Result.IsSuccess) return new Response<object>(MessageResource.Error_FailProcess);

            var updatedOrder = Result.Result;
            var oldOrder = Result.Result;


            updatedOrder!.Code = model.Code;
            updatedOrder!.BuyerId = model.BuyerId;
            updatedOrder!.SellerId = model.SellerId;
            updatedOrder.Title = model.Title;
            updatedOrder!.EntityDescription = model.EntityDescription;
            updatedOrder!.IsModified = true;
            updatedOrder!.DateModifiedLatin= DateTime.Now;
            updatedOrder!.DateModifiedPersian = DateTime.Now.DateToPersian();
        

     
          
            await _orderRepository.ClearAllOrderDetail(updatedOrder);
           
            var updatedorderDetail = model.OrderDetails.Select(item => new OrderDetail()
            {
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                UnitPrice = item.UnitPrice,
                OrderHeaderId = model.Id

            }).ToList();
            updatedOrder.OrderDetails = updatedorderDetail;
           
            await _orderRepository.CreateAllOrderDetail(updatedOrder);
                  

           
            var update = await _orderRepository.UpdateAsync(updatedOrder);
           // await _orderRepository.SaveChanges();
            return new Response<object>(model);


      
        }
        public async Task<IResponse<object>> Delete(DeleteOrderAppDto model)
        {
            if (model == null) return new Response<object>(MessageResource.Error_TheParameterIsNull);
            var Result = await _orderRepository.FindOrderByIdAsync(model.Id);

            //------------
            if (!Result.IsSuccess) return new Response<object>(MessageResource.Error_FailProcess);


            var deletedOrder = Result.Result;
            deletedOrder.IsDeleted = true;
            deletedOrder.DateSoftDeletedLatin = DateTime.Now;
            deletedOrder.DateSoftDeletedPersian = DateTime.Now.DateToPersian();

            var update = await _orderRepository.UpdateAsync(deletedOrder);
                        
            return new Response<object>(update);
        }

    }
}
