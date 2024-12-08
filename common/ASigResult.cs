namespace securelogic.prosigner.client.api.common
{
    public abstract  class ASigResult:ISigResult
    {
        public int ReturnCode = 0;
        public string  ReturnMessage = "Success";
        public byte[] ResultData = null;
    }
}
