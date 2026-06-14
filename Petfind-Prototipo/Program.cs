// Petfind - Prototipo // Inicio de sesion 
// Petfind - Prototipo // Inicio de sesion 
Usuario[] usuarios = new Usuario[100];
int totalUsuarios = 0;
bool sesionIniciada = false;
string usuarioActivo = "";

while (sesionIniciada == false)
{
    Console.WriteLine("\n--- Bienvenido a Petfind ---");
    Console.WriteLine("¿Deseas iniciar sesión o registrarte? (escribe: iniciar o registrar)");
    string opcion = Console.ReadLine();

    if (opcion == "registrar")
    {
        Registrarse();
    }
    else if (opcion == "iniciar")
    {
        IniciarSesion();
    }
    else
    {
        Console.WriteLine("Opción no válida.");
    }
}

// Todo el código del menú principal (registrar mascota, buscar, etc.) va a partir de aquí
Console.WriteLine("\n========================================");
Console.WriteLine($"¡Has entrado al sistema principal, {usuarioActivo}!");
Console.WriteLine("========================================");


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
    string clave = Console.ReadLine();

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
            break;
        }
    }

    if (encontrado == false)
    {
        Console.WriteLine("Usuario o clave incorrectos. Acceso denegado.");
    }
}

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
    public bool extraviada;
}