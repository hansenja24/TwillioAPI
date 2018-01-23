using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Texter.Models
{
    [Table("Contacts")]
    public class Contact
    {
        public Contact(int thisId, string thisName, string thisNumber)
        {
            ContactId = thisId;
            Name = thisName;
            Number = thisNumber;
        }

        public Contact()
        {

        }

        [Key]
        public int ContactId { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
    }
}