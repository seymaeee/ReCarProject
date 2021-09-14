using Entities.Concrete;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
   public static class Messages
    {
        public static string CarAdded = "Araba Eklendi";
        public static string CarNameInvalid = "Araba ismi geçersiz.";
        public static string MaintenanceTime ="Sistem Bakımda";
        public static string CarsListed = "Arabalar listelendi";
        public static string CarNotRental = "Araba kiralanamaz";
        public static string CarRental = "Araba kiralanabilir";
        public static string CarDeleted = "Arabanın kaydı silindi";
        public static string CarUpdated = "Arabanın kaydı güncellendi";
        public static string CarNotAdded = "Araba Eklenemez";
        public static string CarImageLimit = "Max 5 resim yüklenebilir";
        public static string CarImageAdded = "Resim Yüklendi";
        public static string CarImagesListed = "Araba resimleri listelendi";
        public static string CarImagesNot = "Resim bulunmuyor";
    }
}
