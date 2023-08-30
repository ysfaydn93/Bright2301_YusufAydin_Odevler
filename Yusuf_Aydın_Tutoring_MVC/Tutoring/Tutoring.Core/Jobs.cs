using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Tutoring.Core.Models;

namespace Tutoring.Core
{
    public class Jobs
    {
        public static string GetUrl(string text)
        {
            #region Sorunlu Türkçe Karakterler Küçük Harfe Dönüştürülüyor
            text = text.Replace("I", "i");
            text = text.Replace("İ", "i");
            text = text.Replace("ı", "i");
            #endregion
            #region Diğerleri Küçük Harfe Dönüşütürülüyor
            text = text.ToLower();
            #endregion
            #region Türkçe Karakterler Latin Karakterlerine Dönüştürülüyor
            text = text.Replace("ö", "o");
            text = text.Replace("ü", "u");
            text = text.Replace("ş", "s");
            text = text.Replace("ç", "c");
            text = text.Replace("ğ", "g");
            #endregion
            #region Boşluklar Tireye Dönüştürülüyor
            text = text.Replace(" ", "-");
            #endregion
            #region Sorunlu Karakterler Kaldırılıyor
            text = text.Replace(".", "");
            text = text.Replace(",", "");
            text = text.Replace("/", "");
            text = text.Replace("\\", "");
            text = text.Replace("'", "");
            text = text.Replace("\"", "");
            text = text.Replace("^", "");
            text = text.Replace("#", "");
            text = text.Replace("$", "");
            text = text.Replace("%", "");
            text = text.Replace("&", "");
            text = text.Replace("{", "");
            text = text.Replace("(", "");
            text = text.Replace("[", "");
            text = text.Replace("]", "");
            text = text.Replace(")", "");
            text = text.Replace("}", "");
            text = text.Replace("*", "");
            text = text.Replace("=", "");
            text = text.Replace("?", "");
            text = text.Replace("_", "-");
            text = text.Replace("~", "");
            text = text.Replace("`", "");
            text = text.Replace("!", "");
            text = text.Replace("@", "");
            text = text.Replace(">", "");
            text = text.Replace("<", "");
            text = text.Replace("|", "");
            text = text.Replace("€", "");
            text = text.Replace("+", "");
            #endregion
            return text;
        }
        public static string CutText(string text, int length)
        {
            return text.Substring(0, text.Length < length ? text.Length : 30);
        }
        public static List<int> GetYears(int startYear, int endYear)
        {
            List<int> years = new List<int>();
            for (int i = startYear; i <= endYear; i++)
            {
                years.Add(i);
            }
            return years;
        }
        public static List<CityType> GetCities()
        {
            using (StreamReader sr = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/json/cities.json")))
            {
                string jsonResult = sr.ReadToEnd();
                List<CityType> cities = JsonSerializer.Deserialize<List<CityType>>(jsonResult);
                return cities;
            }
        }
        public static string UploadImage(IFormFile imageFile, string url, string dir)
        {
            var extension = Path.GetExtension(imageFile.FileName);

            var randomName = $"{url}-{Guid.NewGuid()}{extension}";

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", dir, randomName);

            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                imageFile.CopyTo(stream);
            }

            return randomName;

        }
    }
}