
using System.Security.Cryptography.X509Certificates;

namespace securelogic.prosigner.client.api.tiff
{
    public class SignatureVerificationResult
    {
        public bool Valid { get; set; } = false;
        public X509Certificate2 SignerCertificate { get; set; } = null;
        public string Message { get; set; } = string.Empty;

        public override string ToString()
        {
            string signerMsg = "Not Exist";
            if(SignerCertificate != null)
            {
                signerMsg = SignerCertificate.Subject;
            }
            return $"Verfication Result: Valid={Valid}, Signed by: {signerMsg}, Message: {Message}";
        }
    }
}
