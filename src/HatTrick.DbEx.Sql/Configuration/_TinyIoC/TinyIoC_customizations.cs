using System.Linq;

namespace TinyIoC
{
    sealed partial class TinyIoCContainer
    {
        public void Clear()
            => _RegisteredTypes.Clear();
    }
}