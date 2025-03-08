using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProject.Interfaces
{
    public interface IPaymentService
    {
        Task<List<Guid>> ProcessPaymentsAsync();
    }
}
