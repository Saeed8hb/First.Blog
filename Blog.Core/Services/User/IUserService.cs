using CoreLayer.DTOs.User;
using CoreLayer.Utilities;

namespace CoreLayer.Services.User
{
    public interface IUserService
    {
        OperationResult Register(UserRegisterDto registerDto);
        OperationResult LoginUser(UserLoginDto loginDto);
    }
}
