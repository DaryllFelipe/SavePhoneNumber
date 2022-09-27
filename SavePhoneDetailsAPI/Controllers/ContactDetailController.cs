using DataObjects;
using Microsoft.AspNetCore.Mvc;
using SavePhoneDetailsAPI.Models;

namespace SavePhoneDetailsAPI.Controllers
{
    [ApiController]
    [Route("contact-detail")]
    public class ContactDetailController : Controller
    {
        [HttpPost]
        [Route("add")]
        public void Add(ContactDetailDTO contactDetailDTO)
        {
            using(PracticeDBContext ctx = new())
            {
                ctx.ContactDetails.Add(new ContactDetail()
                {
                    FullName = contactDetailDTO.FullName,
                    PhoneNumber = contactDetailDTO.PhoneNumber,
                });
                ctx.SaveChanges();
            }
        }

        [HttpGet]
        [Route("all")]
        public List<ContactDetailDTO> Get()
        {
            List<ContactDetailDTO> details = new();
            using(PracticeDBContext ctx = new())
            {
                List<ContactDetail> results = ctx.ContactDetails.ToList();
                if(results != null && results.Any())
                {
                    int count = results.Count();
                    for(int i = 0; i < count; i++)
                    {
                        details.Add(new ContactDetailDTO()
                        {
                            FullName = results[i].FullName,
                            PhoneNumber = results[i].PhoneNumber,
                            Id = results[i].Id
                        });
                    }
                    
                }
            }

            return details;
        }
    }
}
