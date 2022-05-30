using System.IO;

namespace CopyBinaryFile
{
    public class CopyBinaryFile
    {
        static void Main(string[] args)
        {
            string inputPath = @"..\..\..\copyMe.png";
            string outputPath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputPath, outputPath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            using FileStream reader = new FileStream(inputFilePath, FileMode.Open);
            using FileStream writer = new FileStream(outputFilePath, FileMode.Create);
            byte[] bytes = new byte[256];
            int currentByte = reader.Read(bytes, 0, bytes.Length);
            while (currentByte != 0)
            {
                writer.Write(bytes, 0, bytes.Length);
                currentByte = reader.Read(bytes, 0, bytes.Length);
            }

        }
    }
}
