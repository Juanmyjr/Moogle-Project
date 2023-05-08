namespace MoogleEngine;

public class TF_IDF
{
    //cantidad de veces que se repite una palabra entre la cantidad de palabras 
    public static float TF(float cantrep , float cantwrd)
    {
        return (cantrep / cantwrd);
    }
    //cantidad de documentos y la cantidad de documentos en los que aparecen la palabra 
    public static float IDF ( float cantdoc, float cantdocprs)
    {
        float idf = (float) Math.Log (cantdoc / cantdocprs);
        return idf;
    }
}               