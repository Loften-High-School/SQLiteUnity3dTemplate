using System.Collections;
using System.Collections.Generic;
//in Extensions download "NuGet Package Manager GUI"
// First open your terminal and make sure you are CD to your directory
// then type in "dotnet add package Microsoft.Data.Sqlite"
//Open terminal from your Applications folder
//  type: "brew install sqlite"
//
using Mono.Data.Sqlite; //calls the library of SQLite nuget package MySql.Data -Version 8.0.32

//https://learn.microsoft.com/en-us/dotnet/standard/data/sqlite/?tabs=net-cli
using UnityEngine;
using System.Data;



public class SimpleDB : MonoBehaviour
{
    private string dbName = "URI = file:Inventory.db";

    // Start is called before the first frame update
    void Start()
    {
      //Calls Method to Create Database
    CreateDB();
    // AddWeapon ();
    Debug.Log ("SQL started Working!");
    }

    // Update is called once per frame
    void Update()
    {
        // Empty update method
    }

    //TODO: CREATE METHOD FOR CreateDB()
  
    private void CreateDB()
    {
        using (var connection = new SqliteConnection (dbName))
        {
            connection.Open ();
            using (var command = connection.CreateCommand ()) 
            {
                command.CommandText = "CREATE TABLE IF NOT EXISTS weapons (name  VARCHAR (20), qte INT)";
                command.ExecuteNonQuery ();
            }
            connection.Close ();
        }
    }
    //TODO: Create Method for adding Weapon into Database
   
}
