using System.Text.RegularExpressions;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;


namespace Clinica_Frba.AppModel
{
  class ConectorSQL //objeto que hace de interfaz con la base de datos
  {
    /***********************************************************************************
     *                                 Métodos privados                                *
     * *********************************************************************************
     *                                                                                 *
     * Funcionan como primitivas de los métodos publicos, permitiendo distintas firmas *
     *                                                                                 *
     * ********************************************************************************/

    private static void _ejecutarProcedure(string procedure, List<string> args, params object[] values)
    {
      SqlConnection conexion = new SqlConnection();
      SqlCommand comando = new SqlCommand();

      try
      {
        conexionSql(conexion, comando);
        comando.CommandType = CommandType.StoredProcedure;
        comando.CommandText = "CUATRO_QUESOS." + procedure;
        if (_validateArgumentsAndParameters(args, values))
        {
          _loadSqlCommand(args, values, comando);
        }
        comando.ExecuteNonQuery();
      }
      catch (Exception excepcion)
      {
        throw excepcion;
      }

      finally
      {
        if (conexion != null)
        {
          conexion.Close();
        }
      }
    }


    private static bool _checkIfExists(string procedure, List<string> args, params object[] values)
    {
      SqlConnection conexion = new SqlConnection();
      SqlCommand comando = new SqlCommand();
      SqlDataReader dataReader;
      DataTable dataTable = new DataTable();

      try
      {
        conexionSql(conexion, comando);
        comando.CommandType = CommandType.StoredProcedure;
        comando.CommandText = "CUATRO_QUESOS." + procedure;
        if (_validateArgumentsAndParameters(args, values))
        {
          _loadSqlCommand(args, values, comando);
        }
        dataReader = comando.ExecuteReader();
        return dataReader.HasRows;
      }
      catch (Exception excepcion)
      {
        throw excepcion;
      }

      finally
      {
        if (conexion != null)
        {
          conexion.Close();
        }
      }
    }


    private static int _ejecutarProcedureWithReturnValue(string procedure, List<string> args, params object[] values)
    {
      SqlConnection conexion = new SqlConnection();
      SqlCommand comando = new SqlCommand();


      try
      {
        conexionSql(conexion, comando);
        comando.CommandType = CommandType.StoredProcedure;
        comando.CommandText = "CUATRO_QUESOS." + procedure;
        if (_validateArgumentsAndParameters(args, values))
        {
          _loadSqlCommand(args, values, comando);
        }
        comando.Parameters.Add("@RETURN_VALUE", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
        comando.ExecuteNonQuery();
        return (int)comando.Parameters["@RETURN_VALUE"].Value;
      }
      catch (Exception)
      {
        return -1;
      }

      finally
      {
        if (conexion != null)
        {
          conexion.Close();
        }
      }
    }


    private static DataTable _traerDataTable(string procedure, List<string> args, params object[] values)
    {
      SqlConnection conexion = new SqlConnection();
      SqlCommand comando = new SqlCommand();
      SqlDataReader dataReader;
      DataTable dataTable = new DataTable();

      try
      {
        conexionSql(conexion, comando);
        comando.CommandType = CommandType.StoredProcedure;
        comando.CommandText = "CUATRO_QUESOS." + procedure;
        if (_validateArgumentsAndParameters(args, values))
        {
          _loadSqlCommand(args, values, comando);
        }
        dataReader = comando.ExecuteReader();
        dataTable.Load(dataReader);
        return dataTable;
      }
      catch (Exception)
      {
        return null;
      }

      finally
      {
        if (conexion != null)
        {
          conexion.Close();
        }
      }
    }


    private static List<string> _generateArguments(string procedure)
    {
      SqlConnection conexion = new SqlConnection();
      SqlCommand comando = new SqlCommand();
      SqlDataReader dataReader;
      DataTable dataTable = new DataTable();
      List<string> args = new List<string>();
      try
      {
        conexionSql(conexion, comando);
        comando.CommandType = CommandType.Text;
        comando.CommandText = "SELECT PARAMETER_NAME FROM information_schema.parameters WHERE SPECIFIC_SCHEMA='CUATRO_QUESOS' AND SPECIFIC_NAME='" + procedure + "'";
        dataReader = comando.ExecuteReader();
        dataTable.Load(dataReader);
        foreach (DataRow d in dataTable.Rows)
        {
          args.Add(d[0].ToString());
        }
        return args;
      }
      catch (Exception)
      {
        return null;
      }

      finally
      {
        if (conexion != null)
        {
          conexion.Close();
        }
      }
    }


    private static bool _validateArgumentsAndParameters(List<string> args, params object[] values)
    {
      if (args != null && values != null)
      {
        if (args.Count != values.Length)
        {
          throw new ApplicationException();
        }
        return true;
      }
      return false;
    }
    private static void _loadSqlCommand(List<string> args, object[] values, SqlCommand cm)
    {
      for (int i = 0; i < args.Count; i++)
      {
        cm.Parameters.AddWithValue(args[i], values[i]);
      }
    }

    /***********************************************************************************
     *                                 Métodos públicos                                *
     * ********************************************************************************/

    /// <summary>
    /// Ejecuta un stored procedure y devuelve un datatable con el resultado del mismo.
    /// </summary>
    /// <param name="procedure">Nombre del stored procedure almacenado en la BDD sin el nombre del esquema delante.</param>
    /// <param name="values">Argumentos que recibe el stored procedure.</param>
    public static DataTable traerDataTable(string procedure, params object[] values)
    {
      List<string> args = _generateArguments(procedure);
      return _traerDataTable(procedure, args, values);
    }

    /// <summary>
    /// Ejecuta un stored procedure y devuelve un datatable con el resultado del mismo.
    /// </summary>
    /// <param name="procedure">Nombre del stored procedure almacenado en la BDD sin el nombre del esquema delante.</param>
    /// <returns></returns>
    public static DataTable traerDataTable(string procedure)
    {
      return _traerDataTable(procedure, null, null);
    }

    /// <summary>
    /// Ejecuta un stored procedure.
    /// </summary>
    /// <param name="procedure">Nombre del stored procedure almacenado en la BDD sin el nombre del esquema delante.</param>
    /// <param name="values">Argumentos que recibe el stored procedure.</param>
    public static void ejecutarProcedure(string procedure, params object[] values)
    {
      List<string> argumentos = _generateArguments(procedure);
      _ejecutarProcedure(procedure, argumentos, values);
    }

    /// <summary>
    /// Ejecuta un stored procedure.
    /// </summary>
    /// <param name="procedure">Nombre del stored procedure almacenado en la BDD sin el nombre del esquema delante.</param>
    public static void ejecutarProcedure(string procedure)
    {
      _ejecutarProcedure(procedure, null, null);
    }

    /// <summary>
    /// Ejecuta una consulta (a partir de un stored procedure) y devuelve si encontró datos o no.
    /// </summary>
    /// <param name="procedure">Nombre del stored procedure almacenado en la BDD sin el nombre del esquema delante.</param>
    /// <param name="values">Argumentos que recibe el stored procedure.</param>
    /// <returns> True: la consulta devolvió alguna fila. False: no devolvió filas.</returns>
    public static bool checkIfExists(string procedure, params object[] values)
    {
      List<string> argumentos = _generateArguments(procedure);
      return _checkIfExists(procedure, argumentos, values);
    }

    /// <summary>
    /// Ejecuta una consulta (a partir de un stored procedure) y devuelve si encontró datos o no.
    /// </summary>
    /// <param name="procedure">Nombre del stored procedure almacenado en la BDD sin el nombre del esquema delante.</param>
    /// <returns> True: la consulta devolvió alguna fila. False: no devolvió filas.</returns>
    public static bool checkIfExists(string procedure)
    {
      return _checkIfExists(procedure, null, null);
    }

    /// <summary>
    /// Ejecuta un stored procedure que devuelve un valor númerico y retorna dicho valor.
    /// </summary>
    /// <param name="procedure">Nombre del stored procedure almacenado en la BDD sin el nombre del esquema delante.</param>
    /// <param name="values">Argumentos que recibe el stored procedure.</param>
    /// <returns> Valor de retorno del stored procedure.</returns>
    public static int ejecutarProcedureWithReturnValue(string procedure, params object[] values)
    {
      List<string> argumentos = _generateArguments(procedure);
      return _ejecutarProcedureWithReturnValue(procedure, argumentos, values);
    }

    public static void conexionSql(SqlConnection conexion, SqlCommand cm)
    {
      try
      {
        string sconcompleto = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
        conexion.ConnectionString = sconcompleto; 
        cm.Connection = conexion; 
        conexion.Open();  
      }
      catch (Exception excepcion)
      {
        throw excepcion; 
      }
    }

  }
}