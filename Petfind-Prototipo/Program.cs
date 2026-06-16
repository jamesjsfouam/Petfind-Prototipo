// Petfind - Prototipo // Inicio de sesion 
// Petfind - Prototipo // Inicio de sesion 
Usuario[] usuarios = new Usuario[100];
Mascota[] mascotas = new Mascota[100];
int totalMascotas = 0;
int totalUsuarios = 0;
bool sesionIniciada = false;
string usuarioActivo = "";
int menu = 0;

void inicio()
{
    while (sesionIniciada == false)
    {
        Console.WriteLine("\n--- Bienvenido a Petfind ---");
        Console.WriteLine("¿Deseas iniciar sesión o registrarte? (escribe: iniciar o registrar)");
        string opcion = Console.ReadLine()!;

        if (opcion == "registrar" || opcion == "1")
        {
            Registrarse();
            Console.Clear();
        }
        else if (opcion == "iniciar" || opcion == "2")
        {
            IniciarSesion();

            Console.Clear();

        }
        else
        {
            Console.WriteLine("Opción no válida.");
        }
    }

    // Todo el código del menú principal (registrar mascota, buscar, etc.) va a partir de aquí
    Console.Clear();
    Console.WriteLine("\n========================================");
    Console.WriteLine($"¡Has entrado al sistema principal, {usuarioActivo}!");
    Console.WriteLine("========================================");


    //Un temporizador rapido para entrar al menu y dejar todo lo anterior limpio.
    for (int i = 0; i < 5; i++)
    {
        Thread.Sleep(350);
        Console.Write(". ");
    }
    Console.Clear();
}


//Ahora si empieza el menu
void menuPrincipal()
{
    do
    {
        Console.WriteLine(" --  Menu  -- ");
        Console.WriteLine("1. Registrar mascota\n2. Reportar mascota desaparecida\n3. Reportes de desaparecidos\n4. Cartera de petpoints\n5. Salir");
        Console.Write("\nIngrese la opcion a realizar: ");
        if (int.TryParse(Console.ReadLine(), out menu))
        {

        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Ha ingresado una opcion invalida. Ingrese un numero del 1 al 5");
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(350);
                Console.Write(". ");
            }
            Console.ResetColor();
            Console.Clear();

        }
        switch (menu)
        {
            // Registrar mascota
            case 1:
                registroMascota();
                break;

            // Reportar mascota, o sea para decir que tenemos la nuestra en desaparecidos
            case 2:
                reportarMascotaDesaparecida();
                break;

            // Ver que mascotas estan desaparecidas
            case 3:
                mascotasDesaparecidas();
                break;

            // Cuantos puntos tenemos de haber encontrado a las mascotas
            case 4:
                billeteraPetPoints();
                break;

            // Salir del sistema
            case 5:
                salirPrograma();
                break;


            //Cualquier otra opcion que no sea una de las anteriores
            default:
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ha ingresado una opcion invalida. Por favor, ingrese un numero del 1 al 5.");
                for (int i = 0; i < 5; i++)
                {
                    Thread.Sleep(350);
                    Console.Write(". ");
                }
                Console.ResetColor();
                Console.Clear();
                break;


        }

    } while (menu != 5);
}


void Registrarse()
{
    Console.WriteLine("\n--- Registro ---");
    Console.Write("Nombre completo: ");
    string nombre = Console.ReadLine()!;

    Console.Write("Nombre de usuario: ");
    string usuario = Console.ReadLine()!;

    Console.Write("Teléfono: ");
    string telefono = Console.ReadLine()!;

    Console.Write("Clave: ");
    string clave = Console.ReadLine()!;

    if (nombre == "" || usuario == "" || telefono == "" || clave == "")
    {
        Console.WriteLine("Todos los campos son requeridos. Intenta de nuevo.");
        return;
    }

    Usuario nuevoUsuario = new Usuario
    {
        nombre = nombre,
        usuario = usuario,
        telefono = telefono,
        clave = clave,
        petPoints = 0
    };

    if (totalUsuarios < usuarios.Length)
    {
        usuarios[totalUsuarios] = nuevoUsuario;
        totalUsuarios++;
        Console.WriteLine("¡Registro exitoso! Ahora puedes iniciar sesión.");
    }
    else
    {
        Console.WriteLine("No hay espacio para más usuarios.");
    }
}

void IniciarSesion()
{
    Console.WriteLine("\n--- Iniciar Sesión ---");
    Console.Write("Usuario: ");
    string usuario = Console.ReadLine()!;

    Console.Write("Clave: ");
    string clave = Console.ReadLine()!;

    if (usuario == "" || clave == "")
    {
        Console.WriteLine("Usuario y clave son requeridos.");
        return;
    }

    bool encontrado = false;
    for (int i = 0; i < totalUsuarios; i++)
    {
        if (usuarios[i].usuario == usuario && usuarios[i].clave == clave)
        {
            Console.WriteLine($"\n¡Bienvenido de nuevo, {usuarios[i].nombre}!");
            encontrado = true;
            sesionIniciada = true;
            usuarioActivo = usuario;

            sesionIniciada = true;
            usuarioActivo = usuario;
            break;
        }
    }

    if (encontrado == false)
    {
        Console.WriteLine("Usuario o clave incorrectos. Acceso denegado.");
    }
}


void registroMascota()
{
    // Vamos a registrar a la mascotita a partir de aqui
    // Elaborado por Peña
    bool otraMascota = false;
    do
    {
        bool mascotaAdicional = false;
        string registrarMascotaAdicional = "";
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("   -- Registraremos su mascota  --  ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Nombre de su mascota: ");
        string nombre = Console.ReadLine()!;

        Console.Write("Especie: ");
        string especie = Console.ReadLine()!;

        Console.Write("Raza: ");
        string raza = Console.ReadLine()!;

        Console.Write("Color de pelaje: ");
        string color = Console.ReadLine()!;

        Console.WriteLine(" - Informacion medica - ");

        Console.Write("Tipo de sangre: ");
        string sangre = Console.ReadLine()!;

        Console.Write("Vacunas colocadas: ");
        string vacunas = Console.ReadLine()!;

        Console.Write("Alergias: ");
        string alergias = Console.ReadLine()!;

        Console.Write("Condicion especial: ");
        string condicion = Console.ReadLine()!;

        Console.Write("Algun rasgo fisico caracteristico: ");
        string rasgoCaracteristico = Console.ReadLine()!;

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nRegistrando su mascota");

        Mascota nuevaMascota = new Mascota
        {
            id = totalMascotas + 1,
            duenoUsuario = usuarioActivo,
            nombre = nombre,
            especie = especie,
            raza = raza,
            color = color,
            sangre = sangre,
            alergias = alergias,
            vacunas = vacunas,
            condicion = condicion,
            rasgoCaracteristico = rasgoCaracteristico,
            extraviada = false
        };

        if (totalMascotas < mascotas.Length)
        {
            mascotas[totalMascotas] = nuevaMascota;
            totalMascotas++;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("La base de datos de mascotas esta llena.");
            Console.ResetColor();

        }

        // Registrando mascota ...
        for (int i = 0; i < 5; i++)
        {
            Thread.Sleep(350);
            Console.Write(". ");
        }
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Clear();
        Console.WriteLine("Mascota registrada satisfactoriamente.");
        Thread.Sleep(600);
        Console.Clear();

        //Preguntando si se agregara una nueva mascota ...


        do
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  ==  Desea registrar otra mascota (si/no) ==  ");
            registrarMascotaAdicional = Console.ReadLine()!;

            if (registrarMascotaAdicional == "si" || registrarMascotaAdicional == "no")
            {
                mascotaAdicional = true;
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ha ingresado una opcion invalida.");

                for (int i = 0; i < 5; i++)
                {
                    Thread.Sleep(350);
                    Console.Write(". ");
                }
                Console.ResetColor();
                Console.Clear();
            }

        } while (mascotaAdicional != true);

        if (registrarMascotaAdicional == "si")
        {
            otraMascota = true;
            Console.WriteLine("Se registrara una nueva mascota");
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(350);
                Console.Write(". ");
            }
            Console.Clear();
        }
        else if (registrarMascotaAdicional == "no")
        {
            Console.WriteLine("Volviendo al menu principal");
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(350);
                Console.Write(". ");
            }
            otraMascota = false;
            Console.Clear();
        }


    } while (otraMascota != false);


}

void reportarMascotaDesaparecida()
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.DarkCyan;
    Console.WriteLine("========== REPORTAR MASCOTA DESAPARECIDA ==========");
    Console.ResetColor();

    bool tienemascotas = false;
    Console.WriteLine("\nTus mascotas registradas: ");
    for (int i = 0; i < totalMascotas; i++)
    {
        if (mascotas[i].duenoUsuario == usuarioActivo)
        {
            tienemascotas = true;
            string estado = mascotas[i].extraviada ? "[Desaparecida]" : "[En casa]";
            Console.WriteLine($"ID: {mascotas[i].id}");
            Console.WriteLine($"Nombre: {mascotas[i].nombre}");
            Console.WriteLine($"Especie: {mascotas[i].especie}");
            Console.WriteLine($"--> {estado} <--");
        }
    }
    if (!tienemascotas)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nNo tienes mascotas registradas.");
        Console.ResetColor();
        Console.WriteLine("Presiona cualquier boton para continuar");
        Console.ReadKey();
        Console.Clear();
        return;

    }
    Console.WriteLine("\nIngrese el id de la mascota que desea reportar como desaparecida o 0 para cancelar");
    if (int.TryParse(Console.ReadLine(), out int idMascota) && idMascota != 0)
    {
        bool mascotasEncontrada = false;

        for (int i = 0; i < totalMascotas; i++)
        {
            if (mascotas[i].id == idMascota && mascotas[i].duenoUsuario == usuarioActivo)
            {
                mascotas[i].extraviada = true;

                if (mascotas[i].extraviada == true)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"\nEsta mascota ya ha sido reportada como desaparecida");
                    Console.ResetColor();

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nMascota reportada como desaparecida exitosamente");
                    Console.ResetColor();
                }
                break;
            }

        }
        if (!mascotasEncontrada)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nID de mascota no encontrado o no te pertenece. Intenta de nuevo.");
            Console.ResetColor();
        }
        else
        {
            Console.WriteLine("Operacion cancelada.");
        }
        Console.ResetColor();
        Console.WriteLine("Presiona cualquier boton para continuar");
        Console.ReadKey();
        Console.Clear();
    }
}

void mascotasDesaparecidas()
{

}

void billeteraPetPoints()
{

}

void salirPrograma()
{

}

void Main()
{
    inicio();
    menuPrincipal();
    reportarMascotaDesaparecida();
}

Main();
struct Usuario
{
    public string nombre;
    public string usuario;
    public string telefono;
    public string clave;
    public int petPoints;
}

struct Mascota
{
    public int id;
    public string duenoUsuario;
    public string nombre;
    public string especie;
    public string raza;
    public string color;
    public string sangre;
    public string alergias;
    public string vacunas;
    public string condicion;
    public string rasgoCaracteristico;
    public bool extraviada;
}


