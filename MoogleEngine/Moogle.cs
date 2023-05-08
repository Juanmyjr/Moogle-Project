namespace MoogleEngine;


public static class Moogle
{
    public static Dictionary<float,string> order = new Dictionary<float,string >(); // Este dicionario es para que a cada valor de TF se le asocie el documento que le corresponde 
    public static Dictionary<string, string>? orderby { get; set; }                // Este dicionario contiene el titulo con el cuerpo del texto
    public static SearchResult Query(string query) {
        
        query = Normalize.Normalizing(query);                                     // Normalizar la query 
        
        string[] modify = query.Split(" ",StringSplitOptions.RemoveEmptyEntries);//Se crea un array para guardar cada palabra de la query normalizada 
        
        int[] count = new int [modify.Length];     // count es un array donde se va a almacenar el valor la cantidad de documentos en los que aparece cada palbra de la query en orden 
        float [] IDF = new float [modify.Length]; // IDF es un array donde se va a almacenar los IDF de cada documento 
        
        for (int i = 0; i < modify.Length; i++)              // cantidad de documentos en los que esta la palabra 
        {
            for (int j = 0; j < DataBase.text.Length; j++)  // para contar la cantidad de documentos en los que esta la palabra 
            {
                if (DataBase.allwords[j].Contains(modify[i]))
                {
                    count [i] += 1;
                }
            }  
        }

        for (int i = 0; i < modify.Length; i++)  // para calcular los IDF 
        {
            IDF [i] = TF_IDF.IDF(DataBase.directions.Length, count [i]);
        }

        float[] ranking = Score.Ranking(modify, IDF); // esto es para crear el score 

        orderby = new Dictionary<string,string >();
        for (int i = 0; i < ranking.Length; i++) // esto es para llenar los diccionarios
        {
            order [ranking[i]] = DataBase.nameDocuments[i];
            orderby.Add(order[ranking[i]], DataBase.text[i]);            
        }

        Array.Sort(ranking);     // ordenar el score de menor a mayor 
        Array.Reverse(ranking); // para invertir el score y devuelva los que mayor score tengan 


        if (ranking[0] == 0){ // si el mayor score es 0 no existe un resultado 

            SearchItem[] item = new SearchItem[1] {
            new SearchItem("Estas inflando", "organizate palomo", 0.9f)
            };
            return new SearchResult(item, query);
        }
        List <SearchItem> items = new List<SearchItem>();

        for (int i = 0; i < 5; i++) // para mostrar los 5 documentos que mayor coincidencia tienen con la query 
        {
            if (ranking[i] != 0)   // siempre y cuando no sea 0 

            {
                string snippet = Snippet.ShowWrods(orderby[order[ranking[i]]]); //llamar a la funcion que hace el snippet 
                items.Add(new SearchItem(order[ranking[i]], snippet, ranking[i]));
            }
        }
            
        return new SearchResult(items.ToArray(), query); // imprimir resultado 
    }
}
                                                        