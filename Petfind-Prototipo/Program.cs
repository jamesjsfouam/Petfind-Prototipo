// Petfind - Prototipo // Inicio de sesion 
// Petfind - Prototipo // Inicio de sesion 
Usuario[] usuarios = new Usuario[100];
Mascota[] mascotas = new Mascota[100];
int totalMascotas = 0;
int totalUsuarios = 0;
bool sesionIniciada = false;
string usuarioActivo = "";
int menu = 0;
int mascotasExtraviadas = 0;

void inicio()
{
    while (sesionIniciada == false)
    {
        Console.WriteLine("\n--- Bienvenido a Petfind ---");
        Console.WriteLine("¿Deseas iniciar sesión o registrarte? (escribe: iniciar o registrar)");
        string opcion = Console.ReadLine();

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
    string nombre = Console.ReadLine();

    Console.Write("Nombre de usuario: ");
    string usuario = Console.ReadLine();

    Console.Write("Teléfono: ");
    string telefono = Console.ReadLine();

    Console.Write("Clave: ");
    string clave = Console.ReadLine();

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
    string usuario = Console.ReadLine();

    Console.Write("Clave: ");
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
    // Iniciando en programa

    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("Cargando mascotas desaparecidas");
    for (int i = 0; i < 5; i++)
    {
        Thread.Sleep(350);
        Console.Write(". ");
    }
    Console.ResetColor();
    Console.Clear();



    // Si no hay mascotas extraviadas
    if (mascotasExtraviadas == 0)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("No hay mascotas desaparecidas reportadas\n\nVolviendo al menu");
        for (int j = 0; j < 5; j++)
        {
            Thread.Sleep(350);
            Console.Write(". ");
        }
        Console.ResetColor();
        Console.Clear();
    }

    // pero si acaso si hay
    else if (mascotasExtraviadas >= 1)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Hay {mascotasExtraviadas} mascotas extraviadas: ");

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("El listado de mascotas desaparecidas son: ");

        Console.ForegroundColor = ConsoleColor.Yellow;
        for (int i = 0; i < totalMascotas; i++)
        {
            //Si hay alguna mascota extraviada, ademas agrupar las que tengan su bool como true
            if (mascotas[i].extraviada = true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                // ID, nombreMascota, Especie, Raza, RasgoCaracteristico, dueñoMascota
                Console.Write($"#{i + 1}. ID: {mascotas[i].id} - Nombre: {mascotas[i].nombre} - Especie: {mascotas[i].especie} - Raza: {mascotas[i].raza}\n Rasgo caracteristico: {mascotas[i].rasgoCaracteristico} - Dueño de mascota: {mascotas[i].duenoUsuario}\n");
            }
        }
    }
}

void billeteraPetPoints()
{
    //Wilmer Jose Ruiz Villavicencio
    int puntosActuales = 500;
    int opcion = 0;

    // Ciclo While para mantener el menu hasta ingresar una opcion valida.
    while (opcion != 4)
    {
        // Menu principal de Billetera PetPoints.
        Console.WriteLine("\n--- BIENVENIDO A BILLETERA PETPOINTS ---");
        Console.WriteLine("\n1. Registrar (Ganar) puntos. \n 2. Canjear puntos PetFind \n 3. Ver Puntos Actuales. \n 4. Salir.");
        Console.Write("Seleccione una opción (1-4): ");

        // TryParse valida que la entrada sea un numero entero.
        if (int.TryParse(Console.ReadLine(), out opcion))
        {
            Console.WriteLine();

            // Este switch evaluara la opcion numerica ingresada
            switch (opcion)
            {
                case 1:
                    // Submeno de registro de puntos.
                    //Dividido en dos ramas con cantidad de puntos de recompensa diferentes.
                    Console.WriteLine("--- OPCIONES DE REGISTRO ---");
                    Console.WriteLine("\n1. Registrar avistamiento de una mascota perdida (150 puntos). \n 2. Registrar una mascota encontrada e interceptada (300 puntos). \n 3. Volver al menú principal.");
                    Console.Write("Seleccione una opción (1/2): ");

                    if (int.TryParse(Console.ReadLine(), out int tipoRegistro))
                    {
                        Console.WriteLine();
                        switch (tipoRegistro)
                        {
                            case 1:
                                int RecompensaAvistamiento = 150;
                                puntosActuales = puntosActuales + RecompensaAvistamiento;
                                Console.WriteLine("¡Gracias por tu reporte de avistamiento! Reporte procesado correctamente.");
                                Console.WriteLine($"Se ha sumado tu recompensa de {RecompensaAvistamiento} PetPoints.");
                                break;

                            case 2:
                                int recompensaIntercepcion = 300;
                                puntosActuales = puntosActuales + recompensaIntercepcion;
                                Console.WriteLine("¡Gracias por ayudar a la comunidad! Reporte procesado correctamente.");
                                Console.WriteLine($"Se ha sumado tu recompensa de {recompensaIntercepcion} PetPoints.");
                                break;

                            default:
                                Console.WriteLine("Opción de registro no válida. Regresando al menú principal.");
                                break;
                        }

                        //Imprime el saldo actualizado segun opcion de registro.
                        if (tipoRegistro == 1 || tipoRegistro == 2)
                        {
                            Console.WriteLine($"Tu nuevo saldo es de: {puntosActuales} puntos.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nError: Debe introducir un número entero (1 o 2) en el submenú.");
                    }
                    break;

                case 2:
                    //Submenu para canjeo de puntos por servicios veterinarios.
                    Console.WriteLine("Servicios disponibles:");
                    Console.WriteLine("\n1. Consulta Veterinaria General (Costo: 300 PetPoints)n \n2. Cancelar operación");
                    Console.Write("Seleccione el número del servicio que desea canjear (1-2): ");

                    if (int.TryParse(Console.ReadLine(), out int opcionServicio))
                    {
                        Console.WriteLine();
                        switch (opcionServicio)
                        {
                            case 1:
                                int costoServicio = 300;

                                // Validacion de datos.
                                if (puntosActuales >= costoServicio)
                                {
                                    puntosActuales = puntosActuales - costoServicio;
                                    Console.WriteLine("¡Solicitud procesada correctamente! Código de cupón generado.");
                                    Console.WriteLine($"Saldo restante: {puntosActuales} puntos.");
                                }
                                else
                                {
                                    Console.WriteLine($"Error: Saldo insuficiente en tu billetera PetPoints. Requieres {costoServicio} puntos y tienes {puntosActuales}.");
                                }
                                break;

                            case 2:
                                Console.WriteLine("Operación cancelada por el usuario.");
                                break;

                            default:
                                Console.WriteLine("Opcion no valida. Regresando al menu principal");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nError: Debe introducir un número entero válido (1 o 2).");
                    }
                    break; // Rompemos el case 2 para volver al menu principal.

                case 3:
                    Console.WriteLine($"Tu saldo disponible es: {puntosActuales} PetPoints.");
                    break;

                case 4:
                    Console.WriteLine("Gracias por usar billetera PetFind. ¡Hasta luego!");
                    break;

                default:
                    Console.WriteLine("Opción no válida. Por favor, seleccione un número del 1 al 4.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("\nError: Entrada inválida. Por favor, digite un número del 1 al 4.");
        }
    }
}

void salirPrograma()
{

}

void Main()
{
    inicio();
    menuPrincipal();
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