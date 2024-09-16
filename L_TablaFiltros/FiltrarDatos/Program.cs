// See https://aka.ms/new-console-template for more information
using System.Data;
using System.Text;

public class Program
{
    public static string ImprimirTablas(DataTable tabla)
    {

        StringBuilder resultado = new StringBuilder();
        foreach (DataRow fila in tabla.Rows)
        {
            // Crear una cadena para la fila
            string filaTexto = string.Join(", ", fila.ItemArray);
            resultado.AppendLine(filaTexto);

        }
        return resultado.ToString();
    }

    public static DataTable CrearTablaPersonas()
    {
        // Crear una tabla de ejemplo
        DataTable tblPersonas = new DataTable();
        tblPersonas.Columns.Add("Nombre", typeof(string));
        tblPersonas.Columns.Add("DNI", typeof(string));

        //Agregar filas a la tabla
        tblPersonas.Rows.Add("Franco", "70207528");
        tblPersonas.Rows.Add("Ana", "87654321");
        tblPersonas.Rows.Add("Juan", "11223344");
        tblPersonas.Rows.Add("Andres", "70207528");

        return tblPersonas;
    }

    static void Main(string[] args)    {

        /*
        //Filtrar las filas donde el DNI sea 70207528

            DataRow[] filasFiltradas = tblPersonas.Select("DNI = '70207528'");

        // Mostrar los resultados filtrados

            foreach (DataRow row in filasFiltradas)
            {
                Console.WriteLine($"Nombre: {row["Nombre"]} , DNI: {row["DNI"]}");
            }

        //Este código solo te permite capturar las filas que cumplen con una condición específica.

        */

        //********************** 1.Uso del metodo SELECT ****************************************************


        // =================================================================================
        // Propósito: Filtrar una tabla de personas para encontrar
        // las filas donde el DNI sea igual a '70207528'.
        // Si se encuentran filas que coincidan con el filtro,
        // se crea una nueva tabla con esas filas filtradas.
        // En caso contrario, se informa que no se encontraron
        // filas que coincidan. Se maneja cualquier excepción
        // inesperada durante el proceso.
        // =================================================================================

        DataTable tablaPersonas = CrearTablaPersonas();
        DataTable tablaFiltrada = null;   //Coloco el DataTable fuera del if o try, caso contrario habrá error indicando que la variable no existe en el contexto actual.

        try
        {
            DataRow[] filasFiltradas = tablaPersonas.Select("DNI = '70207528'");

            if (filasFiltradas.Length > 0)
            {
                //Crear una nueva tabla para las filas filtradas
                tablaFiltrada = filasFiltradas.CopyToDataTable();
            }
            else
            { Console.WriteLine("No se encontraron filas que coincidan con el filtro"); }

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocurrió un error inesperado: {ex.Message}");
        }




        //Mostrar resultados
        string resultado = ImprimirTablas(tablaFiltrada);
        Console.WriteLine(resultado);
    }
}














/*
    //Motsrar Resultados
        foreach (DataRow row in tablaFiltrada.Rows)
        {
            Console.WriteLine($"Nombre: {row["Nombre"]} , DNI: {row["DNI"]}");
        }
 */     