using securelogic.prosigner.client.api.connector;
using securelogic.prosigner.client.api.common;
using securelogic.prosigner.client.api.connector.v91;

namespace securelogic.prosigner.client.api.common
{
    public abstract class ASigner : ISigner
    {
        protected ProSignerClientConnector mServerConnector = null;

        public abstract ISigSettings CreateSettings();

        public bool SetServerConnector(ProSignerClientConnector serverConnector)
        {
            this.mServerConnector = serverConnector;
            return true;
        }

        public abstract ISigResult Sign(byte[] dataIn, string accessToken, ISigSettings sigSettings);
    }
}
