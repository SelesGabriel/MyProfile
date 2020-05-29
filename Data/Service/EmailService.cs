using BlazorServerProfile.Data.Context;
using BlazorServerProfile.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServerProfile.Data.Service
{
    public class EmailService
    {
        AppDbContext context;
        public EmailService(AppDbContext context)
        {
            this.context = context;
        }

        public async Task PostAsync(Email email)
        {
            context.Add(email);
            await context.SaveChangesAsync();
        }
    }
}
