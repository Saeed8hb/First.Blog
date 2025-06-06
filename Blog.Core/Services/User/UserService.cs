using Blog.DataLayer.Entities;
using CodeYad_Blog.CoreLayer.Utilities;
using CoreLayer.DTOs.User;
using CoreLayer.Utilities;
using DataLayer.Context;
using System;
using System.Linq;

namespace CoreLayer.Services.User
{
    public class UserService : IUserService
    {
        private readonly BlogContext _context;
        public UserService(BlogContext context)
        {
            _context = context;
        }

        public OperationResult LoginUser(UserLoginDto loginDto)
        {
            var passwordHashed = loginDto.Password.EncodeToMd5();
            var isUserExist = _context.Users.Any(u => u.UserName == loginDto.UserName && u.Password == passwordHashed);
            if (!isUserExist)
                return OperationResult.NotFound("کاربری یافت نشد");
            return OperationResult.Success("ورود با موفقیت انجام شد");
        }

        public OperationResult Register(UserRegisterDto registerDto)
        {
            var isUserExist = _context.Users.Any(u => u.UserName == registerDto.UserName || u.FullName == registerDto.FullName);

            if (isUserExist)
                return OperationResult.Error("کاربر در سیستم وجود دارد");


            var passwordHash = registerDto.Password.EncodeToMd5();

            _context.Add(new Blog.DataLayer.Entities.User()
            {
                FullName = registerDto.FullName,
                IsDelete = false,
                UserName = registerDto.UserName,
                Role = UserRole.User,
                CreatedOn = DateTime.Now,
                Password = passwordHash
            });

            _context.SaveChanges();
            return OperationResult.Success();
        }
    }
}
