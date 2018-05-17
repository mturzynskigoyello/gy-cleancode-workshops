using System.Collections.Generic;

namespace GyShop.Cli.Orders
{
    class OrderValidationResult
    {
        public bool IsValid { get; set; }
        public IEnumerable<string> NotAvailableItems { get; set; }
        public IEnumerable<string> NotExistingItems { get; set; }
    }
}
