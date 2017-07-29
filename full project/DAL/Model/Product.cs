using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace full_project.DAL.Model
{
    public class Product:Address
    {
        public int ProductId { set; get; }
        public string ProductName { set; get; }
        public int Price { set; get; }
        public int Available { set; get; }
        public string ImageData { set; get; }
        public byte[] ImageDataBytes { set; get; }
        public int Quantity { set; get; }
    }
}