using static securelogic.prosigner.client.api.common.Enums;

namespace securelogic.prosigner.client.api.common
{
    public interface ISigSettings
    {
        void SetParam(SIG_PARAM_ID key, object value);
        object GetParam(SIG_PARAM_ID key, object defaultValue);
    }
}
