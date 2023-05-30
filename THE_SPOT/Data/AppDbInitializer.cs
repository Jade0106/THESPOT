using THE_SPOT.Models;
using Microsoft.AspNetCore.Identity;
using THE_SPOT.Data.Static;

namespace THE_SPOT.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            //using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            //{
            //    var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

            //    context.Database.EnsureCreated();

            //    if (!context..Any())
            //    {
            //        context.Brand.AddRange(new List<Brand>()
            //        {
            //            new Brand()
            //            {
            //                Name = "Apple",
            //                //Logo = "http://dotnethow.net/images/Brands/Brand-1.jpeg",
            //                //Description = "This is the description of the first Brand"
            //            },
            //            new Brand()
            //            {
            //                Name = "Samsung",
            //                //Logo = "http://dotnethow.net/images/Brands/Brand-2.jpeg",
            //                //Description = "This is the description of the first Brand"
            //            },
            //            new Brand()
            //            {
            //                Name = "Huawei",
            //                //Logo = "http://dotnethow.net/images/Brands/Brand-3.jpeg",
            //                //Description = "This is the description of the first Brand"
            //            },

            //        });
            //        context.SaveChanges();
            //    }

            //    if (!context.Product.Any())
            //    {
            //        context.Product.AddRange(new List<Product>()
            //        {
            //            new Product()
            //            {
            //                Name = "Iphone 11",
            //                Description = "This is the Life movie description",
            //                Price = 11000.00,
            //                ImageURL = "https://www.bing.com/images/blob?bcid=RL8yUwplKpgFaw",
            //                BrandId = 3,
            //                //BrandId = 3,
            //                //ProducerId = 3,
            //                Category = Category.Phones
            //            },
            //            new Product()
            //            {
            //                Name = "Pink Watch",
            //                Description = "This is the Shawshank Redemption description",
            //                Price = 629.50,
            //                ImageURL = "https://www.bing.com/images/blob?bcid=RKWBJKBVFJgFqA",
            //                BrandId =  1,
            //                //EndDate = DateTime.Now.AddDays(3),
            //                //BrandId = 1,
            //                //ProducerId = 1,
            //                Category = Category.Watches
            //            },
            //            new Product()
            //            {
            //                Name = "Iphone12",
            //                Description = "This is the Ghost movie description",
            //                Price = 1239.50,
            //                ImageURL = "https://www.bing.com/images/blob?bcid=RHydejkHQ6AFAA",
            //                BrandId = 2,
            //                //EndDate = DateTime.Now.AddDays(7),
            //                //BrandId = 4,
            //                //ProducerId = 4,
            //                Category = Category.Phones
            //            },
            //            new Product()
            //            {
            //                Name = "Iphone 10",
            //                Description = "This is the Race movie description",
            //                Price = 1239.50,
            //                ImageURL = "https://www.bing.com/images/blob?bcid=RM4g6UzLWKAFvw",
            //                BrandId = 3,
            //                //EndDate = DateTime.Now.AddDays(-5),
            //                //BrandId = 1,
            //                //ProducerId = 2,
            //                Category = Category.Phones
            //            },
            //            new Product()
            //            {
            //                Name = "Black Watch",
            //                Description = "This is the Scoob movie description",
            //                Price = 939.50,
            //                ImageURL = "https://www.bing.com/images/blob?bcid=RHtZAOap15gF7g",
            //                BrandId = 3,
            //                //EndDate = DateTime.Now.AddDays(-2),
            //                //BrandId = 1,
            //                //ProducerId = 3,
            //                Category = Category.Watches
            //            },
            //            new Product()
            //            {
            //                Name = "Heavy Watch",
            //                Description = "This is the Cold Soles movie description",
            //                Price = 739.50,
            //                ImageURL = "https://www.bing.com/images/blob?bcid=RIw13mo5PaAFJA",
            //                BrandId = 1,
            //                //EndDate = DateTime.Now.AddDays(20),
            //                //BrandId = 1,
            //                ////ProducerId = 5,
            //                Category = Category.Watches
            //            },
            //             new Product()
            //            {
            //                Name = "Iphone 13",
            //                Description = "This is the Cold Soles movie description",
            //                Price = 739.50,
            //                ImageURL = "https://www.bing.com/images/blob?bcid=RJqgYqU3g5gFjg",
            //                BrandId = 2,
            //                //EndDate = DateTime.Now.AddDays(20),
            //                //BrandId = 1,
            //                //ProducerId = 5,
            //                Category = Category.Phones
            //            },
            //             new Product()
            //            {
            //                Name = "Iphone 14",
            //                Description = "This is the Cold Soles movie description",
            //                Price = 1739.50,
            //                ImageURL = "https://www.bing.com/images/blob?bcid=RHEh0sXZNZgFyA",
            //                BrandId = 2,
            //                //EndDate = DateTime.Now.AddDays(20),
            //                //BrandId = 1,
            //                //ProducerId = 5,
            //                Category = Category.Phones
            //            },
            //             new Product()
            //            {
            //                Name = "Spotted Watch",
            //                Description = "This is the Cold Soles movie description",
            //                Price = 539.50,
            //                ImageURL = "https://www.bing.com/images/blob?bcid=RN5qEHfjCJgFjg",
            //                BrandId = 3,
            //                //EndDate = DateTime.Now.AddDays(20),
            //                //BrandId = 1,
            //                //ProducerId = 5,
            //                Category = Category.Watches
            //            }

            //        });
            //        context.SaveChanges();
            //        }
            //    }
        }
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));
                if (!await roleManager.RoleExistsAsync(UserRoles.DepartmentEmp))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.DepartmentEmp));
                if (!await roleManager.RoleExistsAsync(UserRoles.PurchasingEmp))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.PurchasingEmp));
                if (!await roleManager.RoleExistsAsync(UserRoles.SalesEmp)) // Add this line
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.SalesEmp));
                if (!await roleManager.RoleExistsAsync(UserRoles.StockControlEmp)) // Add this line
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.StockControlEmp));


                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@gmail.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {

                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Password@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

                string departmentEmpEmail = "deptEmployee@gmail.com";
                var departmentEmp = await userManager.FindByEmailAsync(departmentEmpEmail);
                if (departmentEmp == null)
                {
                    var newDepartmentEmp = new ApplicationUser()
                    {
                        UserName = "deptEmployee@gmail.com",
                        Email = departmentEmpEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newDepartmentEmp, "Password@1234?");
                    await userManager.AddToRoleAsync(newDepartmentEmp, UserRoles.DepartmentEmp);
                }

                string purchasingEmpEmail = "purchasingEmp@gmail.com";
                var purchasingEmp = await userManager.FindByEmailAsync(purchasingEmpEmail);
                if (purchasingEmp == null)
                {
                    var newPurchasingEmp = new ApplicationUser()
                    {

                        UserName = "purchasingEmp@gmail.com",
                        Email = purchasingEmpEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newPurchasingEmp, "Password@1234?");
                    await userManager.AddToRoleAsync(newPurchasingEmp, UserRoles.PurchasingEmp);
                }


                string salesEmpEmail = "salesEmp@gmail.com";
                var salesEmp = await userManager.FindByEmailAsync(salesEmpEmail);
                if (salesEmp == null)
                {
                    var newSalesEmp = new ApplicationUser()
                    {

                        UserName = "salesEmp@gmail.com",
                        Email = salesEmpEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newSalesEmp, "Password@1234?");
                    await userManager.AddToRoleAsync(newSalesEmp, UserRoles.SalesEmp);
                }

                string stockControlEmpEmail = "stockControlEmp@gmail.com";
                var stockControlEmp = await userManager.FindByEmailAsync(stockControlEmpEmail);
                if (stockControlEmp == null)
                {
                    var newStockControlEmp = new ApplicationUser()
                    {

                        UserName = "stockControlEmp@gmail.com",
                        Email = stockControlEmpEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newStockControlEmp, "Password@1234?");
                    await userManager.AddToRoleAsync(newStockControlEmp, UserRoles.StockControlEmp);
                }

                string appUserEmail = "user@gmail.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        //FirstName ="",
                        //LastName = "",
                        //Suburb = "",
                        //City = "",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Password@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}
