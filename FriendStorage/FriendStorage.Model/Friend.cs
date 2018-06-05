using System;
using System.Collections.Generic;

namespace FriendStorage.Model
{
    public class Friend
    {
        public int Id { get; set; }
        public int FriendGroupId { get; set; }
        public string FirstName { get; set; }
        public String LastName { get; set; }
        public DateTime? Birthday { get; set; }
        public bool IsDeveloper { get; set; }
        public Address Address { get; set; }
        public List<FriendEmail> Emails { get; set; }
    }
}
