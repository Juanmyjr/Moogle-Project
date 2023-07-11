namespace MoogleEngine;

 public class Vector {

        public double [] coordenadas;

        public int  dimension
        {
            get { return coordenadas.Length; }
        }

         public double this[int i]
    {
        get { return coordenadas[i]; }
        set { coordenadas[i] = value; }
    }

    public Vector(params double[] coordenadas)
    {
        this.coordenadas = coordenadas;
    }
    
    public static Vector operator + (Vector a, Vector b )
    {
        if(a.dimension != b.dimension || b.dimension != a.dimension)
        {

        throw new ArgumentException("Los vectores deben tener las mismas dimensiones");

        }
        double [] suma = new double [a.dimension];

        for (int i = 0; i <a.dimension; i++)
        {
            for (int j = 0; j < b.dimension; j++)
            {
                for (int k = 0; k < suma.Length; k++)
                {
                    suma[k] =  a[i] + b[j];  

                    i++;
                    j++;
                }
                
            }
                       
            
        }
        return new Vector(suma);
    } 

    public static Vector operator - (Vector a, Vector b)
    {
        if(a.dimension != b.dimension || b.dimension!= a.dimension)
        {

        throw new ArgumentException("Los vectores deben tener las mismas dimensiones");

        }
        double [] resta = new double  [a.dimension];

        for (int i = 0; i <a.dimension; i++)
        {
            
            for (int j = 0; j <b.dimension; j++)
            {
            
                for (int k = 0; k < resta.Length; k++)
                {

                   
                    resta [k] = a[i] - b[j];
                    
                    i++;
                    j++;
                }
                
            
            }
            
        }
        return new Vector(resta);
    } 

    public static Vector operator * (Vector a, Vector b)
        {
            double s =0;

            if(a.dimension != b.dimension || b.dimension != a.dimension)
            {

            throw new ArgumentException("Los vectores deben tener las mismas dimensiones");

            }
            for (int i = 0; i < a.dimension; i++)
            {

            for (int j = 0; j < b.dimension; j++)
            {   
                double  var1 = a[i] * b[j];
                s += var1 ;

                
                i++;
            }
            
       }
       return new Vector(s);
    } 

    public static Vector operator * (Vector a , double b)
    {
        double [] array = new double [a.dimension];

        for (int i = 0; i < a.dimension; i++)
        {
            for (int j = 0; j < array.Length; j++)
            {
                
                array [j] = b * a[i];
                
                 i++;
            }
        }
        return new Vector (array) ;
    }
    
    public static Vector Invert ( Vector array)
    {
        double [] arreglo = new double [array.dimension];
        
        for (int i = array.dimension -1; i > 0; i--)
        {
            for (int j = 0; j < arreglo.Length; j++)
            {
                arreglo [j] = array[i];

                i--;
            }
            
        }

        return new Vector (arreglo);
    }




    }