using secure.logic.client.api.netstd.minimal.rest.v91;
using static secure.logic.client.api.netstd.minimal.rest.v91.APIV91;


namespace securelogic.prosigner.client.api.connector.v91
{
    public class ProSignerClientConnector
    {
        private string mPrimarySrvURL = string.Empty;
        private string mSecondarySrvURL = string.Empty;
        private string mActiveSrvURL = string.Empty;
        private string mAccessToken = string.Empty;

        public override string ToString(){
            return $"ProSignerClientConnector=> [Primary={this.mPrimarySrvURL}], [Secondary={this.mSecondarySrvURL}]";
        }
        // ============================================================================
        private void Switch(string url){
                this.mActiveSrvURL = (url == this.mPrimarySrvURL) ? this.mSecondarySrvURL : this.mPrimarySrvURL;
        }
        // ============================================================================
        private string GetActive()
        {
            return this.mActiveSrvURL;
        }
        // ============================================================================
        private string GetStandby(){
            return (this.mActiveSrvURL == this.mPrimarySrvURL) ? this.mSecondarySrvURL: this.mPrimarySrvURL;
        }
        // ============================================================================
        public ProSignerClientConnector(string primarySrvURL, string secondarySrvURL=null) {
            if (string.IsNullOrEmpty(primarySrvURL))
                throw new Exception("Invalid Primary Server URL");

            this.mPrimarySrvURL = primarySrvURL;
            if (!string.IsNullOrEmpty(secondarySrvURL)){
                this.mSecondarySrvURL = secondarySrvURL;
            }else{
                this.mSecondarySrvURL = primarySrvURL;
            }

            //At the first initiation the active URL is the primary url
            this.mActiveSrvURL = this.mPrimarySrvURL;
        }
        // ============================================================================
        public APIV91.STATUS_REPLY Status(){
            APIV91.STATUS_REPLY reply = new APIV91.STATUS_REPLY();
            try{
                reply = ProSignerRESTConnector.STATUS(this.GetActive(), new APIV91.STATUS_REQUEST());
                if (reply.return_code != 0){
                    this.Switch(this.GetActive());
                    reply = ProSignerRESTConnector.STATUS(this.GetActive(), new APIV91.STATUS_REQUEST());
                }
            }
            catch (Exception e){
                reply.return_code = (int)RETURN_CODES.GENERAL_ERROR;
                reply.return_msg= e.ToString();
            }
            return reply ;
        }
        // ============================================================================
        public APIV91.API_LOGIN_REPLY APILogin(string apiID, string apiKey)
        {
            APIV91.API_LOGIN_REPLY reply = new APIV91.API_LOGIN_REPLY();
            APIV91.API_LOGIN_REQUEST request = new APIV91.API_LOGIN_REQUEST()
            {
                api_id = apiID,
                api_key = apiKey
            };

            try
            {
                reply = ProSignerRESTConnector.API_LOGIN(this.GetActive(), request);
                if (reply.return_code != 0)
                {
                    this.Switch(this.GetActive());
                    reply = ProSignerRESTConnector.API_LOGIN(this.GetActive(), request);
                }
            }
            catch (Exception e)
            {
                reply.return_code = (int)RETURN_CODES.GENERAL_ERROR;
                reply.return_msg = e.ToString();
            }
            return reply;
        }

        // ============================================================================
        public APIV91.SIGN_CMS_REPLY SignCMS(string accessToken, byte[] tbs, int hashAlgorithm, string cuid, string pin, string fileName)
        {
            APIV91.SIGN_CMS_REQUEST request = new APIV91.SIGN_CMS_REQUEST
            {
                cu_id = cuid,
                cu_pass = pin,
                file_name = fileName,
                tbs_value_b64 = Convert.ToBase64String(tbs),
                hash_alg = hashAlgorithm
            };

            APIV91.SIGN_CMS_REPLY reply = new APIV91.SIGN_CMS_REPLY();
            try
            {
                reply = ProSignerRESTConnector.SIGN_CMS(this.GetActive(), accessToken, request);
                if (reply.return_code != 0)
                {
                    this.Switch(this.GetActive());
                    reply = ProSignerRESTConnector.SIGN_CMS(this.GetActive(), accessToken, request);
                }
            }
            catch (Exception e)
            {
                reply.return_code = (int)RETURN_CODES.GENERAL_ERROR;
                reply.return_msg = e.ToString();
            }
            return reply;
        }
        // ============================================================================
        public APIV91.SIGN_PDF_REPLY SignPDF(APIV91.SIGN_PDF_REQUEST request, string accessToken)
        {
            APIV91.SIGN_PDF_REPLY reply = new APIV91.SIGN_PDF_REPLY();
            try
            {
                reply = ProSignerRESTConnector.SIGN_PDF(this.GetActive(), accessToken, request);
                if (reply.return_code != 0)
                {
                    this.Switch(this.GetActive());
                    reply = ProSignerRESTConnector.SIGN_PDF(this.GetActive(), accessToken, request);
                }
            }
            catch (Exception e)
            {
                reply.return_code = (int)APIV91.RETURN_CODES.GENERAL_ERROR;
                reply.return_msg = e.ToString();
            }
            return reply;
        }
        // ============================================================================
        public APIV91.SIGN_XML_REPLY SignXML(APIV91.SIGN_XML_REQUEST request, string accessToken)
        {
            APIV91.SIGN_XML_REPLY reply = new APIV91.SIGN_XML_REPLY();
            try
            {
                reply = ProSignerRESTConnector.SIGN_XML(this.GetActive(), accessToken, request);
                if (reply.return_code != 0)
                {
                    this.Switch(this.GetActive());
                    reply = ProSignerRESTConnector.SIGN_XML(this.GetActive(), accessToken, request);
                }
            }
            catch (Exception e)
            {
                reply.return_code = (int)APIV91.RETURN_CODES.GENERAL_ERROR;
                reply.return_msg = e.ToString();
            }
            return reply;
        }
        // ============================================================================
        public APIV91.SIGN_HASH_REPLY SignHash(APIV91.SIGN_HASH_REQUEST request, string accessToken)
        {
            APIV91.SIGN_HASH_REPLY reply = null;
            try
            {
                reply = ProSignerRESTConnector.SIGN_HASH(this.GetActive(), accessToken, request);
                if (reply.return_code != 0)
                {
                    this.Switch(this.GetActive());
                    reply = ProSignerRESTConnector.SIGN_HASH(this.GetActive(), accessToken, request);
                }
            }
            catch (Exception e)
            {
                reply.return_code = (int)APIV91.RETURN_CODES.GENERAL_ERROR;
                reply.return_msg = "Failed to sign file";
                reply.extended_msg = e.ToString();
            }
            return reply;
        }
        // ============================================================================
        public APIV91.SIGN_CONFIG_REPLY GetSignConfig(APIV91.SIGN_CONFIG_REQUEST request, string accessToken)
        {
            APIV91.SIGN_CONFIG_REPLY reply = new APIV91.SIGN_CONFIG_REPLY();
            try
            {
                reply = ProSignerRESTConnector.GET_SIGN_CONFIG(this.GetActive(), accessToken, request);
                if (reply.return_code != 0)
                {
                    this.Switch(this.GetActive());
                    reply = ProSignerRESTConnector.GET_SIGN_CONFIG(this.GetActive(), accessToken, request);
                }
            }
            catch (Exception e)
            {
                reply.return_code = (int)RETURN_CODES.GENERAL_ERROR;
                reply.return_msg = e.ToString();
            }
            return reply;
        }
        // ============================================================================
    }
}
