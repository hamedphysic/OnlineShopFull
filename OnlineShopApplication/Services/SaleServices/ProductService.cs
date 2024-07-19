using OnlineShopBackOfficeApplication.Dtos.SaleAppDto.ProductAppDto;
using OnlineShopBackOfficeApplication.Services.Contracts;
using OnlineshopDmain.Aggregates.Sale;
using PublicTools.Resources;
using ResponseFramework;
using System.Net;
using PublicTools.Tools;
using Onlineshope.RepositoryDesignPttern.Contracts;


namespace OnlineShopBackOfficeApplication.Services.SaleServices
{
    public class ProductService : IProductService
   {
       
        private readonly IProductRepository _repository;
          
   
        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }


        public async Task<IResponse<GetProductAppDto>> Get(Guid id)
        {
            //------------
            if (id == null) return new Response<GetProductAppDto>(MessageResource.Error_TheParameterIsNull);
            //------------

            var Result = await _repository.FindByIdAsync(id);
            if (!Result.IsSuccess) return new Response<GetProductAppDto>(MessageResource.Error_FailProcess);
            //------------

            GetProductAppDto Selected = new GetProductAppDto()
            {
                Id = Result.Result.Id,
                ProductCategoryId = Result.Result.ProductCategoryId,
                UnitPrice = Result.Result.UnitPrice,
                Code = Result.Result.Code,
                Title = Result.Result.Title,
                EntityDescription = Result.Result.EntityDescription,
                Pic=Result.Result.Pic,
                IsActive = Result.Result.IsActive,
                DateCreatedLatin = Result.Result.DateCreatedLatin,
                DateCreatedPersian = Result.Result.DateCreatedPersian,
                IsModified = Result.Result.IsModified,
                DateModifiedLatin = Result.Result.DateModifiedLatin,
                DateModifiedPersian = Result.Result.DateModifiedPersian,
                IsDeleted = Result.Result.IsDeleted,
                DateSoftDeletedLatin = Result.Result.DateSoftDeletedLatin,
                DateSoftDeletedPersian = Result.Result.DateSoftDeletedPersian
            };

            return new Response<GetProductAppDto>(true, MessageResource.Info_SuccessfullProcess, string.Empty, Selected, HttpStatusCode.OK);
        }

        public async Task<IResponse<List<GetProductAppDto>>> GetAll()
        {


            var Result = await _repository.Select();


            if (!Result.IsSuccess) return new Response<List<GetProductAppDto>>(MessageResource.Error_FailProcess);
            //------------
            if (Result.Result == null) return new Response<List<GetProductAppDto>>(MessageResource.Error_FailProcess);
            //------------
            var products = Result.Result.Select(item => new GetProductAppDto()
            {
                Id = item.Id,
                ProductCategoryId = item.ProductCategoryId,
                UnitPrice = item.UnitPrice,
                Code = item.Code,
                Title = item.Title,
                EntityDescription = item.EntityDescription,
                Pic=item.Pic,
                IsActive = item.IsActive,
                DateCreatedLatin = item.DateCreatedLatin,
                DateCreatedPersian = item.DateCreatedPersian,
                IsModified = item.IsModified,
                DateModifiedLatin = item.DateModifiedLatin,
                DateModifiedPersian = item.DateModifiedPersian,
                IsDeleted = item.IsDeleted,
                DateSoftDeletedLatin = item.DateSoftDeletedLatin,
                DateSoftDeletedPersian = item.DateSoftDeletedPersian

            }).ToList();


            return new Response<List<GetProductAppDto>>(true, MessageResource.Info_SuccessfullProcess, string.Empty, products, HttpStatusCode.OK);


        }
          

        public async Task<IResponse<object>> Post(PostProductAppDto model)
        {
            //------------
            if (model == null) return new Response<object>(MessageResource.Error_ThisFieldIsMandatory);
            if (model.Code == null || model.Code == string.Empty) return new Response<object>(MessageResource.Error_ThisFieldIsMandatory);
            if (model.Title == null || model.Title == string.Empty ) return new Response<object>(MessageResource.Error_ThisFieldIsMandatory);
            // chek product catgory later
            
            //------------
            var product = new Product()
            {
                Id = model.Id,
                ProductCategoryId = model.ProductCategoryId,
                UnitPrice = model.UnitPrice,
                Code = model.Code,
                Title = model.Title,
                EntityDescription = model.EntityDescription,
                Pic=model.Pic,
                DateCreatedLatin = DateTime.Now ,
                DateCreatedPersian = DateTime.Now.DateToPersian()              

            };
               var Result = await _repository.InsertAsync(product);

            if (!Result.IsSuccess) return new Response<object>(MessageResource.Error_FailProcess);
            //------------
            return new Response<object>(
                true,MessageResource.Info_SuccessfullProcess, string.Empty,
                new PostProductResultAppDto()
                {
                    Id = model.Id,
                    ProductCategoryId = model.ProductCategoryId,
                    UnitPrice = model.UnitPrice,
                    Code = model.Code,
                    Title = model.Title,
                    EntityDescription = model.EntityDescription,
                    Pic = model.Pic,
                    DateCreatedLatin = DateTime.Now,
                    DateCreatedPersian = DateTime.Now.DateToPersian()

                },HttpStatusCode.OK);
        }

        public async Task<IResponse<object>> Put(PutProductAppDto model)
        {
            //------------
            if (model == null) return new Response<object>(MessageResource.Error_ThisFieldIsMandatory);
            if (model.Code == null || model.Code == string.Empty) return new Response<object>(MessageResource.Error_ThisFieldIsMandatory);
            if (model.Title == null || model.Title == string.Empty) return new Response<object>(MessageResource.Error_ThisFieldIsMandatory);
            // chek product catgory later
            //------------

            var defultResultValue = await _repository.SelectForUpdateAsync(model.Id);
            if (!defultResultValue.IsSuccess) return new Response<object>(MessageResource.Error_FailProcess);

            var product = new Product()
            {
                Id = model.Id,
                ProductCategoryId = model.ProductCategoryId,
                UnitPrice = model.UnitPrice,
                Code = model.Code,
                Title = model.Title,
                EntityDescription = model.EntityDescription,
                Pic= model.Pic,
             //------ Mandate Put
                       
                IsModified = true,
                DateModifiedLatin = DateTime.Now,
                DateModifiedPersian = DateTime.Now.DateToPersian(),

                IsActive = defultResultValue.Result.IsActive,
                IsDeleted = defultResultValue.Result.IsDeleted,
                DateSoftDeletedLatin = defultResultValue.Result.DateSoftDeletedLatin,
                DateSoftDeletedPersian = defultResultValue.Result.DateSoftDeletedPersian,

                DateCreatedLatin = defultResultValue.Result.DateCreatedLatin,
                DateCreatedPersian = defultResultValue.Result.DateCreatedPersian
           


            };
            var Result = await _repository.UpdateAsync(product);

            if (!Result.IsSuccess) return new Response<object>(MessageResource.Error_FailProcess);
            //------------
            return new Response<object>(
                true, MessageResource.Info_SuccessfullProcess, string.Empty,
                new PutProductResultAppDto()
                {
                    Id = model.Id,
                    ProductCategoryId = model.ProductCategoryId,
                    UnitPrice = model.UnitPrice,
                    Code = model.Code,
                    Title = model.Title,
                    EntityDescription = model.EntityDescription,
                    IsModified = true,
                    DateModifiedLatin = DateTime.Now,
                    DateModifiedPersian = DateTime.Now.DateToPersian()
                }, HttpStatusCode.OK);
         

        }
        
        public async Task<IResponse<object>> Delete(DeleteProductAppDto model)
        {
            //------------
            if (model == null) return new Response<object>(MessageResource.Error_TheParameterIsNull);
      
            //------------
            var defultResultValue = await _repository.SelectForUpdateAsync(model.Id);
            if(!defultResultValue.IsSuccess) return new Response<object>(MessageResource.Error_FailProcess);
            //------------
            var product = new Product()
            {
                Id = model.Id,
                IsDeleted = true,
                DateSoftDeletedLatin = DateTime.Now,
                DateSoftDeletedPersian = DateTime.Now.DateToPersian(),
             
          
                //------ Mandate Put

                ProductCategoryId =defultResultValue.Result.ProductCategoryId,
                UnitPrice = defultResultValue.Result.UnitPrice,
                Code = defultResultValue.Result.Code,
                Title = defultResultValue.Result.Title,
                EntityDescription = defultResultValue.Result.EntityDescription,
                Pic = defultResultValue.Result.Pic,


                IsModified = defultResultValue.Result.IsModified,
                DateModifiedLatin = defultResultValue.Result.DateModifiedLatin,
                DateModifiedPersian = defultResultValue.Result.DateModifiedPersian,

                IsActive = defultResultValue.Result.IsActive,
                DateCreatedLatin = defultResultValue.Result.DateCreatedLatin,
                DateCreatedPersian = defultResultValue.Result.DateCreatedPersian



            };
            var Result = await _repository.UpdateAsync(product);
            if (!Result.IsSuccess) return new Response<object>(MessageResource.Error_FailProcess);
            //------------
            return new Response<object>(
                true, MessageResource.Info_SuccessfullProcess, string.Empty,
                new DeleteProductResultAppDto()
                {
                    Id = model.Id,
                    IsDeleted = true,
                    DateSoftDeletedLatin = DateTime.Now,
                    DateSoftDeletedPersian = DateTime.Now.DateToPersian()
                }, HttpStatusCode.OK);
        }

  
   
    }
}
