namespace ServerSideBlazorApp.Models
{
    public class SingleMetricDatasetModel<T> : SingleMetricDatasetModel
    {
        public new T? Value { get { return (T?)base.Value; } set { base.Value = value; } }
    }
}
