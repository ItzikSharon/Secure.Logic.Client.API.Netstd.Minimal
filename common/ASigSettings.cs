namespace securelogic.prosigner.client.api.common
{
    public  abstract class ASigSettings:ISigSettings
    {
        private object m_lock = new object();   
        private IDictionary<string, object> m_params = new Dictionary<string, object>();
        public object GetParam(Enums.SIG_PARAM_ID key, object defaultValue)
        {
            lock (this.m_lock){
                object rv = null;
                if (this.m_params.TryGetValue(key.ToString(), out rv)) {
                    return rv;
                }
                else{
                    rv = defaultValue;
                }
            return rv;
            }
        }
        public void SetParam(Enums.SIG_PARAM_ID key, object value)
        {
            lock (this.m_lock)
            {
                this.m_params.Remove(key.ToString());
                this.m_params[key.ToString()] = value;
            }
        }

        public string  CryptoUserID
        {
            get { return (string)this.GetParam(Enums.SIG_PARAM_ID.CRYPTO_USER_ID, string.Empty); }
            set { this.SetParam(Enums.SIG_PARAM_ID.CRYPTO_USER_ID, (string)value); }
        }
        public string CryptoUserPIN
        {
            get { return (string)this.GetParam(Enums.SIG_PARAM_ID.CRYPTO_USER_PIN, string.Empty); }
            set { this.SetParam(Enums.SIG_PARAM_ID.CRYPTO_USER_PIN, (string)value); }
        }
        public string FileName
        {
            get { return (string)this.GetParam(Enums.SIG_PARAM_ID.FILE_NAME, string.Empty); }
            set { this.SetParam(Enums.SIG_PARAM_ID.FILE_NAME, (string)value); }
        }
        public int TokenIndex
        {
            get { return (int)this.GetParam(Enums.SIG_PARAM_ID.TOKEN_INDEX, 0); }
            set { this.SetParam(Enums.SIG_PARAM_ID.TOKEN_INDEX, (int)value); }
        }
        public int SigTypeID
        {
            get { return (int)this.GetParam(Enums.SIG_PARAM_ID.SIGTYPE_ID, -1); }
            set { this.SetParam(Enums.SIG_PARAM_ID.SIGTYPE_ID, (int)value); }
        }
        public bool UseCompression
        {
            get { return (bool)this.GetParam(Enums.SIG_PARAM_ID.USE_COMPRESSION, false); }
            set { this.SetParam(Enums.SIG_PARAM_ID.USE_COMPRESSION, (bool)value); }
        }
        public string GetUniqueID()
        {
            return $"{CryptoUserID}-{TokenIndex}-{SigTypeID}";
        }
    }
}
