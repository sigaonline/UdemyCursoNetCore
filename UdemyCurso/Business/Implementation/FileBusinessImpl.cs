using System.IO;
using UdemyCurso.Model;

namespace UdemyCurso.Business.Implementation
{
    public class FileBusinessImpl : IFileBusiness
    {
        public byte[] GetPDFFile()
        {
            string path = Directory.GetCurrentDirectory();
            string fullPath = path + "\\Other\\RECIBO_PA_ASSINADO.pdf";
            return File.ReadAllBytes(fullPath);
        }
    }
}
