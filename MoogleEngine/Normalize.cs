using System.Text.RegularExpressions;
namespace MoogleEngine;

public class Normalize
{
    //Metodo para elimnar tildes y ciertas letras 
    public static string Normalizing(string text)
    {
        text = text.ToLower();
        text = text.Replace("á", "a");
        text = text.Replace("é", "e");
        text = text.Replace("í", "i");
        text = text.Replace("ó", "o");
        text = text.Replace("ú", "u");
        
        text = Regex.Replace(text, @"[^ña-z0-9]", " "); //Metdodo para eliminar todo tipo de caracteres que no se identifican 
    
        return text;
    }
}