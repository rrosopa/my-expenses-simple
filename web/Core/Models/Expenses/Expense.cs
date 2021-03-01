using System;

namespace Core.Models.Expenses
{
    public class Expense : BaseModel
    {
        public int ExpenseTypeId { get; set; }
        public string ExpenseTypeName { get; set; }

        public string Note { get; set; }

        public decimal Amount { get; set; }
        public DateTimeOffset Date { get; set; }
    }

    public class ExpenseSearchOptions : BaseSearchOptions
    {
        public int? ExpenseTypeId { get; set; }
        public DateTimeOffset? DateFrom { get; set; }
        public DateTimeOffset? DateTo { get; set; }
    }
}
