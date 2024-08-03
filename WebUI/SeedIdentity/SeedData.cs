using EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;

namespace WebUI.SeedIdentity
{
	public static class SeedData
	{
		public static async Task Initialize(IServiceProvider serviceProvider)
		{
			var userManager = serviceProvider.GetRequiredService<UserManager<CustomUser>>();


			var userEmail = "admin@gmail.com";
			var user = await userManager.FindByEmailAsync(userEmail);

			if (user == null)
			{
				user = new CustomUser
				{
					UserName = "admin",
					Email = userEmail,
					Name = "Admin",
					Surname = "User",
					ImageUrl = "/images/UserImages/ffcad692-1a49-4902-9241-0a241399bf64.jpg"
				};

				var result = await userManager.CreateAsync(user, "123456Aa.");
				if (!result.Succeeded)
				{

					foreach (var error in result.Errors)
					{
						System.Diagnostics.Debug.WriteLine(error);
					}
				}
			}
		}
	}
}
