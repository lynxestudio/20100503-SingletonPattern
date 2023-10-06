using System;
using System.Collections.Generic;
using System.Linq;

namespace PostSingleton
{
public class Program
{
static List<DataBase> _conns = null;
public static int Main(string[] args)
{
	 _conns = new List<DataBase>();
	 char o = 'q';
	 Console.ForegroundColor = ConsoleColor.White;
     char[] options = { 'a','b','q'};
     string[] menu = { "Conexión DB","Ver Conexiones","Salir"};
	 do{
         Util.Print("Ejemplo del patron singleton para conexiones".ToUpper());
         Util.DisplayMenu(menu,options);
	     Console.ForegroundColor = ConsoleColor.Yellow;
         o = Util.PromptOption("Elija su opción y pulse <ENTER>: ");
	     Console.ForegroundColor = ConsoleColor.White;
	switch(o){
		case 'a':
			ConectarDB();
			break;
		case 'b':
			VerConexiones();
			break;
        case 'q':
            Exit();
            break;
	}
	 }while(o != 'q');
	 Console.WriteLine("\nHasta luego");
	return 0;
	
}
static void VerConexiones(){
try
{
    Console.Clear();
    Util.Title("LISTADO DE CONEXIONES");
    Util.Print("\n");
    Util.Print("+------------------------------------+");
    Util.Print("| CONEXIONES ACTIVAS                 |");
    Util.Print("+------------------------------------+\n");
if(_conns.Count > 0){
var q = from c in _conns where c.IsOpen == true select c;
foreach(var i in q){
    Console.ForegroundColor = ConsoleColor.Green;
	Util.Print(i.Info);
    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.White;
}}else 
    Util.Title("NO HAY CONEXIONES ACTIVAS");
}catch(Exception x){ 
    Console.WriteLine("Excepcion " + x.Message); }
}		
static void ConectarDB(){
	try{
	Console.Clear();
	Console.WriteLine("Datos de la cadena de conexion ");
    Console.ForegroundColor = ConsoleColor.Yellow;
    string server = Util.Prompt("Servidor y pulse <ENTER> : ");
    string database = Util.Prompt("Base de datos y pulse <ENTER> : ");
    string user = Util.Prompt("Usuario y pulse <ENTER> : ");
    string password = Util.Prompt("Password y pulse <ENTER> : ");
	Console.ForegroundColor = ConsoleColor.White;
	string connStr = String.Format(
    "Data Source={0};Initial Catalog={1};User ID={2};Password={3};",
    server,database,user,password);
    Util.Print("Intentando conexión...");
     //Conexion sin singleton
	DataBase db = new DataBase(connStr);
    _conns.Add(db);
    //Conexion usando singleton 
    //_conns.Add(DataBase2.GetInstance(connStr));		
	VerConexiones();
}catch(Exception x){
	Util.Print("Excepción " + x.Message);
}
}
static void Exit(){
Environment.Exit(0);
}}}