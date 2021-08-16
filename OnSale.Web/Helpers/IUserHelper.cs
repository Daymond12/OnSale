using Microsoft.AspNetCore.Identity;
using OnSale.Common.Enums;
using OnSale.Web.Data.Entities;
using OnSale.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnSale.Web.Helpers
{
    public interface IUserHelper
    {
        //mandamos el email y él retorna el usuario
        Task<User> GetUserAsync(string email);

        //sobrecarga de metodo GetUserAsync
        Task<User> GetUserAsync(Guid userId);

        //IdentityResult me dice si puso o no pudo agregar los usuarios,de no poder
        //me dice as razones porque
        Task<IdentityResult> AddUserAsync(User user, string password);

        //
        Task CheckRoleAsync(string roleName);

        //agregar a ese usuario ese rol
        Task AddUserToRoleAsync(User user, string roleName);

        Task<bool> IsUserInRoleAsync(User user, string roleName);

        Task<SignInResult> LoginAsync(LoginViewModel model);

        Task LogoutAsync();

        Task<SignInResult> ValidatePasswordAsync(User user, string password);

        Task<User> AddUserAsync(AddUserViewModel model, Guid imageId, UserType userType);

        //MÉTODOS PARA CAMBIAR EL PASSWWORD

        Task<IdentityResult> ChangePasswordAsync(User user, string oldPassword, string newPassword);

        Task<IdentityResult> UpdateUserAsync(User user);

        Task<string> GenerateEmailConfirmationTokenAsync(User user);

        Task<IdentityResult> ConfirmEmailAsync(User user, string token);


        //METODOS PARA RECUPERACIÓN DE PASSWORD
        Task<string> GeneratePasswordResetTokenAsync(User user);

        Task<IdentityResult> ResetPasswordAsync(User user, string token, string password);






    }

}
