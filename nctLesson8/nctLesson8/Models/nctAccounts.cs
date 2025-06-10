using System;
using System.ComponentModel.DataAnnotations;

namespace nctLesson8.Models
{
    public class nctAccounts
    {
        [Required(ErrorMessage = "Id không được để trống")]
        [StringLength(10, ErrorMessage = "Id không được vượt quá 10 ký tự")]
        public string nctId { get; set; }

        [Required(ErrorMessage = "Tên không được để trống")]
        [StringLength(40, ErrorMessage = "Tên không được vượt quá 40 ký tự")]
        public string nctFullName { get; set; }

        [Required(ErrorMessage = "Email không được để trống")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string nctEmail { get; set; }

        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        [StringLength(10, ErrorMessage = "Số điện thoại không được vượt quá 10 ký tự")]
        [RegularExpression(@"^\d{1,10}$", ErrorMessage = "Số điện thoại chỉ được chứa số")]
        public string nctPhone { get; set; }

        [StringLength(40, ErrorMessage = "Địa chỉ không được vượt quá 40 ký tự")]
        public string nctAddress { get; set; }

        public string nctAvatar { get; set; }

        [Required(ErrorMessage = "Ngày sinh không được để trống")]
        public DateTime nctBirthday { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [MinLength(6, ErrorMessage = "Mật khẩu phải có ít nhất 6 ký tự")]
        public string nctPassword { get; set; }

        public string nctFacebook { get; set; }
    }
}
