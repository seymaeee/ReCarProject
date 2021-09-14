using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public class DefaultImage
    {
        public static string DefaultImageFolder = $"{Directory.GetParent(Directory.GetCurrentDirectory())}\\WebAPI\\Images\\";
        public static string DefaultPicture = $"{DefaultImageFolder}defaultLogo.jpg";
    }
}
