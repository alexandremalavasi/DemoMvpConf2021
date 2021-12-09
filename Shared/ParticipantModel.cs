using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace MVPConfDemo.Shared
{
    public class ParticipantModel
    {
        [Required(ErrorMessage = "Please enter a name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter the job title")]
        [MinLength(5, ErrorMessage = "Job description must be longer than 5 characters")]
        public string JobTitle { get; set; }

        [Required(ErrorMessage = "Please enter a valid email")]
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", ErrorMessage = "Please enter a valid email")]
        public string Email { get; set; }
        public bool PaymentConfirmed { get; set; }
    }
}
