export interface Pagenation<T> {
    pageIndex: number;
    pageSize: number;
    countLeft: number;
    totalCount: number;
    data: T;
}

