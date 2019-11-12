using HouseCleanersApi.Data;
using HouseCleanersApi.Interfaces;

namespace HouseCleanersApi.BusinessLayer
{
    public class InvoiceLinesRepo : RepositoryBase<InvoiceLines>, IInvoiceLinesRepo
    {
        public InvoiceLinesRepo(clearnersDbContext context) : base(context)
        {
        }
    }
}