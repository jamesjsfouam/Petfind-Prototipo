// Petfind - Prototipo 3
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

void MostrarEncabezado(string titulo, string instrucciones)
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine($"========== {titulo} ==========");
    Console.ResetColor();

    if (instrucciones != "")
    {
        Console.WriteLine(instrucciones + "\n");
    }
}

void PausarYContinuar()
{
    Console.WriteLine("\nPresiona Enter para continuar...");
    Console.ReadLine();
    Console.Clear();
}

string ObtenerEntrada(string prompt)
{
    try
    {
        while (true)
        {
            Console.Write(prompt);
            string entrada = Console.ReadLine() ?? "";

            if (entrada != "")
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
            MostrarEncabezado("BIENVENIDO A PETFIND", "");
            Console.WriteLine("1. Iniciar sesión");
            Console.WriteLine("2. Registrarse");
            Console.WriteLine("3. Salir del programa");
            Console.Write("\nSeleccione una opción (1-3): ");

            string opcion = Console.ReadLine() ?? "";

            switch (opcion)
            {
                case "1":
                    IniciarSesion();
                    Console.Clear();
                    break;
                case "2":
                    Registrarse();
                    Console.Clear();
                    break;
                case "3":
                    Console.WriteLine("Apagando el sistema PetFind...");
                    Environment.Exit(0);
                    break;
                default:
                    MostrarError("Opción no válida. Por favor, ingrese 1, 2 o 3.");
                    MostrarCarga(2);
                    break;
            }
        }

        MostrarEncabezado("SISTEMA PRINCIPAL", "");
        Console.WriteLine($"¡Has entrado exitosamente, {usuarioActivo}!");
        MostrarCarga(4);
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
            Console.WriteLine(" --  Menu Principal  -- ");
            Console.WriteLine("1. Registrar mascota");
            Console.WriteLine("2. Historial Médico y Citas Veterinarias");
            Console.WriteLine("3. Reportar mascota desaparecida / encontrada");
            Console.WriteLine("4. Reportes de desaparecidos (Público)");
            Console.WriteLine("5. Cartera de PetPoints");
            Console.WriteLine("6. Exportar Base de Datos a CSV");
            Console.WriteLine("7. Cerrar Sesión");
            Console.Write("\nIngrese la opcion a realizar: ");

            string entrada = Console.ReadLine() ?? "";

            if (int.TryParse(entrada, out menu))
            {
                // Opción válida
            }
            else
            {
                MostrarError("Ha ingresado una opcion invalida. Ingrese un numero del 1 al 7");
                MostrarCarga(4);
                Console.Clear();
                continue;
            }

            switch (menu)
            {
                case 1:
                    registroMascota();
                    break;
                case 2:
                    historialMedico();
                    break;
                case 3:
                    reportarMascotaDesaparecida();
                    break;
                case 4:
                    mascotasDesaparecidas();
                    break;
                case 5:
                    billeteraPetPoints();
                    break;
                case 6:
                    exportarDatosCSV();
                    break;
                case 7:
                    salirPrograma();
                    break;
                default:
                    Console.Clear();
                    MostrarError("Ha ingresado una opcion invalida. Por favor, ingrese un numero del 1 al 7.");
                    MostrarCarga(4);
                    Console.Clear();
                    break;
            }

        } while (menu != 7);
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
        MostrarEncabezado("INICIAR SESIÓN", "Instrucciones: Escribe '<' para retroceder un campo, o '/' para salir al inicio.");

        string usuario = "", clave = "";
        int paso = 1;

        while (paso <= 2)
        {
            if (paso == 1)
            {
                usuario = ObtenerEntrada("Usuario: ");
                if (usuario == "/") return;
                if (usuario == "<") { MostrarAdvertencia("Estás en el primer campo, no puedes retroceder."); continue; }
                paso = 2;
            }
            else if (paso == 2)
            {
                clave = ObtenerEntrada("Clave: ");
                if (clave == "/") return;
                if (clave == "<") { paso = 1; continue; }
                paso = 3;
            }
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
                MostrarCarga(4);
                break;
            }
        }

        if (usuarioExiste == false)
        {
            MostrarError("Acceso denegado: El usuario ingresado no está registrado en el sistema.");
            MostrarCarga(4);
        }
    }
    catch (Exception ex)
    {
        MostrarError($"Error al iniciar sesión: {ex.Message}");
        MostrarCarga(4);
    }
}

void Registrarse()
{
    try
    {
        MostrarEncabezado("REGISTRO DE CUENTA NUEVA", "Instrucciones: Escribe '<' para retroceder un campo, o '/' para salir al inicio.");

        string nombre = "", usuario = "", telefono = "", clave = "";
        int paso = 1;

        while (paso <= 4)
        {
            if (paso == 1)
            {
                nombre = ObtenerEntrada("Nombre completo: ");
                if (nombre == "/") return;
                if (nombre == "<") { MostrarAdvertencia("Estás en el primer campo."); continue; }
                paso = 2;
            }
            else if (paso == 2)
            {
                usuario = ObtenerEntrada("Nombre de usuario: ");
                if (usuario == "/") return;
                if (usuario == "<") { paso = 1; continue; }

                bool usuarioDuplicado = false;
                for (int i = 0; i < totalUsuarios; i++)
                {
                    if (usuarios[i].usuario == usuario)
                    {
                        usuarioDuplicado = true;
                        break;
                    }
                }

                if (usuarioDuplicado == true)
                {
                    MostrarError("Ese nombre de usuario ya está en uso. Por favor, elige otro.");
                    MostrarCarga(4);
                    continue;
                }

                paso = 3;
            }
            else if (paso == 3)
            {
                telefono = ObtenerEntrada("Teléfono: ");
                if (telefono == "/") return;
                if (telefono == "<") { paso = 2; continue; }
                paso = 4;
            }
            else if (paso == 4)
            {
                clave = ObtenerEntrada("Clave: ");
                if (clave == "/") return;
                if (clave == "<") { paso = 3; continue; }
                paso = 5;
            }
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
            MostrarCarga(4);
        }
        else
        {
            MostrarAdvertencia("No hay espacio para más usuarios.");
            MostrarCarga(4);
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
            MostrarEncabezado("REGISTRAREMOS SU MASCOTA", "Instrucciones: Escribe '<' para retroceder un campo, o '/' para cancelar y volver al menú.");

            string nombre = "", especie = "", raza = "", color = "", sangre = "", vacunas = "", alergias = "", condicion = "", rasgoCaracteristico = "";
            int paso = 1;

            while (paso <= 9)
            {
                if (paso == 1)
                {
                    nombre = ObtenerEntrada("Nombre de su mascota: ");
                    if (nombre == "/") return;
                    if (nombre == "<") { MostrarAdvertencia("Estás en el primer campo."); continue; }
                    paso = 2;
                }
                else if (paso == 2)
                {
                    especie = ObtenerEntrada("Especie: ");
                    if (especie == "/") return;
                    if (especie == "<") { paso = 1; continue; }
                    paso = 3;
                }
                else if (paso == 3)
                {
                    raza = ObtenerEntrada("Raza: ");
                    if (raza == "/") return;
                    if (raza == "<") { paso = 2; continue; }
                    paso = 4;
                }
                else if (paso == 4)
                {
                    color = ObtenerEntrada("Color de pelaje: ");
                    if (color == "/") return;
                    if (color == "<") { paso = 3; continue; }
                    paso = 5;
                }
                else if (paso == 5)
                {
                    Console.WriteLine("\n - Información médica inicial - ");
                    sangre = ObtenerEntrada("Tipo de sangre: ");
                    if (sangre == "/") return;
                    if (sangre == "<") { paso = 4; continue; }
                    paso = 6;
                }
                else if (paso == 6)
                {
                    vacunas = ObtenerEntrada("Vacunas colocadas: ");
                    if (vacunas == "/") return;
                    if (vacunas == "<") { paso = 5; continue; }
                    paso = 7;
                }
                else if (paso == 7)
                {
                    alergias = ObtenerEntrada("Alergias: ");
                    if (alergias == "/") return;
                    if (alergias == "<") { paso = 6; continue; }
                    paso = 8;
                }
                else if (paso == 8)
                {
                    condicion = ObtenerEntrada("Condición especial: ");
                    if (condicion == "/") return;
                    if (condicion == "<") { paso = 7; continue; }
                    paso = 9;
                }
                else if (paso == 9)
                {
                    rasgoCaracteristico = ObtenerEntrada("Algún rasgo físico característico: ");
                    if (rasgoCaracteristico == "/") return;
                    if (rasgoCaracteristico == "<") { paso = 8; continue; }
                    paso = 10;
                }
            }

            MostrarAdvertencia("\nRegistrando su mascota...");

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
                citasMedicas = "Sin citas registradas aún.",
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

            MostrarCarga(4);
            Console.Clear();
            MostrarExito("Mascota registrada satisfactoriamente.");
            MostrarCarga(2);
            Console.Clear();

            bool mascotaAdicional = false;
            string registrarMascotaAdicional = "";

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
                    MostrarCarga(4);
                    Console.Clear();
                }

            } while (mascotaAdicional != true);

            if (registrarMascotaAdicional == "si")
            {
                otraMascota = true;
            }
            else
            {
                MostrarAdvertencia("Volviendo al menu principal");
                MostrarCarga(4);
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

void historialMedico()
{
    try
    {
        MostrarEncabezado("EXPEDIENTE MÉDICO Y CITAS", "Instrucciones: Escribe '/' para regresar al menú principal.");

        bool tienemascotas = false;
        Console.WriteLine("Tus mascotas registradas: ");
        for (int i = 0; i < totalMascotas; i++)
        {
            if (mascotas[i].duenoUsuario == usuarioActivo)
            {
                tienemascotas = true;
                Console.WriteLine($"ID: {mascotas[i].id} | Nombre: {mascotas[i].nombre} | Especie: {mascotas[i].especie}");
            }
        }

        if (tienemascotas == false)
        {
            MostrarAdvertencia("\nNo tienes mascotas registradas para ver su historial.");
            PausarYContinuar();
            return;
        }
        string entrada = ObtenerEntrada("\nIngrese el ID de la mascota que desea consultar, o '/' para volver: ");

        if (entrada == "/")
        {
            Console.Clear();
            return;
        }

        Console.Clear();
        if (int.TryParse(entrada, out int idMascota))
        {
            bool mascotaEncontrada = false;

            for (int i = 0; i < totalMascotas; i++)
            {
                if (mascotas[i].id == idMascota && mascotas[i].duenoUsuario == usuarioActivo)
                {
                    mascotaEncontrada = true;

                    int opcionActualizar = 0;
                    while (opcionActualizar != 5)
                    {
                        MostrarEncabezado($"HISTORIAL DE {mascotas[i].nombre.ToUpper()}", "");

                        Console.WriteLine($"Tipo de Sangre: {mascotas[i].sangre}");
                        Console.WriteLine($"Vacunas: {mascotas[i].vacunas}");
                        Console.WriteLine($"Alergias: {mascotas[i].alergias}");
                        Console.WriteLine($"Condiciones Especiales: {mascotas[i].condicion}");

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\n--- REGISTRO DE CITAS VETERINARIAS ---");
                        Console.ResetColor();
                        Console.WriteLine(mascotas[i].citasMedicas);
                        Console.WriteLine("--------------------------------------------------");

                        Console.WriteLine("\n¿Qué dato médico desea agregar o actualizar?");
                        Console.WriteLine("1. Agregar nueva vacuna");
                        Console.WriteLine("2. Agregar nueva alergia");
                        Console.WriteLine("3. Agregar nueva condición médica");
                        Console.WriteLine("4. Agregar CITA VETERINARIA");
                        Console.WriteLine("5. Volver al menú principal");
                        Console.Write("Seleccione una opción (1-5): ");

                        string entradaSub = Console.ReadLine() ?? "";
                        if (int.TryParse(entradaSub, out opcionActualizar))
                        {
                            if (opcionActualizar == 1)
                            {
                                string nuevaVacuna = ObtenerEntrada("Ingrese el nombre de la nueva vacuna: ");
                                if (nuevaVacuna != "/" && nuevaVacuna != "<")
                                {
                                    mascotas[i].vacunas += " | " + nuevaVacuna;
                                    MostrarExito("Historial de vacunas actualizado.");
                                    MostrarCarga(3);
                                }
                            }
                            else if (opcionActualizar == 2)
                            {
                                string nuevaAlergia = ObtenerEntrada("Ingrese la nueva alergia detectada: ");
                                if (nuevaAlergia != "/" && nuevaAlergia != "<")
                                {
                                    mascotas[i].alergias += " | " + nuevaAlergia;
                                    MostrarExito("Historial de alergias actualizado.");
                                    MostrarCarga(3);
                                }
                            }
                            else if (opcionActualizar == 3)
                            {
                                string nuevaCondicion = ObtenerEntrada("Ingrese la nueva condición médica: ");
                                if (nuevaCondicion != "/" && nuevaCondicion != "<")
                                {
                                    mascotas[i].condicion += " | " + nuevaCondicion;
                                    MostrarExito("Historial de condiciones actualizado.");
                                    MostrarCarga(3);
                                }
                            }
                            else if (opcionActualizar == 4)
                            {
                                Console.WriteLine("\n-- Nueva Cita Veterinaria --");
                                string fecha = ObtenerEntrada("Fecha de la cita (ej. 25/10/2026): ");
                                if (fecha != "/" && fecha != "<")
                                {
                                    string observacion = ObtenerEntrada("Observaciones del veterinario: ");
                                    if (observacion != "/" && observacion != "<")
                                    {
                                        if (mascotas[i].citasMedicas == "Sin citas registradas aún.")
                                        {
                                            mascotas[i].citasMedicas = "";
                                        }

                                        mascotas[i].citasMedicas += $"\n> [{fecha}] Observaciones: {observacion}";
                                        MostrarExito("Cita veterinaria agregada al expediente exitosamente.");
                                        MostrarCarga(3);
                                    }
                                }
                            }
                            else if (opcionActualizar != 5)
                            {
                                MostrarError("Opción no válida.");
                                MostrarCarga(3);
                            }
                        }
                    }
                    break;
                }
            }

            if (mascotaEncontrada == false)
            {
                MostrarError("\nID de mascota no encontrado o no te pertenece. Intenta de nuevo.");
                PausarYContinuar();
            }
        }
    }
    catch (Exception ex)
    {
        MostrarError($"Error en el historial médico: {ex.Message}");
    }
}

void reportarMascotaDesaparecida()
{
    try
    {
        MostrarEncabezado("CAMBIAR ESTADO DE MASCOTA", "Instrucciones: Escribe '/' para regresar al menú principal.");

        bool tienemascotas = false;
        Console.WriteLine("Tus mascotas registradas: ");
        for (int i = 0; i < totalMascotas; i++)
        {
            if (mascotas[i].duenoUsuario == usuarioActivo)
            {
                tienemascotas = true;

                string estado = "En casa";
                if (mascotas[i].extraviada == true)
                {
                    estado = "Desaparecida";
                }

                Console.WriteLine($"ID: {mascotas[i].id}");
                Console.WriteLine($"Nombre: {mascotas[i].nombre}");
                Console.WriteLine($"Especie: {mascotas[i].especie}");
                Console.WriteLine($"--> Estado actual: {estado} <--");
                Console.WriteLine("---------------------------------");
            }
        }
        if (tienemascotas == false)
        {
            MostrarAdvertencia("\nNo tienes mascotas registradas.");
            PausarYContinuar();
            return;
        }

        Console.WriteLine();
        string entrada = ObtenerEntrada("Ingrese el ID de la mascota para cambiar su estado o '/' para volver: ");

        if (entrada == "/")
        {
            Console.Clear();
            Console.WriteLine("\nRegresando al menú principal...");
            MostrarCarga(3);
            Console.Clear();
            return;
        }

        if (int.TryParse(entrada, out int idMascota))
        {
            bool mascotasEncontrada = false;

            for (int i = 0; i < totalMascotas; i++)
            {
                if (mascotas[i].id == idMascota && mascotas[i].duenoUsuario == usuarioActivo)
                {
                    mascotasEncontrada = true;

                    if (mascotas[i].extraviada == false)
                    {
                        mascotas[i].extraviada = true;
                        mascotasExtraviadas++;
                        MostrarExito($"\n¡Mascota {mascotas[i].nombre} reportada como DESAPARECIDA exitosamente!");
                    }
                    else
                    {
                        mascotas[i].extraviada = false;
                        mascotasExtraviadas--;
                        MostrarExito($"\n¡Qué alegría! Mascota {mascotas[i].nombre} reportada como EN CASA exitosamente!");
                    }
                    break;
                }
            }

            if (mascotasEncontrada == false)
            {
                MostrarError("\nID de mascota no encontrado o no te pertenece. Intenta de nuevo.");
            }

            PausarYContinuar();
        }
    }
    catch (Exception ex)
    {
        MostrarError($"Error al actualizar el estado de la mascota: {ex.Message}");
    }
}

void mascotasDesaparecidas()
{
    try
    {
        MostrarEncabezado("REPORTE PÚBLICO DE MASCOTAS", "Cargando mascotas desaparecidas...");
        MostrarCarga(4);
        Console.Clear();

        if (mascotasExtraviadas == 0)
        {
            MostrarExito("\nNo hay mascotas desaparecidas reportadas. ¡Todos están en casa!");
        }
        else
        {
            MostrarEncabezado("REPORTE PÚBLICO DE MASCOTAS", "");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Hay {mascotasExtraviadas} mascotas extraviadas: \n");
            Console.ResetColor();

            for (int i = 0; i < totalMascotas; i++)
            {
                if (mascotas[i].extraviada == true)
                {
                    MostrarAdvertencia($"#{i + 1}. ID: {mascotas[i].id} - Nombre: {mascotas[i].nombre} - Especie: {mascotas[i].especie} - Raza: {mascotas[i].raza}");
                    Console.WriteLine($" Rasgo característico: {mascotas[i].rasgoCaracteristico} - Dueño de mascota: {mascotas[i].duenoUsuario}\n");
                }
            }
        }
        PausarYContinuar();
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
        int indiceUsuario = 0;
        for (int i = 0; i < totalUsuarios; i++)
        {
            if (usuarios[i].usuario == usuarioActivo)
            {
                indiceUsuario = i;
                break;
            }
        }

        int opcion = 0;

        while (opcion != 4)
        {
            MostrarEncabezado("BILLETERA PETPOINTS", "Instrucciones: Escribe '/' para regresar al menu principal");
            Console.WriteLine("1. Registrar (Ganar) puntos");
            Console.WriteLine("2. Canjear puntos PetFind");
            Console.WriteLine("3. Ver Puntos Actuales");
            Console.WriteLine("4. Salir");
            Console.Write("\nSeleccione una opción (1-4): ");

            string entrada = Console.ReadLine() ?? "";

            if (entrada == "/") return;

            if (int.TryParse(entrada, out opcion))
            {
                Console.WriteLine();

                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("--- OPCIONES DE REGISTRO ---");
                        Console.WriteLine("\n1. Registrar avistamiento de una mascota perdida (150 puntos). \n2. Registrar una mascota encontrada e interceptada (300 puntos). \n3. Volver al menú de billetera.");
                        Console.Write("Seleccione una opción (1/2): ");

                        if (int.TryParse(Console.ReadLine(), out int tipoRegistro))
                        {
                            Console.WriteLine();
                            switch (tipoRegistro)
                            {
                                case 1:
                                    usuarios[indiceUsuario].petPoints += 150;
                                    MostrarExito("¡Gracias por tu reporte de avistamiento! Reporte procesado correctamente.");
                                    Console.WriteLine($"Se ha sumado tu recompensa de 150 PetPoints.");
                                    break;
                                case 2:
                                    usuarios[indiceUsuario].petPoints += 300;
                                    MostrarExito("¡Gracias por ayudar a la comunidad! Reporte procesado correctamente.");
                                    Console.WriteLine($"Se ha sumado tu recompensa de 300 PetPoints.");
                                    break;
                                default:
                                    MostrarAdvertencia("Opción de registro no válida. Regresando al menú de billetera.");
                                    break;
                            }

                            if (tipoRegistro == 1 || tipoRegistro == 2)
                            {
                                Console.WriteLine($"Tu nuevo saldo es de: {usuarios[indiceUsuario].petPoints} puntos.");
                            }
                            MostrarCarga(4);
                        }
                        else
                        {
                            MostrarError("\nError: Debe introducir un número entero (1 o 2) en el submenú.");
                            MostrarCarga(4);
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
                                    if (usuarios[indiceUsuario].petPoints >= 300)
                                    {
                                        usuarios[indiceUsuario].petPoints -= 300;
                                        MostrarExito("¡Solicitud procesada correctamente! Código de cupón generado.");
                                        Console.WriteLine($"Saldo restante: {usuarios[indiceUsuario].petPoints} puntos.");
                                    }
                                    else
                                    {
                                        MostrarError($"Error: Saldo insuficiente en tu billetera PetPoints. Requieres 300 puntos y tienes {usuarios[indiceUsuario].petPoints}.");
                                    }
                                    break;

                                case 2:
                                    MostrarAdvertencia("Operación cancelada por el usuario.");
                                    break;

                                default:
                                    MostrarAdvertencia("Opcion no valida. Regresando al menu de billetera");
                                    break;
                            }
                            MostrarCarga(4);
                        }
                        else
                        {
                            MostrarError("\nError: Debe introducir un número entero válido (1 o 2).");
                            MostrarCarga(4);
                        }
                        break;

                    case 3:
                        Console.WriteLine($"Tu saldo disponible es: {usuarios[indiceUsuario].petPoints} PetPoints.");
                        PausarYContinuar();
                        break;

                    case 4:
                        Console.Clear();
                        MostrarExito("Gracias por usar billetera PetFind. ¡Regresando al menú principal!");
                        MostrarCarga(3);
                        Console.Clear();
                        break;
                    default:
                        MostrarError("Opción no válida. Por favor, seleccione un número del 1 al 4.");
                        MostrarCarga(3);
                        break;
                }
            }
            else
            {
                MostrarError("\nError: Entrada inválida. Por favor, digite un número del 1 al 4.");
                MostrarCarga(3);
            }
        }
    }
    catch (Exception ex)
    {
        MostrarError($"Error en la billetera de PetPoints: {ex.Message}");
    }
}

void exportarDatosCSV()
{
    try
    {
        MostrarEncabezado("EXPORTACIÓN DE DATOS", "Preparando la base de datos de mascotas para exportación...");
        MostrarCarga(4);

        StreamWriter archivoCSV = new StreamWriter("BaseDeDatos_Mascotas.csv");

        archivoCSV.WriteLine("ID,Dueño,Nombre,Especie,Raza,Color,Sangre,Vacunas,Alergias,Condicion,Citas_Medicas,Estado");

        for (int i = 0; i < totalMascotas; i++)
        {
            string estado = "En Casa";
            if (mascotas[i].extraviada == true)
            {
                estado = "Desaparecida";
            }

            string citasLimpias = mascotas[i].citasMedicas.Replace("\n", " ");

            archivoCSV.WriteLine($"{mascotas[i].id},{mascotas[i].duenoUsuario},{mascotas[i].nombre},{mascotas[i].especie},{mascotas[i].raza},{mascotas[i].color},{mascotas[i].sangre},{mascotas[i].vacunas},{mascotas[i].alergias},{mascotas[i].condicion},{citasLimpias},{estado}");
        }

        archivoCSV.Close();

        MostrarEncabezado("EXPORTACIÓN DE DATOS", "");
        MostrarExito("¡Datos guardados exitosamente!\n");
        Console.WriteLine("Se ha creado el archivo 'BaseDeDatos_Mascotas.csv' en la carpeta de tu proyecto.");
        Console.WriteLine("Puedes abrirlo directamente con Excel.");

        PausarYContinuar();
    }
    catch (Exception ex)
    {
        MostrarError($"Error al exportar los datos: {ex.Message}");
        PausarYContinuar();
    }
}

void salirPrograma()
{
    try
    {
        MostrarEncabezado("CERRANDO SESIÓN", "");
        Console.WriteLine("Cerrando sesión actual en Petfind.");
        Console.WriteLine("¡Vuelve pronto!");

        MostrarCarga(3);
        Console.WriteLine();
        sesionIniciada = false;
        usuarioActivo = "";
        menu = 7;
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
        while (true)
        {
            inicio();
            if (sesionIniciada == true)
            {
                menuPrincipal();
            }
        }
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
    public string citasMedicas;
    public bool extraviada;
}