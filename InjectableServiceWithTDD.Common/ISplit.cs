using Splitio.Services.Client.Interfaces;

namespace InjectableServiceWithTDD.Common
{
    public interface ISplit
    {
        ISplitClient SDK { get; }
    }
}