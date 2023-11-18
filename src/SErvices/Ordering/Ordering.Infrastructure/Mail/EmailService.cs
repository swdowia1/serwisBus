using Newtonsoft.Json;
using Ordering.Application.Contracts.Infrastructure;
using Ordering.Application.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Mail
{
    public class EmailService : IEmailService
    {
        public async Task<bool> SendEmail(Email email)
        {
            string nazwa = "mail_{0}.txt";
            string g = Guid.NewGuid().ToString();
            nazwa = string.Format(nazwa, g);

            string json = JsonConvert.SerializeObject(email, Formatting.Indented);
            File.WriteAllText(nazwa, json);
            return true;
        }
    }
}
