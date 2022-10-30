using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FileDoc.Model
{
    public enum GT
    {
        [Display(Name = "Nam")]
        Nam = 1,
        [Display(Name = "Nữ")]
        Nữ = 2,
    }

    public class UserModel
    {
        [Key]
        public int UserId { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        [Display(Name = "Tài khoản")]
        [StringLength(50)]
        [RegularExpression("^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$", ErrorMessage = "Email is not valid")]
        [Required(ErrorMessage = "Bạn cần nhập tài khoản")]
        public string Email { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        [Display(Name = "Họ và tên")]
        [Required(ErrorMessage = "Bạn cần nhập tên")]
        [StringLength(50)]
        public string UserName { get; set; }

        [Display(Name = "Chức danh")]
        [Column(TypeName = "nvarchar(100)")]

        public string Title { get; set; }
        [Display(Name = "Giới Tính")]
        public GT Gender { get; set; }
        [Display(Name = "Ngày sinh")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DOB { get; set; }
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }
        [Column(TypeName = "varchar(50)"), MaxLength(50)]
        [Display(Name = "Mật khẩu")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Column(TypeName = "varchar(50)"), MaxLength(50)]
        [Display(Name = "Nhập lại mật khẩu")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Mật khẩu không khớp")]
        [NotMapped]
        public string ConfirmPassword { get; set; }

        public int RoleId { get; set; }
        public RoleModel Role { get; set; }
        public int GroupId { get; set; }
        public GroupPermission GroupPermission { get; set; }

        public List<DocumentList> documentLists { get; set; }
    }
}
