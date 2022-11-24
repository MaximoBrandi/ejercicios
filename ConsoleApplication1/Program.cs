using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


/* Es necesario anadir la posibilidad de eliminar y modificar entradas en el visor de empleados
 al mismo tiempo que deberian de poder verse un limite de 10 por pantalla y toda la informacion 
 de ellos en forma de tabla, y al seleccionarlo ver las posibles acciones sobre el empleado*/

namespace ConsoleApplication1
{

    internal class Program
    {
        static void Main(string[] args)
        {
            FileSystem fileSystem = new FileSystem();
            while (true)
            {
                Console.Clear();
                if (File.Exists(@"C:\Users\" + Environment.UserName + @"\AppData\Local\Temp\Working\Ex12.2\Listado.txt") && !fileSystem.Cache().ContainsKey("TemporaryFiles"))
                {
                    fileSystem.Inicio(true);
                }
                else if (File.Exists(@"C:\Users\" + Environment.UserName + @"\Documents\Working\Ex12.2\Listado.txt") && !fileSystem.Cache().ContainsKey("TemporaryFiles"))
                {
                    fileSystem.Inicio(false);
                }
                else if (!fileSystem.Cache().ContainsKey("TemporaryFiles"))
                {
                    Console.WriteLine("La aplicacion actual utiliza archivos almacenados para su correcto funcionamiento, desea guardarlos de forma temporal?\n (y=yes\n\\n=no)");
                    switch (Console.ReadKey().KeyChar)
                    {
                        case 'y':
                            fileSystem.Inicio(true);
                            break;
                        case 'n':
                            fileSystem.Inicio(false);
                            break;
                    }
                }
                Console.Clear();
                Console.WriteLine("Ejercicio 12.2 Máximo Prandi\n\nBienvenido, ingrese la accion que desea realizar\n1. Generar empleado\n2. Ver empleados\n3. Gestion de archivos");
                if (!fileSystem.Listado().ContainsKey(@"C:\Users\Desarrollo\Documents\Working\Ex12.2\Lists\Ejemplo.txt"))
                {
                    Console.Write("3. Descargar ejemplo de prueba\n4.Gestion de archivos");
                    Console.Write(fileSystem.Listado().First().Key);
                }
                switch (Console.ReadKey().KeyChar.ToString())
                {
                    case "1":
                        Console.Clear();
                        
                                if (fileSystem.Listado().Count > 1)
                        {
                            Console.WriteLine("Ejercicio 12.2 Máximo Prandi\n\nSelecciona un archivo de listado");
                            for (int j = 0; j < fileSystem.Listado().Count; j++)
                            {
                                Console.WriteLine("  "+fileSystem.Listado()[(j + 1).ToString()].Split('/')[1]);
                            }
                            int counter = 1;
                            string line;
                            Console.WriteLine("Seleccion:  1");
                            var originalpos = Console.CursorTop;
                            Console.SetCursorPosition(0, 0);
                            Console.WriteLine("█");

                            var k = Console.ReadKey();
                            var i = 0;
                            while (k.Key != ConsoleKey.Enter)
                            { 
                                if (k.Key == ConsoleKey.DownArrow) 
                                {
                                    Console.SetCursorPosition(0, i);
                                    Console.WriteLine(" ");
                                    if (i >= counter - 2)
                                    {
                                        i = 0;
                                    } else
                                    {
                                        i++;
                                    }
                                        
                                    Console.SetCursorPosition(0, i);
                                    Console.WriteLine("█");
                                    Console.SetCursorPosition(12, originalpos -1);
                                    Console.Write(i +1);
                                }
                                k = Console.ReadKey();
                                if (k.Key == ConsoleKey.Enter)
                                {
                                    try
                                    {
                                        Console.Clear();
                                        fileSystem.cargarListado(fileSystem.Listado()[(i + 1).ToString()].Split('/')[1]);
                                    }
                                        
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex);
                                        throw;
                                    }
                                }
                            }
                        }
                        else if (fileSystem.Listado().Count == 0)
                        {
                            Console.WriteLine("No existen archivos de listado");
                            Console.ReadKey();
                            break;
                        }else
                        {
                            fileSystem.cargarListado(fileSystem.Listado().First().Key);
                        }
                        Console.Clear();
                        Console.WriteLine("Ejercicio 12.2 Máximo Prandi\n\n¿Que deseas ingresar?\n1. Comerciante\n2. Repartidor");
                        switch (Console.ReadKey().KeyChar.ToString())
                        {
                            case "2":
                                Console.Clear();
                                try
                                {
                                    using (StreamWriter fs = new StreamWriter(fileSystem.Employee, true))
                                    {
                                        fs.Write("Tipo:Comercial/Plus:no");
                                        Console.WriteLine("Ejercicio 12.2 Máximo Prandi\n\nIngresa un nombre para el empleado");
                                        fs.Write("/Nombre:" + Console.ReadLine());

                                        Console.Clear();

                                        Console.WriteLine("Ejercicio 12.2 Máximo Prandi\n\nIngresa un salario para el empleado");
                                        fs.Write("/Salario:" + Console.ReadLine());

                                        Console.Clear();

                                        Console.WriteLine("Ejercicio 12.2 Máximo Prandi\n\nIngresa una edad para el empleado");
                                        fs.Write("/Edad:" + Console.ReadLine());

                                        Console.Clear();

                                        Console.WriteLine("Ejercicio 12.2 Máximo Prandi\n\nIngresa una comision para el empleado");
                                        fs.WriteLine("/Comision:" + Console.ReadLine());
                                        fs.Close();
                                    }
                                    Console.ReadKey();
                                }
                                catch (Exception Ex)
                                {
                                    Console.WriteLine(Ex.ToString());
                                }

                                Console.ReadKey();
                                break;
                            case "1":
                                Console.Clear();
                                try
                                {
                                    using (StreamWriter fs = new StreamWriter(fileSystem.Employee, true))
                                    {
                                        fs.Write("Tipo:Repartidor/Plus:no");
                                        Console.WriteLine("Ejercicio 12.2 Máximo Prandi\n\nIngresa un nombre para el empleado");
                                        fs.Write("/Nombre:" + Console.ReadLine());

                                        Console.Clear();

                                        Console.WriteLine("Ejercicio 12.2 Máximo Prandi\n\nIngresa un salario para el empleado");
                                        fs.Write("/Salario:" + Console.ReadLine());

                                        Console.Clear();

                                        Console.WriteLine("Ejercicio 12.2 Máximo Prandi\n\nIngresa una edad para el empleado");
                                        fs.Write("/Edad:" + Console.ReadLine());

                                        Console.Clear();

                                        Console.WriteLine("Ejercicio 12.2 Máximo Prandi\n\nIngresa una zona para el empleado");
                                        fs.WriteLine("/Zona:" + Console.ReadLine());
                                        fs.Close();
                                    }
                                    Console.ReadKey();
                                }
                                catch (Exception Ex)
                                {
                                    Console.WriteLine(Ex.ToString());
                                }

                                Console.ReadKey();
                                break;
                            default:
                                Console.Clear();
                                Console.WriteLine("Error");
                                Console.ReadKey();
                                break;
                        }

                        Console.ReadKey();
                        break;
                    case "2":
                        Console.Clear();
                        if (fileSystem.Listado().Count > 1)
                        {
                            Console.WriteLine("Ejercicio 12.2 Máximo Prandi\n\nSelecciona un archivo de listado");
                            for (int j = 0; j < fileSystem.Listado().Count; j++)
                            {
                                Console.WriteLine("  "+fileSystem.Listado()[(j + 1).ToString()].Split('/')[1]);
                            }
                            int counter = 1;
                            string line;
                            Console.WriteLine("Seleccion:  1");
                            var originalpos = Console.CursorTop;
                            Console.SetCursorPosition(0, 0);
                            Console.WriteLine("█");

                            var k = Console.ReadKey();
                            var i = 0;
                            while (k.Key != ConsoleKey.Enter)
                            { 
                                if (k.Key == ConsoleKey.DownArrow) 
                                {
                                    Console.SetCursorPosition(0, i);
                                    Console.WriteLine(" ");
                                    if (i >= counter - 2)
                                    {
                                        i = 0;
                                    } else
                                    {
                                        i++;
                                    }
                                        
                                    Console.SetCursorPosition(0, i);
                                    Console.WriteLine("█");
                                    Console.SetCursorPosition(12, originalpos -1);
                                    Console.Write(i +1);
                                }
                                k = Console.ReadKey();
                                if (k.Key == ConsoleKey.Enter)
                                {
                                    try
                                    {
                                        Console.Clear();
                                        fileSystem.cargarListado(fileSystem.Listado()[(i + 1).ToString()].Split('/')[1]);
                                    }
                                        
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex);
                                        throw;
                                    }
                                }
                            }
                        }
                        else if (fileSystem.Listado().Count == 0)
                        {
                            Console.WriteLine("No existen archivos de listado");
                            Console.ReadKey();
                            break;
                        }else
                        {
                            fileSystem.cargarListado(fileSystem.Listado().First().Key);
                        }
                        try
                        {
                            using (StreamReader archive = new StreamReader(fileSystem.Employee))
                            {
                                Dictionary <string, string> Empleados = new Dictionary<string, string>();
                                int counter = 1;
                                string line;
                                while ((line = archive.ReadLine()) != null)
                                {
                                    Console.WriteLine("  "+ line.Split('/')[0].Split(':')[1]+" "+line.Split('/')[2].Split(':')[1]);
                                    Empleados.Add(counter.ToString(), line);
                                    counter++;
                                }
                                Console.WriteLine("Seleccion:  1");
                                var originalpos = Console.CursorTop;
                                Console.SetCursorPosition(0, 0);
                                Console.WriteLine("█");

                                var k = Console.ReadKey();
                                var i = 0;
                                while (k.Key != ConsoleKey.Enter)
                                {
                                    if (k.Key == ConsoleKey.DownArrow)
                                    {
                                        Console.SetCursorPosition(0, i);
                                        Console.WriteLine(" ");
                                        if (i >= counter - 2)
                                        {
                                            i = 0;
                                        } else
                                        {
                                            i++;
                                        }
                                        
                                        Console.SetCursorPosition(0, i);
                                        Console.WriteLine("█");
                                        Console.SetCursorPosition(12, originalpos -1);
                                        Console.Write(i +1);
                                    }
                                    k = Console.ReadKey();
                                    if (k.Key == ConsoleKey.Enter)
                                    {
                                        try
                                        {
                                            Console.Clear();
                                            string[] pistacho = Empleados[(i + 1).ToString()].Split('/');
                                            if (pistacho[0].Split(':')[1] == "Repartidor")
                                            {
                                                Console.WriteLine("Empleado: {0}\nCargo: {1}\nEdad: {2}\nZona: {3}\nPlus: {4}\n\n", pistacho[2].Split(':')[1], pistacho[0].Split(':')[1], pistacho[4].Split(':')[1], pistacho[5].Split(':')[1], pistacho[1].Split(':')[1]);
                                            }
                                            else
                                            {
                                                Console.WriteLine("Empleado: {0}\nCargo: {1}\nEdad: {2}\nComision: {3}\nPlus: {4}\n\n", pistacho[2].Split(':')[1], pistacho[0].Split(':')[1], pistacho[4].Split(':')[1], pistacho[5].Split(':')[1], pistacho[1].Split(':')[1]);
                                            }
                                            
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine(ex);
                                            throw;
                                        }
                                    }
                                }
                            }
                        }
                        catch (Exception Ex)
                        {
                            Console.WriteLine("No existen empleados registrados");
                        }
                        Console.ReadKey();
                        break;
                    case "3":
                        if (!fileSystem.Listado().ContainsKey(@"C:\Users\Desarrollo\Documents\Working\Ex12.2\Lists\Ejemplo.txt"))
                        {
                            Console.Clear();
                            Console.WriteLine("Ejercicio 12.2 Máximo Prandi\n\n¿Desea descargar el archivo XXXX (XXX)?\n1. Si\n2. No");
                            switch (Console.ReadKey().KeyChar.ToString())
                            {
                                case "1":
                                    Console.Clear();
                                    Console.WriteLine("Ejercicio 12.2 Máximo Prandi\n\n");
                                    Console.Write("Descargar");
                                    fileSystem.descargarListado("https://testing5.lac-lyp.com.ar/Ejemplo.txt","Ejemplo.txt");
                                    Thread thread2 = new Thread(ThreadWork.Load);
                                    thread2.Start();
                                    Console.ReadLine();
                                    thread2.Abort();
                                    break;
                                case "2":
                                    break;
                                default:
                                    break;
                            }
                        }
                        else
                        {
                            /*Aqui deberia colocar los archivos de listado y el poder borrarlos, modificarlos, eliminarlos, renombrarlos entre otras posibles acciones*/
                        }
                        break;
                    case "exit":
                        Console.Clear();
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Error");
                        Console.ReadKey();
                        break;
                }
            }

        }
    }
}