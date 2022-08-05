namespace TinyIoC
{
    sealed partial class TinyIoCContainer
    {
        public void Clear()
        {
            _RegisteredTypes.Clear();
        }
    }
}
