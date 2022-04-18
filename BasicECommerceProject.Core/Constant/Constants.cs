using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicECommerceProject.Core.Constant
{
    public static class Constants
    {
        public static Dictionary<StatusEnum, int> StatusEnumIds { get; set; } = new Dictionary<StatusEnum, int>();
        public enum StatusEnum
        {
            [Display(Description = "Bekleyen")] _1,
            [Display(Description = "Yeni")] _2,
            [Display(Description = "Paketlenen")] _3,
            [Display(Description = "Faturası Kesilen")] _4,
            [Display(Description = "Kargolanan")] _6,
            [Display(Description = "Teslim Edilen")] _7,
            [Display(Description = "Teslim Edilemeyen")] _8,
            [Display(Description = "Ödemesi Tamamlanan")] _10,
            [Display(Description = "İade Sürecinde Olan")] _11,
            [Display(Description = "İptal Olan")] _12,
            [Display(Description = "NoStatus")] _0,

        }
    }
}
