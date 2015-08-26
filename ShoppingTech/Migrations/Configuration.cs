using System.Security.Policy;
using System.Web.UI.WebControls;
using ShoppingTech.Models;

namespace ShoppingTech.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ShoppingTech.DAL.StoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ShoppingTech.DAL.StoreContext context)
        {           
            var pc = new Category { Name = "PC" };
            var laptop = new Category { Name = "Laptop" };
            var display = new Category { Name = "Display" };

            context.Categories.AddOrUpdate(
                c => c.CategoryId,
                pc,
                laptop,
                display
            );

            context.Products.AddOrUpdate(
                p => p.ProductId,
                new Product
                {
                    Category = pc,
                    Description = "Thiết kế nhỏ gọn, ấn tượng Acer Aspire TC703 Celeron J1900  được thiết kế nhỏ gọn với cấu hình mạnh, xử lý đồ họa và các tác vụ phức tạp tốt với ổ cứng lưu trữ 500GB thoải mái lưu trữ dữ liệu lớn nhưng vẫn đảm bảo tiết kiệm điện.",
                    DiscountPercent = 10,
                    ListPrice = 4889000,
                    Name = "ACER ASPIRE TC703 CELERON J1900",
                    ProductCode = "TC703",
                    ImageUrl = String.Format("~/Content/productimg/{0}", "TC703")
                },
                new Product
                {
                    Category = pc,
                    Description = "Máy tính để bàn Asus K30AD-VN017D được trang bị bộ xử lý Celeron G1840 tốc độ 2.8GHz, RAM 2GB DDR3. Với cấu hình này, CPU đáp ứng hiệu quả nhu cầu công việc mỗi ngày cũng như chạy đa nhiệm linh hoạt. Đặc biệt, chip đồ họa tích hợp bên trong bộ xử lý sẽ đem đến những khung hình sống động và sắc nét khi bạn giải trí và tiết kiệm điện năng tối ưu.",
                    DiscountPercent = 0,
                    ListPrice = 5299000,
                    Name = "ASUS K30AD-VN017D",
                    ProductCode = "K30ADVN017D",
                    ImageUrl = String.Format("~/Content/productimg/{0}", "K30ADVN017D")
                },
                new Product
                {
                    Category = pc,
                    Description = "Máy tính để bànLenovo H50-50-G3250 mang lại hiệu năng xử lý đa nhiệm linh hoạt khi được trang bị bộ xử lý Dual core, bộ nhớ RAM DDR3 tốc độ cao và ổ cứng dung lượng lớn 500GB. Máy không cài đặt sẵn hệ điều hành, nhờ đó bạn có thể cài đặt bất kỳ hệ điều hành nào mình yêu thích.",
                    DiscountPercent = 0,
                    ListPrice = 5999000,
                    Name = "LENOVO H50-50-G3250",
                    ProductCode = "H5050G3250",
                    ImageUrl = String.Format("~/Content/productimg/{0}", "H5050G3250")
                },
                new Product
                {
                    Category = pc,
                    Description = "Máy tính để bàn Dell Vostro 3900MTG1840 được thiết kế nhỏ gọn với cấu hình mạnh, xử lý đồ họa và các tác vụ phức tạp tốt với ổ cứng lưu trữ tới 500GB thoải mái lưu trữ dữ liệu lớn nhưng vẫn đảm bảo tiết kiệm điện.",
                    DiscountPercent = 10,
                    ListPrice = 4889000,
                    Name = "DELL VOSTRO 3900MTG1840",
                    ProductCode = "V3900MTG1840",
                    ImageUrl = String.Format("~/Content/productimg/{0}", "V3900MTG1840")
                },
                new Product
                {
                    Category = pc,
                    Description = "Máy tính để bàn  HP 280 G1 MT  sở hữu chip Pentium G3250 cho hiệu suất xử lý các tác vụ tạm ổn ứng dụng hỗ trợ công việc lẫn giải trí cá nhân.",
                    DiscountPercent = 10,
                    ListPrice = 6599000,
                    Name = "HP 280 G1 MT",
                    ProductCode = "HP280G1MT",
                    ImageUrl = String.Format("~/Content/productimg/{0}", "HP280G1MT")
                },
                new Product
                {
                    Category = pc,
                    Description = "Acer Aspire XC605-G32401T được thiết kế hiện đại với vẻ ngoải nhỏ gọn, đơn giản. Các nút điều khiển, các bộ phận của máy được bố trí hài hòa, hợp lý nhằm đáp ứng tối đa nhu cầu sử dụng.",
                    DiscountPercent = 10,
                    ListPrice = 6099000,
                    Name = "ACER ASPIRE XC605-G32401T",
                    ProductCode = "XC605G32401T",
                    ImageUrl = String.Format("~/Content/productimg/{0}", "XC605G32401T")
                },
                new Product
                {
                    Category = laptop,
                    Description = "Dell Inspiron N5548-M5I52652 sử dụng lớp vỏ bằng nhôm cho vẻ đẹp mạnh mẽ, chắc chắn. Đồng thời, các góc cạnh được bo tròn mềm mại mang đến một thiết kế tinh tế thẩm mĩ cao.",
                    DiscountPercent = 0,
                    ListPrice = 14999000,
                    Name = "DELL INSPIRON N5548-M5I52652",
                    ProductCode = "N5548_M5I52652",
                    ImageUrl = String.Format("~/Content/productimg/{0}", "N5548_M5I52652")
                },
                new Product
                {
                    Category = laptop,
                    Description = "Asus P550LDV-XO516HP sử dụng lớp vỏ nhám, chất liệu cao cấp chống bám dấu vân tay hiệu quả, giữ máy luôn tươm tất, sạch sẽ. Màu đen của máy sang trọng, thanh lịch phù hợp với đối tượng doanh nhân, đòi hỏi cao ở mặt thiết kế.",
                    DiscountPercent = 0,
                    ListPrice = 11999000,
                    Name = "ASUS P550LDV-XO516H",
                    ProductCode = "P550LDV-XO516H",
                    ImageUrl = String.Format("~/Content/productimg/{0}", "P550LDV-XO516H")
                },
                new Product
                {
                    Category = laptop,
                    Description = "HP 15-R208TU có thiết kế bo tròn ở các góc, màu sắc bạc sang trọng, bộ khung của máy được gia công chắc chắn đem đến cảm giác an tâm hơn khi sử dụng, tuy vậy nhưng trọng lượng của HP15-R020TU chỉ khoảng 2.2kg nên sẽ không gây nhiều khó khắn khi sử dụng cũng như di chuyển.",
                    DiscountPercent = 0,
                    ListPrice = 9499000,
                    Name = "HP 15-R208TU",
                    ProductCode = "HP15-R208TU",
                    ImageUrl = String.Format("~/Content/productimg/{0}", "HP15-R208TU")
                },
                new Product
                {
                    Category = laptop,
                    Description = "Lenovo G4070-59436675 có độ mỏng ấn tượng trong phân khúc máy tính tầm trung hiện nay. Mặt lưng với lớp sơn lì, không bóng, hạn chế bám dấu vân tay và vết bẩn. Các góc máy dù được bo tròn để máy trông gọn gàng hơn nhưng vẫn giữ được sự vuông vức, khá cổ điển và mạnh mẽ. Đồng thời, máy được vát mỏng về phía trước để máy có vẻ thanh mảnh hơn thực tế, mang đến cảm giác trẻ trung, năng động cho sản phẩm.",
                    DiscountPercent = 0,
                    ListPrice = 7999000,
                    Name = "LENOVO G4070-59436675",
                    ProductCode = "G4070_59436675",
                    ImageUrl = String.Format("~/Content/productimg/{0}", "G4070_59436675")
                },
                new Product
                {
                    Category = display,
                    Description = "Màn hình máy tính LED Dell E1914H có kích thước 18.5 inch mang đến khung hình rộng khi làm việc và giải trí. Độ phân giải hình ảnh 1366×768 pixel mang đến những hình ảnh sống động",
                    DiscountPercent = 10,
                    ListPrice = 1999000,
                    Name = "DELL E1914H",
                    ProductCode = "E1914H",
                    ImageUrl = String.Format("~/Content/productimg/{0}", "E1914H")
                },
                new Product
                {
                    Category = display,
                    Description = "Màn hình LED có kích thước 18.5 inch vừa đủ để làm việc, chơi game, xem phim. Màn hiển thị 16,7 triệu màu sống động cùng độ phân giải 1366x768 pixel",
                    DiscountPercent = 0,
                    ListPrice = 1499000,
                    Name = "LED SAMSUNG S19C300B",
                    ProductCode = "S19C300B",
                    ImageUrl = String.Format("~/Content/productimg/{0}", "S19C300B")
                },
                new Product
                {
                    Category = display,
                    Description = "Màn hình máy tính DELL Ultrasharp U2414H LED có kích thước 23.8 inch, đáp ứng đa dạng nhu cầu của người sử dụng về tính năng làm việc, giải trí.",
                    DiscountPercent = 0,
                    ListPrice = 5199000,
                    Name = "DELL ULTRASHARP U2414H LED",
                    ProductCode = "U2414H",
                    ImageUrl = String.Format("~/Content/productimg/{0}", "U2414H")
                },
                new Product
                {
                    Category = display,
                    Description = "Với màu đen bóng, màu chuyển tiếp màu đỏ trong suốt xung quanh màn hình và đường sạch sẽ, màn hình này có một thiết kế tinh xảo và hiện đại, chắc chắn sẽ tạo ấn tượng.",
                    DiscountPercent = 10,
                    ListPrice = 2999000,
                    Name = "SAMSUNG LS22D390HSXV",
                    ProductCode = "LS22D390HSXV",
                    ImageUrl = String.Format("~/Content/productimg/{0}", "LS22D390HSXV")
                }
            );
        }
    }
}
