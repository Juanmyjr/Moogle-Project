
namespace MoogleEngine;

//Esta Clase se utiliza para cargar los documentos de Moogle Project
public class DataBase
{   
    public static string [] directions = new string[1];//Este campo es para guardar los directorios de los documentos 
    public static string [] nameDocuments = new string[1];//Este campo es para guardar los nombres de los documentos 
    public static string[] text = new string[1]; //Este campos es para guardar los documentos 
    public static string [][] allwords = new string [1][]; // En este campo se listan los documentos separados por palabra 
    public static Dictionary<string, float>[] wordsDocuments = new Dictionary<string, float>[1];
    // Este campo es un array de diccionarios que contienen un diccionario encada posicion del array con cada palabra y su TF



    // Funcion para cargar y calcular el TF de los Documentos 
    public static void Loading (string path = "Content") 
    {
        directions = Directory.GetFiles(Path.Join("..",  path),"",SearchOption.AllDirectories);
        nameDocuments = new string[directions.Length];
        text = new string[directions.Length];
        allwords = new string[directions.Length][];
        wordsDocuments = new Dictionary<string, float>[directions.Length];

        for (int i = 0; i < directions.Length;i++)
        {
            nameDocuments[i] = Path.GetFileNameWithoutExtension(directions[i]);//Metodo para obtener el nombre de los Documentos 
            text[i] = Normalize.Normalizing ( File.ReadAllText (directions[i]));// Metodo llamado de la clase Normalize para normalizar el texto y el ReadAllText para leer los documentos 
            allwords [i]= text[i].Split(" ",StringSplitOptions.RemoveEmptyEntries); // Metodo para eliminar espacios vacios 
            wordsDocuments[i] = new Dictionary<string, float>(); //Esto es para que no de error al iniciar MOpgle y me diga qu esta vacio 

            foreach (string word in allwords[i]) {
                
                 if (wordsDocuments[i].Keys.Contains(word)) {      //Metodo para saber si la palabra esta repetida 
                    wordsDocuments[i][word] += 1;                 // Contador para si la palabra esta repetida adicionar uno en cada repeticion 
                } else {
                    wordsDocuments[i].Add(word, 1);              // Si no se cumple que se repite mas de una vez le asignamos 1
                }
            }
            
            foreach ( var key in wordsDocuments[i].Keys)      // linea para intercambiar cada valor de cada palabra por su TF en el Diccionario  
            {
                wordsDocuments [i][key] = TF_IDF.TF(wordsDocuments[i] [key] , allwords[i].Length);
            }




        }
    }
}