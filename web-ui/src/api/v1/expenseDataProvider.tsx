import { queryHelper } from "../../helpers/queryHelper";
import { IFetchResult, ISearchResult } from "../../models/common/result";
import { IExpense, IExpenseSearchOptions } from "../../models/expenses/expense";
import { IExpenseSummary } from "../../models/expenses/expenseSummary";
import { api } from "../apiBase";

export class ExpenseDataProvider {
    readonly version = 'v1';

    public getExpenseSummaryAsync(month: number){        
        return api.get<IFetchResult<IExpenseSummary>>(`/api/${this.version}/expenses/summary?month=${month}`);
    }

    public searchExpensesAsync(searchOptions: IExpenseSearchOptions){     
        console.log('aa: ', searchOptions)
        return api.get<ISearchResult<IExpense>>(`/api/${this.version}/expenses${queryHelper.buildQueryFromObject(searchOptions)}`);
    }
}