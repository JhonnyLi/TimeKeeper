using Azure.Security.KeyVault.Secrets;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeKeeper.Data;
using TimeKeeper.Web.Models;

namespace TimeKeeper.Web.Data
{
    public class SeedData
    {
        private readonly SecretClient _secretClient;

        public SeedData(SecretClient secretClient)
        {
            _secretClient = secretClient;
        }

        public async Task Initialize(AppDbContext context, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            context.Database.EnsureCreated();

            await AddUsers(userManager, roleManager).ConfigureAwait(false);

            await AddCompanies(context).ConfigureAwait(false);
            
        }

        private async Task AddCompanies(AppDbContext context)
        {
            var company1 = new CompanyModel
            {
                Address = new AddressModel
                {
                    AddressModelId = Guid.NewGuid(),
                    City = "Tyresö",
                    Country = "Sweden",
                    County = "Stockholm",
                    PostCode = "135 49",
                    Street = "Funäsdalen 5"
                },
                CompanyModelId = Guid.NewGuid(),
                Contact = new PersonModel
                {
                    PersonModelId = Guid.NewGuid(),
                    FirstName = "Torgny",
                    LastName = "Mogren",
                    Email = "torgny@mogren.se",
                    Addresses = new List<AddressModel>(),
                    PhoneNumbers = new List<PhoneNumberModel>()
                },
                Name = "Dirty Deeds Inc",
                VatId = "123456789-0"
            };
            if (!context.Companies.Any(c => c.Name.Equals(company1.Name)))
            {
                await context.Companies.AddAsync(company1).ConfigureAwait(false);
                await context.SaveChangesAsync().ConfigureAwait(false);
            }

            var company2 = new CompanyModel
            {
                Address = new AddressModel
                {
                    AddressModelId = Guid.NewGuid(),
                    City = "Malmö",
                    Country = "Sweden",
                    County = "Skåne",
                    PostCode = "000 00",
                    Street = "Bakre ingången 3"
                },
                CompanyModelId = Guid.NewGuid(),
                Contact = new PersonModel
                {
                    PersonModelId = Guid.NewGuid(),
                    FirstName = "Kjell",
                    LastName = "Wallander",
                    Email = "kjell@wallander.se",
                    Addresses = new List<AddressModel>(),
                    PhoneNumbers = new List<PhoneNumberModel>()
                },
                Name = "Gansters Co",
                VatId = "098765432-1"
            };
            if (!context.Companies.Any(c => c.Name.Equals(company2.Name)))
            {
                await context.Companies.AddAsync(company2).ConfigureAwait(false);
                await context.SaveChangesAsync().ConfigureAwait(false);
            }
        }

        private async Task AddUsers(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            string adminRole = "Admin";
            string desc1 = "Administrators role";

            string userRole = "Member";
            string desc2 = "Members role";

            string adminSeed = _secretClient.GetSecret("SeedAdminEmail").Value.ToString();
            string adminPassword = _secretClient.GetSecret("SeedAdminPassword").Value.ToString();
            string adminName = _secretClient.GetSecret("SeedAdminName").Value.ToString();

            string userSeed = _secretClient.GetSecret("SeedUserEmail").Value.ToString();
            string userPassword = _secretClient.GetSecret("SeedUserPassword").Value.ToString();
            string userName = _secretClient.GetSecret("SeedAdminName").Value.ToString();

            if (await roleManager.FindByNameAsync(adminRole) == null)
            {
                await roleManager.CreateAsync(new AppRole(adminRole, desc1, DateTime.Now));
            }
            if (await roleManager.FindByNameAsync(userRole) == null)
            {
                await roleManager.CreateAsync(new AppRole(userRole, desc2, DateTime.Now));
            }

            if (await userManager.FindByNameAsync(adminSeed) == null)
            {
                var adminUser = new AppUser
                {
                    UserName = adminSeed,
                    Email = adminSeed,
                    FirstName = adminName,
                };

                var result = await userManager.CreateAsync(adminUser);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(adminUser, adminPassword);
                    await userManager.AddToRoleAsync(adminUser, adminRole);
                }
            }

            if (await userManager.FindByNameAsync(userSeed) == null)
            {
                var user = new AppUser
                {
                    UserName = userSeed,
                    Email = userSeed,
                    FirstName = userName,
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, userPassword);
                    await userManager.AddToRoleAsync(user, userRole);
                }
            }
        }
    }
}
