using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult Add(Product product)
        {
            //business codes
            
            if(product.ProductName.Length<2)
            {
                return new ErrorResult("Urun ismi min 2 karakter olmalidir");
            }
            _productDal.Add(product);
            // return new Result(true,"urun eklendi"); yalnızca bu satiri yazamayiz constructor eklememiz lzm
            return new SuccessResult("urun eklendi");


        }

        public List<Product> GetAll()
        {
            return _productDal.GetAll();    
        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return _productDal.GetAll(p=>p.CategoryId == id);   
        }

        public List<Product> GetAllByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p=>p.UnitPrice<=min && p.UnitPrice<=max);
        }

        public Product GetById(int prodctId)
        {
            return _productDal.Get(p=>p.ProductId==prodctId);
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            return _productDal.GetProductDetails();
        }
    }
}
