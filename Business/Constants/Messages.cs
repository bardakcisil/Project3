using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
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

        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";

        public static string CategoryLimitExceded = "Kategori Limiti Aşıldığı için Yeni ürün eklenemedi";
        public static string AuthorizationDenied = "Yetkiniz yok.";
    }
}
//1.37.29