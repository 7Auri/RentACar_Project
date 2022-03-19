using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.Constants
{
    public static class Messages
    {
        public static string SuccessAdd = "Ekleme başarılı";
        public static string ErrorAdd = "Ekleme başarısız";

        public static string SuccessDelete = "Silme başarılı";
        public static string ErrorDelete = "Silme başarısız";

        public static string SuccessUpdate = "Güncelleme başarılı";
        public static string ErrorUpdate = "Güncelleme başarısız";

        public static string SuccessListed = "Listeleme başarılı";
        public static string ErrorListed = "Listeleme başarısız";

        public static string BrandNameInvalid = "Marka adı geçersiz. En az 2 karakterli olmalı";
        public static string RentalCarNotAvailable = "Araba şu an başkasına hizmet vermektedir.";

    }
}
