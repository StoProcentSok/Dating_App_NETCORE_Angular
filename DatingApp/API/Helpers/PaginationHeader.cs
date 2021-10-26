namespace API.Helpers
{
    public class PaginationHeader
    {
        public PaginationHeader(int currentPage, int items, int totalItems, int totalPages)
        {
            CurrentPage = currentPage;
            Items = items;
            TotalItems = totalItems;
            TotalPages = totalPages;
        }

        public int CurrentPage { get; set; }
        public int Items { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
    }
}