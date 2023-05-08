namespace MoogleEngine;

public static class Score
{
    public static float [] Ranking (string [] modify , float [] IDF) // Metodo para crear un ranking(valor de coincidencia de un documento con la query ) de documentos 
    {
        float [] ranking = new float [DataBase.directions.Length]; // array para guardar el ranking 
        float tfxidf = 0;
        for (int i = 0; i < DataBase.wordsDocuments.Length; i++)// iteramos sobre los documentos 
        {
            int j = 0;
            foreach (var word in modify ) //iteramos sobre la query 
            {
                if(DataBase.wordsDocuments[i].ContainsKey(word)) // si el documento contiene la palabra se le agrega su valor de TF-IDF
                {
                    tfxidf = tfxidf + DataBase.wordsDocuments[i][word] * IDF[j]; // se va acumulando el valor de TF IDF de cada documento 
                    j++;
                    
                }
                else {
                    tfxidf /= 2; // esto ubica los documentos que mas coincidencias en palabras tienen con la query ordenandolos por Tf IDF
                    j++;
                }

                }

            ranking [i] = tfxidf; // Se le asigna lo acumulado al ranking 
            tfxidf = 0 ; // se vuelven a igualar a 0 para el siguiente Documento 
        }

        return ranking;
    }




}