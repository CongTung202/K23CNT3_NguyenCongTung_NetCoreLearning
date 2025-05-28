using System;

namespace nctLesson6.Models
{
    public class nctEmployee
    {
        public int nctId { get; set; }
        public string nctName { get; set; }
        public DateTime nctBirthDay { get; set; }
        public string nctEmail { get; set; }
        public string nctPhone { get; set; }
        public decimal nctSalary { get; set; }
        public bool nctStatus { get; set; }
    }
}
