
export interface IExpenseTypeSummary {
    expenseTypeId: number;
    expenseTypeName: string;
    totalAmount: number;
}

export interface IExpenseSummary {
    expenseTypes: IExpenseTypeSummary[];
    totalExpense: number;
    topExpense: IExpenseTypeSummary;
}