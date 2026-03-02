using System;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text;
//using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Signature
{
    public class Signature
    {
        //public FirmadoResponse FirmaXMl(FirmadoRequest request)
        //{

        //    var response = new FirmadoResponse();

        //    var certificate = new X509Certificate2();            
        //    certificate.Import(request.ruta_Firma, request.contra_Firma, X509KeyStorageFlags.MachineKeySet);

        //    var xmlDoc = new XmlDocument();

        //        xmlDoc.PreserveWhitespace = true;
        //        xmlDoc.Load(request.ruta_xml);

        //        var nodoExtension = xmlDoc.GetElementsByTagName("ExtensionContent", "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2").Item(request.flg_firma);
        //        if (nodoExtension == null)
        //            throw new InvalidOperationException("No se pudo encontrar el nodo ExtensionContent en el XML");
        //        nodoExtension.RemoveAll();

        //        // Creamos el objeto SignedXml.
        //        var signedXml = new SignedXml(xmlDoc) { SigningKey = certificate.PrivateKey };
        //        var xmlSignature = signedXml.Signature;

        //        var env = new XmlDsigEnvelopedSignatureTransform();

        //        var reference = new Reference(string.Empty);
        //        reference.AddTransform(env);
        //        xmlSignature.SignedInfo.AddReference(reference);

        //        var keyInfo = new KeyInfo();
        //        var x509Data = new KeyInfoX509Data(certificate);

        //        x509Data.AddSubjectName(certificate.Subject);

        //        keyInfo.AddClause(x509Data);
        //        xmlSignature.KeyInfo = keyInfo;
        //        xmlSignature.Id = "SignFacturacionElectronica";
        //        signedXml.ComputeSignature();

        //        // Recuperamos el valor Hash de la firma para este documento.
        //        if (reference.DigestValue != null)
        //            response.DigestValue = Convert.ToBase64String(reference.DigestValue);
        //            response.ValorFirma = Convert.ToBase64String(signedXml.SignatureValue);

        //        nodoExtension.AppendChild(signedXml.GetXml());

        //        using (var memDoc = new MemoryStream())
        //        {

        //            using (var writer = XmlWriter.Create(memDoc,
        //                new XmlWriterSettings { Encoding = Encoding.GetEncoding("utf-8") }))
        //            {
        //                xmlDoc.WriteTo(writer);
        //            }

        //        xmlDoc.Save(request.ruta_xml);


        //        }

        //    return response;
        //}      


        public FirmadoResponse FirmaXMl(FirmadoRequest request)
        {
            var response = new FirmadoResponse();

            var certificate = new X509Certificate2();
            try
            {
                certificate.Import(request.ruta_Firma, request.contra_Firma, X509KeyStorageFlags.PersistKeySet);

                if (!certificate.HasPrivateKey)
                {
                    throw new CryptographicException("El certificado no contiene una clave privada.");
                }

                var xmlDoc = new XmlDocument();
                xmlDoc.PreserveWhitespace = true;
                xmlDoc.Load(request.ruta_xml);

                var nodoExtension = xmlDoc.GetElementsByTagName("ExtensionContent", "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2").Item(request.flg_firma);
                if (nodoExtension == null)
                    throw new InvalidOperationException("No se pudo encontrar el nodo ExtensionContent en el XML");

                nodoExtension.RemoveAll();

                var signedXml = new SignedXml(xmlDoc) { SigningKey = certificate.PrivateKey };

                // Especificamos el algoritmo de firma (RSA-SHA1 por ejemplo)
                signedXml.Signature.SignedInfo.SignatureMethod = SignedXml.XmlDsigRSASHA1Url;

                var xmlSignature = signedXml.Signature;

                var env = new XmlDsigEnvelopedSignatureTransform();
                var reference = new Reference(string.Empty);
                reference.AddTransform(env);

                // Especificamos el método de digest para SHA-256
                reference.DigestMethod = "http://www.w3.org/2001/04/xmlenc#sha256";  // Algoritmo SHA256
                xmlSignature.SignedInfo.AddReference(reference);

                var keyInfo = new KeyInfo();
                var x509Data = new KeyInfoX509Data(certificate);
                x509Data.AddSubjectName(certificate.Subject);
                keyInfo.AddClause(x509Data);
                xmlSignature.KeyInfo = keyInfo;
                xmlSignature.Id = "SignFacturacionElectronica";
                signedXml.ComputeSignature();

                if (reference.DigestValue != null)
                    response.DigestValue = Convert.ToBase64String(reference.DigestValue);

                response.ValorFirma = Convert.ToBase64String(signedXml.SignatureValue);

                nodoExtension.AppendChild(signedXml.GetXml());

                // Guardar el documento firmado en la ruta especificada
                using (var memDoc = new MemoryStream())
                {
                    using (var writer = XmlWriter.Create(memDoc, new XmlWriterSettings { Encoding = Encoding.GetEncoding("utf-8") }))
                    {
                        xmlDoc.WriteTo(writer);
                    }

                    // Guardar el contenido firmado en el archivo XML
                    File.WriteAllBytes(request.ruta_xml, memDoc.ToArray());
                }
            }
            catch (CryptographicException ex)
            {
                Console.WriteLine("Error al intentar firmar el documento: " + ex.Message);
                Console.WriteLine(ex.ToString());
                throw new InvalidOperationException("Error al intentar firmar el documento: " + ex.Message, ex);
            }

            return response;
        }


    }
}
