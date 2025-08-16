namespace ProvaPub.Models
{
    public class ListModel<T> where T : class
    {
        public virtual List<T> Items { get; set; }
        public int TotalCount { get; set; }
        public bool HasNext { get; set; }
    }
}
