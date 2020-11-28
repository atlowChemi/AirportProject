export interface PaginatedData<T> {
    elements: T[];
    total: number;
    maxPage: number;
}
