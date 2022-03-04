namespace Publisher.Infrastructure.Interfaces.Models
{
    public interface IBook
    {
        #region Properties
        public string Title { get; }
        public string Author { get; }
        public string Publisher { get; }
        public int Released { get; }
        public long ISBN { get; }
        public string Description { get; }
        #endregion
    }
}