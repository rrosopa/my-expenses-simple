import { IError } from "./error";

export interface IActionResult<T> {
    errors: IError[];
    result: T;
}

export interface IFetchResult<T> extends IActionResult<T> {

}

export interface ISearchResult<T> extends IActionResult<T[]> {
    page: number;
    pageSize: number;
    pageTotalCount: number;
    totalResult: number;
}