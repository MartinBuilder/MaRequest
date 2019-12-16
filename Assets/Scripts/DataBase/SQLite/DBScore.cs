using System;
using UnityEngine;
using UnityEngine.UI;
using Mono.Data.Sqlite;
using System.Data;

public class DBScore : MonoBehaviour {

    private float Score;
    private string Name;
    [SerializeField] private InputField ScoreIn;
    [SerializeField] private InputField NameIn;
    IDbConnection dbconn;
    IDbCommand dbcmd;
    IDataReader reader;

    void Start()
    {
        EditDB(WriteDB);
    }

    private void WriteDB()
    {
        string sqlQuery = "SELECT Score,Name " + "FROM Score";
        dbcmd.CommandText = sqlQuery;
        reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            float Score = reader.GetFloat(0);
            string Name = reader.GetString(1);

            Debug.Log("Naam= " + Name + "  Score = " + Score);
        }

    }
      
    public void Button()
    {
        if (NameIn.text != "" && ScoreIn.text != "")
        {
            Name = NameIn.text;
            Score = Single.Parse(ScoreIn.text);

            Debug.Log("Score: " + Score + "Naam:" + Name);
            EditDB(Add);
        }
    }

    private void Add()
    {
        dbcmd.CommandText = "INSERT INTO Score (Score,Name) VALUES('" + Score + "','" + Name + "')";
        dbcmd.ExecuteNonQuery();
    }

    private void OpenDB()
    {
        string conn = "URI=file:" + Application.dataPath + "/ScoreDataBase.s3db"; //Path to database.
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        dbcmd = dbconn.CreateCommand();
    }

    private void CloseDB()
    {
        reader?.Close();
        reader = null;
        dbcmd?.Dispose();
        dbcmd = null;
        dbconn?.Close();
        dbconn = null;
    }

    private delegate void dbFunction();

    private void EditDB(dbFunction dbFunction)
    {
        OpenDB();
        dbFunction?.Invoke();
        CloseDB();
    }
}
