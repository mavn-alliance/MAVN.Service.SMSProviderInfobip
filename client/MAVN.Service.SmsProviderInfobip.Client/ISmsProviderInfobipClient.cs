using JetBrains.Annotations;

namespace MAVN.Service.SmsProviderInfobip.Client
{
    /// <summary>
    /// SmsProviderInfobip client interface.
    /// </summary>
    [PublicAPI]
    public interface ISmsProviderInfobipClient
    {
        /// <summary>Application Api interface</summary>
        ISmsProviderInfobipApi Api { get; }
    }
}
