using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Models.Expenses
{
    public class ExpenseSummary
    {
        public List<ExpenseTypeSummary> ExpenseTypes { get; set; } = new List<ExpenseTypeSummary>();
        
        public decimal TotalExpense => ExpenseTypes.Sum(x => x.TotalAmount);
        public ExpenseTypeSummary TopExpense => ExpenseTypes.OrderByDescending(x => x.TotalAmount).FirstOrDefault();
    }

    public class ExpenseTypeSummary
    {
        public int ExpenseTypeId { get; set; }
        public string ExpenseTypeName { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
