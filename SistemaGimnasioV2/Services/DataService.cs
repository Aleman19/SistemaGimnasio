using Microsoft.EntityFrameworkCore;
using SistemaGimnasioV2.Data;
using SistemaGimnasioV2.Models;

namespace SistemaGimnasioV2.Services
{
    public class InvoiceService
    {
        private readonly GymDbContext _context;

        public InvoiceService(GymDbContext context)
        {
            _context = context;
        }

        public async Task<List<Invoice>> GenerateInvoicesAsync(int month)
        {
            var memberships = await _context.Memberships
                .Include(m => m.User)
                .Where(m => m.StartDate.Month <= month && m.EndDate.Month >= month)
                .ToListAsync();

            var invoices = new List<Invoice>();

            foreach (var membership in memberships)
            {
                var invoice = new Invoice
                {
                    UserId = membership.UserId,
                    Date = DateTime.Now,
                    Amount = membership.Price
                };

                _context.Invoices.Add(invoice);
                invoices.Add(invoice);
            }

            await _context.SaveChangesAsync();
            return invoices;
        }
    }
}
