
using OnlineShopBackOfficeApplication.Dtos.SaleAppDto.ProductCategoryAppDto;
using OnlineShopBackOfficeApplication.Services.Contracts;
using OnlineshopDmain.Aggregates.Sale;
using Onlineshope.RepositoryDesignPttern.Contracts;
using PublicTools.Resources;
using ResponseFramework;
using System.Net;


namespace OnlineShopBackOfficeApplication.Services.SaleServices
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductCategoryRepository _repository;
        public ProductCategoryService(IProductCategoryRepository repository)
        {
            _repository = repository;
        }

       
        public async Task<IResponse<GetProductCategoryAppDto>> Get(int id)
        {
            //------------
            if (id == null) return new Response<GetProductCategoryAppDto>(MessageResource.Error_TheParameterIsNull);
            if (id < 0 ) return new Response<GetProductCategoryAppDto>(MessageResource.Error_ThisFieldIsMandatory);
            //------------

            var Result = await _repository.FindByIdAsync(id);
            if (!Result.IsSuccess) return new Response<GetProductCategoryAppDto>(MessageResource.Error_FailProcess);
            //------------

            GetProductCategoryAppDto Selected = new GetProductCategoryAppDto()
            {
                Id = Result.Result.Id,
                Title = Result.Result.Title,
                ParentId = Result.Result.ParentId
            };

            return new Response<GetProductCategoryAppDto>(true, MessageResource.Info_SuccessfullProcess, string.Empty, Selected, HttpStatusCode.OK);
        }

        public async Task<IResponse<List<GetProductCategoryAppDto>>> GetAll()
        {
            var Result = await _repository.Select();


            if (!Result.IsSuccess) return new Response<List<GetProductCategoryAppDto>>(MessageResource.Error_FailProcess);
            //------------
            if (Result.Result == null) return new Response<List<GetProductCategoryAppDto>>(MessageResource.Error_FailProcess);
            //------------
            var productCategories = Result.Result.Select(item => new GetProductCategoryAppDto()
            {
                Id = item.Id,
                Title = item.Title,
                ParentId= item.ParentId

            }).ToList();


            return new Response<List<GetProductCategoryAppDto>>(true, MessageResource.Info_SuccessfullProcess, string.Empty, productCategories, HttpStatusCode.OK);
        }

        public async Task<IResponse<object>> Post(PostProductCategoryAppDto model)
        {
            //------------
            if (model == null) return new Response<object>(MessageResource.Error_ThisFieldIsMandatory);

            if (model.Title == null || model.Title == string.Empty) return new Response<object>(MessageResource.Error_ThisFieldIsMandatory);
        

            //------------
            var productCtegory = new ProductCategory()
            {
                        
                Title = model.Title,
                ParentId=model.ParentId               

            };
            var Result = await _repository.InsertAsync(productCtegory);
            if (!Result.IsSuccess) return new Response<object>(MessageResource.Error_FailProcess);
            
            //------------
            return new Response<object>(
                true, MessageResource.Info_SuccessfullProcess, string.Empty,
                new PostProductCategoryResultAppDto()
                {
                
                    Title = model.Title,
                    ParentId = model.ParentId

                }, HttpStatusCode.OK);
        }

        public async Task<IResponse<object>> Put(PutProductCategoryAppDto model)
        {
            //------------
            if (model == null) return new Response<object>(MessageResource.Error_ThisFieldIsMandatory);
            if (model.Title == null || model.Title == string.Empty) return new Response<object>(MessageResource.Error_ThisFieldIsMandatory);
         
            //------------
            var productCategory = new ProductCategory()
            {
                Id = model.Id,
                Title = model.Title,
                ParentId=model.ParentId

            };
            var Result = await _repository.UpdateAsync(productCategory);
            if (!Result.IsSuccess) return new Response<object>(MessageResource.Error_FailProcess);
            
           await _repository.SaveChanges();
            //------------
            return new Response<object>(
                true, MessageResource.Info_SuccessfullProcess, string.Empty,
                new PutProductCategoryResultAppDto()
                {
                    Id = model.Id,
                    Title = model.Title,
                   ParentId = model.ParentId
                }, HttpStatusCode.OK);
        }
        public async Task<IResponse<object>> Delete(DeleteProductCategoryAppDto model)
        {
            //------------
            if (model == null) return new Response<object>(MessageResource.Error_TheParameterIsNull);
            // اگر فرزند داشته باشد نباید پاک شود
            //------------

            var productCategory = new ProductCategory()
            {
                Id = model.Id
            };

            var Result = await _repository.DeleteAsync(productCategory);
            if (!Result.IsSuccess) return new Response<object>(MessageResource.Error_FailProcess);
            await _repository.SaveChanges();
            //------------
            return new Response<object>(
                true, MessageResource.Info_SuccessfullProcess, string.Empty,
                new DeleteProductCategoryResultAppDto()
                {
                    Id = model.Id
                }, HttpStatusCode.OK);
        }

   
    }
}
