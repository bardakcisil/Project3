using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Urun Eklendi";
        public static string ProductNameInvalid = "Urun ismi gecersiz";
        public static string MaintananceTime = "Sistem bakımda";
        public static string ProductListed = "Urunler listelendi";
        public static string ProductCountofCategoryError="1 kategoride en fazla 10 urun olabilir";
        public static string ProductNameAlreadyExists="Bu isimde zaten başka bir ürün var";

        public static string CategoryLimitExceded = "Kategori Limiti Aşıldığı için Yeni ürün eklenemedi";
    }
}
//1.37.29