using System;
using System.Collections.Generic;

namespace DataAccess.BO
{
    public class Person
    {
        public int Id { get; set; }
        public int? BossId { get; set; }
        public string Title { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }

    }

}
