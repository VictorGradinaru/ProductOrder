using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Shared.NewFolder
{
    public interface IFileLogger
    {
        void Log(string message);
    }

    public class FileLogger : IFileLogger
    {
        private readonly string _logFilePath;

        public FileLogger(IConfiguration configuration)
        {
            // Obține calea fișierului din configurare
            _logFilePath = configuration["Logging:LogFilePath"];
        }

        public void Log(string message)
        {
            try
            {
                // Asigură-te că fișierul există sau creează-l
                var directory = Path.GetDirectoryName(_logFilePath);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);  // Creează folderul dacă nu există
                }

                // Adaugă data și mesajul logat la fișier
                using (StreamWriter writer = new StreamWriter(_logFilePath, append: true))
                {
                    writer.WriteLine($"{DateTime.UtcNow:yyyy-MM-dd HH:mm:ss} - {message}");
                }
            }
            catch (Exception ex)
            {
                // În caz de eroare, poți loga și eroarea într-un alt fișier sau afișa un mesaj de eroare
                Console.WriteLine($"Error writing to log file: {ex.Message}");
            }
        }
    }
}
