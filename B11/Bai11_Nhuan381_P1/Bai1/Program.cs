namespace Bai1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var brands = new List<Brand>() {
             new Brand{ID = 1, Name = "Vingroup"},
             new Brand{ID = 2, Name = "Samsung"},
             new Brand{ID = 3, Name = "FPT"},
            };
            var products = new List<Product>() {
             new Product(1,"O to", 400, new string[] {"Do","Trang","Den"}, 1),
             new Product(2,"Dien thoai",400, new string[] {"Den", "Xanh"}, 2),
             new Product(3,"May giat", 500, new string[] {"Trang"}, 2),
             new Product(4,"Tu lanh", 200, new string[] {"Trang", "Xam"}, 2),
             new Product(5,"Laptop", 300, new string[] {"Xam", "Den", "Do"}, 3),
             new Product(6,"Dieu hoa", 500, new string[] {"Trang"}, 2),
             new Product(7,"Xe may", 600, new string[] {"Trang"}, 1),
            };

            //var listProduct = from product in products select product;

            //var listProduct = products.Select(product => product);

            var listProduct = from product in products orderby product.Name ascending
                              select new
                              {
                                  ten = product.Name.ToUpper(),
                                  mausac = string.Join(',', product.Colors),
                              };

            //var listProduct = products.Select(product => new
            //{
            //    ten = product.Name.ToUpper(),
            //    mausac = string.Join(",", product.Colors),

            //});

            foreach (var product in listProduct)
            {
                Console.WriteLine(product.ten+" "+product.mausac);
            }




        }
    }
}