namespace Energy.API.ViewModel.Requests
{
    public class RequestEditDistributor
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public bool Active { get; set; }
    }
}
