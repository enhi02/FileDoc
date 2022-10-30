using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FileDoc.Model
{
    public class GroupPermission
    {
        [Key]
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public DateTime createdDate { get; set; }
        public string Note { get; set; }
        public List<UserModel> users { get; set; }
    }
}
