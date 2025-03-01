using System;
using System.IO;

class Program
{
    // Rutas de las carpetas y archivos
    static string rutaLaboratorio = Path.Combine(Directory.GetCurrentDirectory(), "LaboratorioAvengers");
    static string rutaArchivoInventos = Path.Combine(rutaLaboratorio, "inventos.txt");
    static string rutaBackup = Path.Combine(rutaLaboratorio, "Backup");
    static string rutaArchivosClasificados = Path.Combine(rutaLaboratorio, "ArchivosClasificados");
    static string rutaProyectosSecretos = Path.Combine(rutaLaboratorio, "ProyectosSecretos");

    // Función principal
    static void Main(string[] args)
    {
        // Crear las carpetas necesarias al iniciar el programa
        CrearCarpeta(rutaLaboratorio);
        CrearCarpeta(rutaBackup);
        CrearCarpeta(rutaArchivosClasificados);
        CrearCarpeta(rutaProyectosSecretos);

        // Menú interactivo
        while (true)
        {
            Console.WriteLine("¡Bienvenido al Laboratorio de Tony Stark!");
            Console.WriteLine("1. Crear archivo de inventos");
            Console.WriteLine("2. Agregar un invento");
            Console.WriteLine("3. Leer inventos línea por línea");
            Console.WriteLine("4. Leer todo el contenido del archivo");
            Console.WriteLine("5. Copiar archivo a Backup");
            Console.WriteLine("6. Mover archivo a ArchivosClasificados");
            Console.WriteLine("7. Listar archivos en LaboratorioAvengers");
            Console.WriteLine("8. Eliminar archivo de inventos");
            Console.WriteLine("9. Salir");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    CrearArchivo();
                    break;
                case "2":
                    Console.Write("Ingrese el nombre del invento: ");
                    string invento = Console.ReadLine();
                    AgregarInvento(invento);
                    break;
                case "3":
                    LeerLineaPorLinea();
                    break;
                case "4":
                    LeerTodoElTexto();
                    break;
                case "5":
                    CopiarArchivo(rutaArchivoInventos, Path.Combine(rutaBackup, "inventos.txt"));
                    break;
                case "6":
                    MoverArchivo(rutaArchivoInventos, Path.Combine(rutaArchivosClasificados, "inventos.txt"));
                    break;
                case "7":
                    ListarArchivos(rutaLaboratorio);
                    break;
                case "8":
                    EliminarArchivo(rutaArchivoInventos);
                    break;
                case "9":
                    return;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        }
    }

    // Función para crear el archivo de inventos
    static void CrearArchivo()
    {
        try
        {
            // Verifica si el archivo ya existe
            if (!File.Exists(rutaArchivoInventos))
            {
                // Crea el archivo y lo cierra inmediatamente
                File.Create(rutaArchivoInventos).Close();
                Console.WriteLine("Archivo 'inventos.txt' creado exitosamente.");
            }
            else
            {
                Console.WriteLine("El archivo 'inventos.txt' ya existe.");
            }
        }
        catch (Exception ex)
        {
            // Manejo de excepciones: muestra un mensaje de error si algo sale mal
            Console.WriteLine("Error: No se pudo crear el archivo 'inventos.txt'. Verifica los permisos o si la carpeta existe.");
        }
    }

    // Función para agregar un invento al archivo
    static void AgregarInvento(string invento)
    {
        try
        {
            // Abre el archivo en modo append (agregar al final) y escribe el invento
            using (StreamWriter sw = File.AppendText(rutaArchivoInventos))
            {
                sw.WriteLine(invento);
            }
            Console.WriteLine($"Invento '{invento}' agregado exitosamente.");
        }
        catch (Exception ex)
        {
            // Manejo de excepciones: muestra un mensaje de error si algo sale mal
            Console.WriteLine("Error: No se pudo agregar el invento al archivo. Asegúrate de que el archivo no esté en uso o protegido.");
        }
    }

    // Función para leer el archivo línea por línea
    static void LeerLineaPorLinea()
    {
        try
        {
            // Verifica si el archivo existe
            if (File.Exists(rutaArchivoInventos))
            {
                // Abre el archivo y lo lee línea por línea
                using (StreamReader sr = new StreamReader(rutaArchivoInventos))
                {
                    string linea;
                    while ((linea = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(linea);
                    }
                }
            }
            else
            {
                Console.WriteLine("Error: El archivo 'inventos.txt' no existe. ¡Ultron debe haberlo borrado!");
            }
        }
        catch (Exception ex)
        {
            // Manejo de excepciones: muestra un mensaje de error si algo sale mal
            Console.WriteLine("Error: No se pudo leer el archivo. ¿Está seguro de que el archivo 'inventos.txt' si existe? :)");
        }
    }

    // Función para leer todo el contenido del archivo
    static void LeerTodoElTexto()
    {
        try
        {
            // Verifica si el archivo existe
            if (File.Exists(rutaArchivoInventos))
            {
                // Lee todo el contenido del archivo y lo muestra en la consola
                string contenido = File.ReadAllText(rutaArchivoInventos);
                Console.WriteLine(contenido);
            }
            else
            {
                Console.WriteLine("Error: El archivo 'inventos.txt' no existe. ¡Ultron debe haberlo borrado!");
            }
        }
        catch (Exception ex)
        {
            // Manejo de excepciones: muestra un mensaje de error si algo sale mal
            Console.WriteLine("Error: No se pudo leer el contenido del archivo. ¿Está seguro de que el archivo 'inventos.txt' existe y no está dañado?");
        }
    }

    // Función para copiar un archivo
    static void CopiarArchivo(string origen, string destino)
    {
        try
        {
            // Copia el archivo de origen al destino
            File.Copy(origen, destino, true);
            Console.WriteLine($"Archivo copiado a '{destino}' exitosamente.");
        }
        catch (Exception ex)
        {
            // Manejo de excepciones: muestra un mensaje de error si algo sale mal
            Console.WriteLine("Error: No se pudo copiar el archivo. Verifica si el archivo de origen existe o si el destino tiene permisos de escritura.");
        }
    }

    // Función para mover un archivo
    static void MoverArchivo(string origen, string destino)
    {
        try
        {
            // Mueve el archivo de origen al destino
            File.Move(origen, destino);
            Console.WriteLine($"Archivo movido a '{destino}' exitosamente.");
        }
        catch (Exception ex)
        {
            // Manejo de excepciones: muestra un mensaje de error si algo sale mal
            Console.WriteLine("Error: No se pudo mover el archivo. Asegúrate de que el archivo de origen exista y que el destino no tenga un archivo con el mismo nombre.");
        }
    }

    // Función para crear una carpeta
    static void CrearCarpeta(string nombreCarpeta)
    {
        try
        {
            // Verifica si la carpeta ya existe
            if (!Directory.Exists(nombreCarpeta))
            {
                // Crea la carpeta
                Directory.CreateDirectory(nombreCarpeta);
                Console.WriteLine($"Carpeta '{nombreCarpeta}' creada exitosamente.");
            }
        }
        catch (Exception ex)
        {
            // Manejo de excepciones: muestra un mensaje de error si algo sale mal
            Console.WriteLine("Error: No se pudo crear la carpeta. Verifica los permisos o si la ruta especificada es válida.");
        }
    }

    // Función para listar archivos en una carpeta
    static void ListarArchivos(string ruta)
    {
        try
        {
            // Obtiene todos los archivos en la carpeta especificada
            string[] archivos = Directory.GetFiles(ruta);
            if (archivos.Length > 0)
            {
                Console.WriteLine("Archivos en la carpeta:");
                foreach (string archivo in archivos)
                {
                    Console.WriteLine(Path.GetFileName(archivo));
                }
            }
            else
            {
                Console.WriteLine("No hay archivos en la carpeta.");
            }
        }
        catch (Exception ex)
        {
            // Manejo de excepciones: muestra un mensaje de error si algo sale mal
            Console.WriteLine("Error: No se pudo listar los archivos. Asegúrate de que la carpeta exista y tengas permisos para acceder a ella.");
        }
    }

    // Función para eliminar un archivo
    static void EliminarArchivo(string rutaArchivo)
    {
        try
        {
            // Verifica si el archivo existe
            if (File.Exists(rutaArchivo))
            {
                // Elimina el archivo
                File.Delete(rutaArchivo);
                Console.WriteLine("Archivo eliminado exitosamente.");
            }
            else
            {
                Console.WriteLine("Error: El archivo 'inventos.txt' no existe. De seguro Ultron lo borro, denuevo...");
            }
        }
        catch (Exception ex)
        {
            // Manejo de excepciones: muestra un mensaje de error si algo sale mal
            Console.WriteLine("Error: No se pudo eliminar el archivo. Verifica si el archivo existe, no está en uso o si tienes los permisos necesarios.");
        }
    }
}

