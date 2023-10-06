//04/10
//Clase que utiliza la conexión a una base de datos
//con el patrón Singleton
//xomalli@gmail.com
using System;
using System.Data;
using System.Data.SqlClient;

namespace PostSingleton
{
public class DataBase2
{
static DataBase2 Instance = null;
static SqlConnection _conn = null;
private DataBase2(){  }
private static void CreateInstance(){
    if(Instance == null)
    { Instance = new DataBase2();}
    }
    public static DataBase2 GetInstance(string conStr){
    if(Instance == null){
    CreateInstance();
    Instance.ConnectionString = conStr;
    Instance.GetConnection();}
    return Instance;
    }
    void GetConnection(){
    try{
    _conn = new SqlConnection();
     _conn.StateChange += delegate(object o,StateChangeEventArgs args){
    Info = String.Format(" {1}| {2}| {3}|",args.CurrentState.ToString(),
    System.DateTime.Now.ToLocalTime(),_conn.DataSource,_conn.Database);
    };
    _conn.ConnectionString = ConnectionString;
    _conn.Open();
    IsOpen = true;
    }
    catch(SqlException x){
        if (_conn.State == System.Data.ConnectionState.Open)
              _conn.Close();
    throw x;
    }
    }
    public void Close(){
		if (_conn.State == System.Data.ConnectionState.Open){
              _conn.Close();
              IsOpen = false;
		}
	}
	string ConnectionString {set;get;}
	public bool IsOpen {set;get;}
	public string Info {set;get;}	
}}
