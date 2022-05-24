//namespace EDexamenT6a8
///<summary>
/// Proporciona las propiedades y métodos necesarios para Obtener los niveles de agua y el consumo de capsulas
/// ademas de reponer las capsulas y los niveles de agua
///</summary>
///<remarks>Recuerde utilizar esta clase solo cuando necesite modificar toda la información referente a la cafetera </remarks>
class cafetera
{

    /// <summary>
    /// <para>A lo largo de todo el codigo hemos tenido que identar el codigo para que prosiga con los estilos marcados</para>
    /// <para>Aqui encapsularemos los campos ya que estos deben ser privados siguiendo la norma general de poo
    /// ademas de reubicar la posicion de las propiedades y los campos</para>
    /// </summary>
    private string marcaMaquina;
    public global::System.String MarcaMaquina { get => marcaMaquina; set => marcaMaquina = value; }

    private string referenciaModelo;
    public global::System.String RefereciaModelo { get => referenciaModelo; set => referenciaModelo = value; }

    private double cantidadAgua;
    public global::System.Double CantidadAgua { get => cantidadAgua; set => cantidadAgua = value; }

    private double totalDeCapsulas;
    public global::System.Double Totaldecapsulas { get => totalDeCapsulas; set => totalDeCapsulas = value; }
    ///<param name="ConsumoDeAguaUnidadCafe">
    ///Esta variable la hemos tenido que extraer del metodo y le hemos tenido que reemplazar el nombre ya que este era poco
    ///especidico
    /// </param>
    static const double ConsumoDeAguaUnidadCafe = 0.1;
    ///<sumary>
    ///Aqui realizaremos una refactorizacion de renombre ya que los variables tienen un nombre poco especicfico
    ///ademas de eliminar los elementos this ya que estos ya no seran necesarios
    ///</sumary>
    /// <param name="marcaMaquina">Valor de tipo string en el cual se indica la marca de la cafetera</param>
    /// <param name="referenciaModelo">Valor de tipo string en el cual se indica la referencia del modelo de la cafetera</param>
    /// <param name="cantidadAgua">Valor de tipo double en el cual se la cantidadd de agua que tiene la cafetera</param>
    /// <param name="totalDeCapsulas">Valor de tipo double en el cual se indica el total de capsulas que tiene la cafetera</param>

    public cafetera(string marcaMaquina, string referenciaModelo, double cantidadAgua, double totalDeCapsulas)
    {
        MarcaMaquina = marcaMaquina;
        RefereciaModelo = referenciaModelo;
        Totaldecapsulas = totalDeCapsulas;
        CantidadAgua = cantidadAgua;
    }
    /// <summary>
    /// Este metodo permite saber los niveles de agua que tiene la maquina de cafe tras realizar un consumo de "x" cafes
    /// </summary>
    /// <param name="numeroCafe">Valor de tipo double el cual especifica el numero de cafes que se van a realizar</param>
    /// <returns>Un string que indicara la cantidad de agua que tenemos</returns>
    public string ObtenerNivelesAgua(double numeroCafe)
    {
        CantidadAgua = CantidadAgua - numeroCafe * ConsumoDeAguaUnidadCafe;

        if (CantidadAgua < 0.1)
        {
            CantidadAgua = 0;
            return "Falta agua en el depósito, por favor, revisar los niveles.";
        }
        else
        {
            return "Quedan" + CantidadAgua + " centilitros";
        }
    }
    /// <summary>
    /// Este metodo permite saber si se puede o no realizar un cafe
    /// </summary>
    /// <param name="numeroCafe">Valor de tipo double el cual especifica el numero de cafes que se van a realizar</param>
    /// <returns>Un string que indicara si se necesitan capsulas o en caso negativo el total de capsulas que hay</returns>
    public string ObtenerConsumoCapsulas(double numeroCafe)
    {
        Totaldecapsulas = Totaldecapsulas - numeroCafe;

        if (Totaldecapsulas < 0)
        {
            Totaldecapsulas = 0;
            return "Faltan cápsulas en el depósito, por favor, compre cápsulas.";
        }
        else
        {
            return "Quedan" + Totaldecapsulas + "unidades";
        }
    }
    /// <summary>
    /// este metodo sirve para reponer capsulas a la cafetera
    /// </summary>
    /// <param name="cantidadCapsulas">valor de tipo double que refleja la cantidad de capsulas que se van a recargar</param>
    public double ReponerCapsulas(double cantidadCapsulas)
    {
        ///<summary>
        /// aqui hemos tenido que eliminar el return ya que al estar modificando una propiedad de la clase este no es necesario 
        /// ademas de sutituir el "=" por un "+=" ya que este le da mas elegancia al codigo
        /// </summary>
        Totaldecapsulas += cantidadCapsulas;
    }
    /// <summary>
    /// este metodo sirve para reponer los niveles de agua de la cafetera
    /// </summary>
    /// <param name="litrosReponer">valor de tipo double que refleja la cantidad de litros de agua que queremos reponer</param>
    public double ReponerNivelesAgua(double litrosReponer)
    {
        CantidadAgua += litrosReponer;
    }
    ///<remarks>
    ///el metodo verEspecificacion ha sido eliminado ya que no es usado en ningun momento del codigo
    /// </remarks>
}


class ejemplodemicafetera
{
    static void main()
    {
        ///<summary>
        ///<para>En un principio crearemos una cafetera pasandole los datos indicados en el constructor de la clase</para>
        ///<para>Despues mostraremos por pantalla la cantidad de agua de la cafetera es decir 0.6</para>
        ///<para>acto seguido llamaremos al metodo ObtenerConsumoCapsulas pasandole un consumo de 5 cafes y en consecuencia 
        ///comprobaremos si el total de capsulas ha disminuido</para>
        ///<para>Ahora llamaremos los niveles de agua pasandole un consumo de 5 cafes y comprobaremos tras esto la cantidas de agua que hay</para>
        ///<para>Tras esto repondremos los niveles de agua y los mostraremos por pantalla para ver si estos han aumentado y posteriormente haremos 
        ///lo mismo con las capsulas</para>
        /// </summary>
        cafetera cafeteraEjemplo = new cafetera("EspressoBarista", "Procoffee", cantidadAgua: 0.6, totalDeCapsulas: 7);

        Console.WriteLine(cafeteraEjemplo.CantidadAgua);
        Console.WriteLine(cafeteraEjemplo.ObtenerConsumoCapsulas(numeroCafe: 5));
        Console.WriteLine(cafeteraEjemplo.Totaldecapsulas);
        Console.WriteLine(cafeteraEjemplo.ObtenerNivelesAgua(numeroCafe: 5));
        Console.WriteLine(cafeteraEjemplo.CantidadAgua);
        cafeteraEjemplo.ReponerNivelesAgua(litrosReponer: 0.5);
        Console.WriteLine(cafeteraEjemplo.CantidadAgua);
        cafeteraEjemplo.ReponerCapsulas(cantidadCapsulas: 3);
        Console.WriteLine(cafeteraEjemplo.Totaldecapsulas);
    }
}