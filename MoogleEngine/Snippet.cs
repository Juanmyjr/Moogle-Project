
namespace MoogleEngine;

public class Snippet
{ 
    public static string ShowWrods(string text){
        string result = "";

        if (text.Length > 100) {
            result = text.Substring(0, 100);
        } else {
            result = text;
        }    

        
        return result;
    }
    
}