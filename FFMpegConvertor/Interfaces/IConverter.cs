using System.Threading.Tasks;

namespace FFMpegConvertor
{
    public interface IConverter
    {
        // Convert audio file
        void Convert();

        // Convert audio file with current arguments asynchronically
        Task ConvertAsync();
    }
}
