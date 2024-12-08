using securelogic.prosigner.client.api.connector.v91;

namespace securelogic.prosigner.client.api.common
{
    public  interface ISigner
    {
        ISigResult Sign( byte[] dataIn, string accessToken, ISigSettings sigSettings);
        ISigSettings CreateSettings();
        bool SetServerConnector(ProSignerClientConnector serverConnector);
    }
}
