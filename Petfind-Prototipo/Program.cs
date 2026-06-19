// Petfind - Prototipo 2
Usuario[] usuarios = new Usuario[100];
Mascota[] mascotas = new Mascota[100];
int totalMascotas = 0;
int totalUsuarios = 0;
bool sesionIniciada = false;
string usuarioActivo = "";
int menu = 0;
int mascotasExtraviadas = 0;

void MostrarCarga(int segundos)
{
    try
    {
        for (int i = 0; i < segundos; i++)
        {
            Thread.Sleep(350);
            Console.Write(". ");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error al mostrar carga: {ex.Message}");
    }
}

void MostrarError(string mensaje)
{
    try
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(mensaje);
        Console.ResetColor();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {mensaje} - {ex.Message}");
    }
}

void MostrarExito(string mensaje)
{
    try
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(mensaje);
        Console.ResetColor();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Éxito: {mensaje} - {ex.Message}");
    }
}

void MostrarAdvertencia(string mensaje)
{
    try
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(mensaje);
        Console.ResetColor();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Advertencia: {mensaje} - {ex.Message}");
    }
}

string ObtenerEntrada(string prompt)
{
    try
    {
        while (true)
        {
            Console.Write(prompt);
            string entrada = Console.ReadLine() ?? "";

            if (!string.IsNullOrWhiteSpace(entrada))
            {
                return entrada;
            }
            else
            {
                MostrarError("Entrada vacía. Por favor, intenta de nuevo.");
            }
        }
    }
    catch (Exception ex)
    {
        MostrarError($"Error al obtener entrada: {ex.Message}");
        return "";
    }
}

void inicio()
{
    try
    {
        while (sesionIniciada == false)
        {
            Console.WriteLine("\n--- Bienvenido a Petfind ---");
            Console.WriteLine("¿Deseas iniciar sesión o registrarte? (escribe: iniciar o registrar )");
            string opcion = Console.ReadLine() ?? "";

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
                MostrarError("Opción no válida.");
            }
        }

        Console.Clear();
        Console.WriteLine("\n========================================");
        Console.WriteLine($"¡Has entrado al sistema principal, {usuarioActivo}!");
        Console.WriteLine("========================================");

        MostrarCarga(5);
        Console.Clear();
    }
    catch (Exception ex)
    {
        MostrarError($"Error en la inicialización: {ex.Message}");
    }
}

void menuPrincipal()
{
    try
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
                MostrarError("Ha ingresado una opcion invalida. Ingrese un numero del 1 al 5");
                MostrarCarga(5);
                Console.Clear();
                continue;
            }

            switch (menu)
            {
                case 1:
                    registroMascota();
                    break;

                case 2:
                    reportarMascotaDesaparecida();
                    break;

                case 3:
                    mascotasDesaparecidas();
                    break;

                case 4:
                    billeteraPetPoints();
                    break;

                case 5:
                    salirPrograma();
                    break;

                default:
                    Console.Clear();
                    MostrarError("Ha ingresado una opcion invalida. Por favor, ingrese un numero del 1 al 5.");
                    MostrarCarga(5);
                    Console.Clear();
                    break;
            }

        } while (menu != 5);
    }
    catch (Exception ex)
    {
        MostrarError($"Error en el menú principal: {ex.Message}");
    }
}


void IniciarSesion()
{
    try
    {
        Console.WriteLine("\n--- Iniciar Sesión ---");
        string usuario = ObtenerEntrada("Usuario: ");
        string clave = ObtenerEntrada("Clave: ");

        if (usuario == "" || clave == "")
        {
            MostrarError("Usuario y clave son requeridos.");
            Thread.Sleep(1500);
            return;
        }

        bool usuarioExiste = false;

        for (int i = 0; i < totalUsuarios; i++)
        {
            if (usuarios[i].usuario == usuario)
            {
                usuarioExiste = true;

                if (usuarios[i].clave == clave)
                {
                    MostrarExito($"\n¡Bienvenido de nuevo, {usuarios[i].nombre}!");
                    sesionIniciada = true;
                    usuarioActivo = usuario;
                    break;
                }
                else
                {
                    MostrarError("Acceso denegado: La contraseña no coincide con el usuario.");
                }
                Thread.Sleep(1500);
                break;
            }
        }
        if (!usuarioExiste)
        {
            MostrarError("Acceso denegado: El usuario ingresado no está registrado en el sistema.");
            Thread.Sleep(1500);
        }
    }
    catch (Exception ex)
    {
        MostrarError($"Error al iniciar sesión: {ex.Message}");
        Thread.Sleep(1500);
    }
}

void Registrarse()
{
    try
    {
        Console.WriteLine("\n--- Registro ---");
        string nombre = ObtenerEntrada("Nombre completo: ");
        string usuario = ObtenerEntrada("Nombre de usuario: ");
        string telefono = ObtenerEntrada("Teléfono: ");
        string clave = ObtenerEntrada("Clave: ");

        if (nombre == "" || usuario == "" || telefono == "" || clave == "")
        {
            MostrarError("Todos los campos son requeridos. Intenta de nuevo.");
            Thread.Sleep(500);
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
            MostrarExito("¡Registro exitoso! Ahora puedes iniciar sesión.");
        }
        else
        {
            MostrarAdvertencia("No hay espacio para más usuarios.");
        }
    }
    catch (Exception ex)
    {
        MostrarError($"Error al registrarse: {ex.Message}");
    }
}


void registroMascota()
{
    try
    {
        bool otraMascota = false;
        do
        {
            bool mascotaAdicional = false;
            string registrarMascotaAdicional = "";
            Console.Clear();
            MostrarAdvertencia("   -- Registraremos su mascota  --  ");

            string nombre = ObtenerEntrada("Nombre de su mascota: ");
            string especie = ObtenerEntrada("Especie: ");
            string raza = ObtenerEntrada("Raza: ");
            string color = ObtenerEntrada("Color de pelaje: ");

            Console.WriteLine(" - Información médica - ");

            string sangre = ObtenerEntrada("Tipo de sangre: ");
            string vacunas = ObtenerEntrada("Vacunas colocadas: ");
            string alergias = ObtenerEntrada("Alergias: ");
            string condicion = ObtenerEntrada("Condición especial: ");
            string rasgoCaracteristico = ObtenerEntrada("Algún rasgo físico característico: ");

            MostrarAdvertencia("\nRegistrando su mascota");

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
                MostrarAdvertencia("La base de datos de mascotas esta llena.");
            }

            MostrarCarga(5);
            Console.Clear();
            MostrarExito("Mascota registrada satisfactoriamente.");
            Thread.Sleep(600);
            Console.Clear();

            do
            {
                MostrarAdvertencia("  ==  Desea registrar otra mascota (si/no) ==  ");
                registrarMascotaAdicional = (Console.ReadLine() ?? "").ToLower();

                if (registrarMascotaAdicional == "si" || registrarMascotaAdicional == "no")
                {
                    mascotaAdicional = true;
                }
                else
                {
                    MostrarError("Ha ingresado una opcion invalida.");
                    MostrarCarga(5);
                    Console.Clear();
                }

            } while (mascotaAdicional != true);

            if (registrarMascotaAdicional == "si")
            {
                otraMascota = true;
                MostrarAdvertencia("Se registrara una nueva mascota");
                MostrarCarga(5);
                Console.Clear();
            }
            else if (registrarMascotaAdicional == "no")
            {
                MostrarAdvertencia("Volviendo al menu principal");
                MostrarCarga(5);
                otraMascota = false;
                Console.Clear();
            }

        } while (otraMascota != false);
    }
    catch (Exception ex)
    {
        MostrarError($"Error al registrar mascota: {ex.Message}");
    }
}

void reportarMascotaDesaparecida()
{
    try
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
            MostrarAdvertencia("\nNo tienes mascotas registradas.");
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
                    mascotasEncontrada = true;
                    mascotas[i].extraviada = true;
                    mascotasExtraviadas++;

                    MostrarExito($"\nMascota reportada como desaparecida exitosamente");
                    break;
                }
            }

            if (!mascotasEncontrada)
            {
                MostrarError("\nID de mascota no encontrado o no te pertenece. Intenta de nuevo.");
            }

            Console.WriteLine("Presiona cualquier boton para continuar");
            Console.ReadKey();
            Console.Clear();
        }
    }
    catch (Exception ex)
    {
        MostrarError($"Error al reportar mascota desaparecida: {ex.Message}");
    }
}

void mascotasDesaparecidas()
{
    try
    {
        Console.Clear();
        MostrarAdvertencia("Cargando mascotas desaparecidas");
        MostrarCarga(5);
        Console.Clear();

        if (mascotasExtraviadas == 0)
        {
            Console.Clear();
            MostrarExito("No hay mascotas desaparecidas reportadas\n\nVolviendo al menu");
            MostrarCarga(5);
            Console.Clear();
        }
        else if (mascotasExtraviadas >= 1)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Hay {mascotasExtraviadas} mascotas extraviadas: ");
            Console.ResetColor();

            MostrarExito("El listado de mascotas desaparecidas son: ");

            for (int i = 0; i < totalMascotas; i++)
            {
                if (mascotas[i].extraviada == true)
                {
                    MostrarAdvertencia($"#{i + 1}. ID: {mascotas[i].id} - Nombre: {mascotas[i].nombre} - Especie: {mascotas[i].especie} - Raza: {mascotas[i].raza}");
                    Console.WriteLine($" Rasgo característico: {mascotas[i].rasgoCaracteristico} - Dueño de mascota: {mascotas[i].duenoUsuario}\n");
                }
            }
            Console.WriteLine("Presiona cualquier boton para continuar");
            Console.ReadKey();
            Console.Clear();
        }
    }
    catch (Exception ex)
    {
        MostrarError($"Error al mostrar mascotas desaparecidas: {ex.Message}");
    }
}

void billeteraPetPoints()
{
    try
    {
        int puntosActuales = 500;
        int opcion = 0;

        while (opcion != 4)
        {
            Console.WriteLine("\n--- BIENVENIDO A BILLETERA PETPOINTS ---");
            Console.WriteLine("\n1. Registrar (Ganar) puntos. \n 2. Canjear puntos PetFind \n 3. Ver Puntos Actuales. \n 4. Salir.");
            Console.Write("Seleccione una opción (1-4): ");

            if (int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine();

                switch (opcion)
                {
                    case 1:
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
                                    MostrarExito("¡Gracias por tu reporte de avistamiento! Reporte procesado correctamente.");
                                    Console.WriteLine($"Se ha sumado tu recompensa de {RecompensaAvistamiento} PetPoints.");
                                    break;

                                case 2:
                                    int recompensaIntercepcion = 300;
                                    puntosActuales = puntosActuales + recompensaIntercepcion;
                                    MostrarExito("¡Gracias por ayudar a la comunidad! Reporte procesado correctamente.");
                                    Console.WriteLine($"Se ha sumado tu recompensa de {recompensaIntercepcion} PetPoints.");
                                    break;

                                default:
                                    MostrarAdvertencia("Opción de registro no válida. Regresando al menú principal.");
                                    break;
                            }


                            if (tipoRegistro == 1 || tipoRegistro == 2)
                            {
                                Console.WriteLine($"Tu nuevo saldo es de: {puntosActuales} puntos.");
                            }
                        }
                        else
                        {
                            MostrarError("\nError: Debe introducir un número entero (1 o 2) en el submenú.");
                        }
                        break;

                    case 2:
                        Console.WriteLine("Servicios disponibles:");
                        Console.WriteLine("\n1. Consulta Veterinaria General (Costo: 300 PetPoints) \n2. Cancelar operación");
                        Console.Write("Seleccione el número del servicio que desea canjear (1-2): ");

                        if (int.TryParse(Console.ReadLine(), out int opcionServicio))
                        {
                            Console.WriteLine();
                            switch (opcionServicio)
                            {
                                case 1:
                                    int costoServicio = 300;


                                    if (puntosActuales >= costoServicio)
                                    {
                                        puntosActuales = puntosActuales - costoServicio;
                                        MostrarExito("¡Solicitud procesada correctamente! Código de cupón generado.");
                                        Console.WriteLine($"Saldo restante: {puntosActuales} puntos.");
                                    }
                                    else
                                    {
                                        MostrarError($"Error: Saldo insuficiente en tu billetera PetPoints. Requieres {costoServicio} puntos y tienes {puntosActuales}.");
                                    }
                                    break;

                                case 2:
                                    MostrarAdvertencia("Operación cancelada por el usuario.");
                                    break;

                                default:
                                    MostrarAdvertencia("Opcion no valida. Regresando al menu principal");
                                    break;
                            }
                        }
                        else
                        {
                            MostrarError("\nError: Debe introducir un número entero válido (1 o 2).");
                        }
                        break;

                    case 3:
                        Console.WriteLine($"Tu saldo disponible es: {puntosActuales} PetPoints.");
                        break;

                    case 4:
                        MostrarExito("Gracias por usar billetera PetFind. ¡Hasta luego!");
                        break;

                    default:
                        MostrarError("Opción no válida. Por favor, seleccione un número del 1 al 4.");
                        break;
                }
            }
            else
            {
                MostrarError("\nError: Entrada inválida. Por favor, digite un número del 1 al 4.");
            }
        }
    }
    catch (Exception ex)
    {
        MostrarError($"Error en la billetera de PetPoints: {ex.Message}");
    }
}

void salirPrograma()
{
    try
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n========================================");
        Console.WriteLine("Gracias por usar Petfind.");
        Console.WriteLine("¡Vuelve pronto!");
        Console.WriteLine("========================================");
        Console.ResetColor();

        MostrarCarga(3);
        Console.WriteLine();
        sesionIniciada = false;
        usuarioActivo = "";
        menu = 5;
        Console.Clear();
    }
    catch (Exception ex)
    {
        MostrarError($"Error al salir: {ex.Message}");
    }
}

void Main()
{
    try
    {
        inicio();
        menuPrincipal();
    }
    catch (Exception ex)
    {
        MostrarError($"Error fatal en el programa: {ex.Message}");
    }
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