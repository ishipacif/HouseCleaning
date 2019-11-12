using HouseCleanersApi.Data;
using HouseCleanersApi.Interfaces;

namespace HouseCleanersApi.BusinessLayer
{
    public class InvoicesRepo: RepositoryBase<Invoices>, IInvoiceRepo

    {
        public InvoicesRepo(clearnersDbContext context) : base(context)
        {
        }
    }
}