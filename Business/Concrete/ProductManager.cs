using Business.Abstract;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
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


        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            //ayni isimde urun eklenemez

             if (CheckIfProductCountofCategoryCorrect(product.CategoryId).Success)
            { 
             //busines code
            _productDal.Add(product);
             // return new Result(true,"urun eklendi"); yalnızca bu satiri yazamayiz constructor eklememiz lzm
             return new SuccessResult(Messages.ProductAdded);
            }
            return new ErrorResult();

        }

        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour == 18)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintananceTime);
            }
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductListed);    
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p=>p.CategoryId == id));   
        }

        public IDataResult<List<Product>> GetAllByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p=>p.UnitPrice<=min && p.UnitPrice<=max));
        }

        public IDataResult<Product> GetById(int prodctId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p=>p.ProductId==prodctId));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
           /* if(DateTime.Now.Hour == 16)
            {
                return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintananceTime);
            }*/
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Update(Product product)
        {
            //bir kategoride en fazla 10 urun olabilir
            var result = _productDal.GetAll(p => p.CategoryId == product.CategoryId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.ProductCountofCategoryError);
            }
            throw new NotImplementedException();
        }

        private IResult CheckIfProductCountofCategoryCorrect(int categoryId)
        {
            //select count(*) from products where categoryId=1
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.ProductCountofCategoryError);
            }
            return new SuccessResult();
        }
    }
}

