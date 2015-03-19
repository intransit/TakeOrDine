using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TakeOrDine.Models
{
    public class UserInfo
    {
        //primary key
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }    //sensitive to store as it is!!
                                                //should credentials be a separate object/table of its own?
    }
}