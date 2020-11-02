namespace ServerSideBlazorApp.Models
{
    public abstract class SingleMetricDatasetModel
    {
        public object Value { get; set; }
        public string Label { get; set; }
    }

    public class SingleMetricDatasetModel<T> : SingleMetricDatasetModel
    {
        public new T Value { get { return (T)base.Value; } set { base.Value = value; } }
    }
}
