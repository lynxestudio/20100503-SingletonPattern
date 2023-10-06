//04/10
//Clase que utiliza la conexión a una base de datos sin 
//el patrón Singleton
//xomalli@gmail.com
using System;
using System.Data;
using System.Data.SqlClient;

namespace PostSingleton
{
public class DataBase
{
	SqlConnection _conn = null;
	public DataBase(string conString){
	ConnectionString = conString;
    GetConnection();	
	}
	 public void GetConnection(){
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
	Close();
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
}
}