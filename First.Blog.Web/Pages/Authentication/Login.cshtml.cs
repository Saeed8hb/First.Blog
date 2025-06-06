using CoreLayer.DTOs.User;
using CoreLayer.Services.User;
using CoreLayer.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Endpoint.Pages.Authentication
{
    [ValidateAntiForgeryToken]
    [BindProperties]
    public class LoginModel : PageModel
    {
        #region Constructor

        private readonly IUserService _userService;

        public LoginModel(IUserService userService)
        {
            _userService = userService;
        }

        #endregion


        #region Properties
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string UserName { get; set; }

        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [MinLength(6, ErrorMessage = "{0} باید بیشتر از 5 کارکتر باشد")]
        public string Password { get; set; }

        #endregion

        #region Methods

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var res = _userService.LoginUser(new UserLoginDto()
            {
                UserName = UserName,
                Password = Password
            });
            if (res.Status == OperationResultStatus.Error)
                ModelState.AddModelError("UserName", "نام کاربری یا رمز عبور اشتباه است");
            return Page();

            return RedirectToPage("../Index");
        }

        #endregion

    }
}
