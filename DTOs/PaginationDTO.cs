namespace skm_back_dotnet.DTOs
{
    public class PaginationDTO
    {
        private int recordsPerPage = 10;
        private readonly int maxRecordsPerPage = 100;

        public int Page { get; set; } = 1;
        public int RecordsPerPage{
            get { return recordsPerPage; }
            set { recordsPerPage = (value > maxRecordsPerPage ? maxRecordsPerPage : value); }
        }


    }
}