using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnAspNet.Models;

namespace LearnAspNet.Services
{
    public class ProductService : List<ProductModel>
    {
        public ProductService(){
            this.AddRange(new ProductModel[]{
                new ProductModel(1,"Iphone 5",1000),
                new ProductModel(2,"Iphone 5",1200),
                new ProductModel(3,"Iphone 7",1400),
                new ProductModel(4,"Iphone 8",1600),
                new ProductModel(5,"Iphone X",1700),
            });
        }
    }
}