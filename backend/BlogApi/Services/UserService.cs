using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApi.DataModel.Interfaces;
using BlogApi.DataModel;
using Microsoft.AspNetCore.Identity;

namespace BlogApi.Services
{
    public class UserService : IUserService
    {
            private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IJWTAuthenticationManager _jwtAuthenticationManager;

    public UserService(UserManager<User> userManager, SignInManager<User> signInManager, IJWTAuthenticationManager jwtAuthenticationManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _jwtAuthenticationManager = jwtAuthenticationManager;
    }

    public async Task<User> Register(User user, string password)
    {
        var newUser = new User
        {
            Email = user.Email,
            DisplayName = user.DisplayName,
            Image = user.Image,
        };

        var result = await _userManager.CreateAsync(newUser, password);

        if (result.Succeeded)
        {
            return newUser;
        }
        else
        {
            throw new Exception(string.Join(", ", result.Errors.Select(x => x.Description)));
        }
    }

    public async Task<string> Authenticate(string email, string password)
    {
        var result = await _signInManager.PasswordSignInAsync(email, password, false, false);

        if (result.Succeeded)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.Email == email);
            return _jwtAuthenticationManager.Authenticate(user.DisplayName, password);
        }
        else
        {
            throw new Exception("Authentication failed");
        }
    }

    public async Task<User> Update(int id, User user)
    {
        var existingUser = await _userManager.FindByIdAsync(id.ToString());

        if (existingUser != null)
        {
            existingUser.Email = user.Email;
            existingUser.DisplayName = user.DisplayName;
            existingUser.Image = user.Image;

            var result = await _userManager.UpdateAsync(existingUser);

            if (result.Succeeded)
            {
                return existingUser;
            }
            else
            {
                throw new Exception(string.Join(", ", result.Errors.Select(x => x.Description)));
            }
        }
        else
        {
            throw new Exception("User not found");
        }
    }

    public async Task Delete(int id)
    {
        var user = await _userManager.FindByIdAsync(id.ToString());

        if (user != null)
        {
            var result = await _userManager.DeleteAsync(user);

            if (!result.Succeeded)
            {
                throw new Exception(string.Join(", ", result.Errors.Select(x => x.Description)));
            }
        }
        else
        {
            throw new Exception("User not found");
        }
    }
    }
}