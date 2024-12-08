using secure.logic.client.api.netstd.minimal.rest.v91;
using securelogic.prosigner.client.api.connector.v91;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace secure.logic.client.api.netstd.minimal.main
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("This is sample API calling to ProSigner server REST API");
            
            string primaryServerURL = "<You signing server base URL>";
            string apiID = "<API ID >";
            string apiCode = "<API Authentication code>";
            string cuID = "<Crypto User ID>";
            string cuPass = "<Crypto User PIN>";
            string filePath = "<Path to PDF file to be signed>";
            


            ProSignerClientConnector connector = new ProSignerClientConnector(primaryServerURL);

            
            if (connector.Status().return_code != 0)
            {
                Console.WriteLine("Status failure, check network connectivity");
                return;
            }
            
            Console.WriteLine("Status SUCCESS!");
            APIV91.API_LOGIN_REPLY apiLoginReply = connector.APILogin(apiID, apiCode);
            if (apiLoginReply.return_code != 0)
            {
                Console.WriteLine($"API login failure: {apiLoginReply.return_msg}");
                return;
            }

            Console.WriteLine("API login SUCCESS!");

            // Read the file 
            byte [] fileBufferIn = File.ReadAllBytes(filePath);
            string fileName = Path.GetFileName(filePath);

            APIV91.SIGN_PDF_REQUEST pdfSignRequest = new APIV91.SIGN_PDF_REQUEST()
            {
                cu_id = cuID,
                cu_pass = cuPass,
                file_name = fileName,
                value_b64 = Convert.ToBase64String(fileBufferIn),
            };

            APIV91.SIGN_PDF_REPLY pdfSignReply = connector.SignPDF(pdfSignRequest, apiLoginReply.auth_token);

            if (pdfSignReply.return_code != 0)
            {
                Console.WriteLine($"PDF Sign failure {pdfSignReply.return_msg}");
                return;
            }

            Console.WriteLine("PDF sign SUCCESS!");
            byte[] fileBufferOut = Convert.FromBase64String(pdfSignReply.value_b64);
            string fileOutPath = $"{filePath}.signed";
            File.WriteAllBytes(fileOutPath, fileBufferOut);
            
            Console.WriteLine($"File successfully signed and saved to: {fileOutPath}");
        }
    }
}
