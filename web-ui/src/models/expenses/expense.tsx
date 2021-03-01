export interface IExpense {
    id: number;
    
    expenseTypeId: number;
    expenseTypeName: string;
    note: string | null;

    amount: number;
    date: Date;    
}

export interface IExpenseSearchOptions {
    page: number;
    pageSize: number;

    expenseTypeId: number | null;
    dateFrom: Date | null;
    dateTo: Date | null;
}