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
    //Global Variable Created
    private string dbName = "URI = file:Inventory.db";

    // Start is called before the first frame update
    void Start()
    {
      //Calls Method to Create Database
    CreateDB();
    AddWeapon ("pistol", 25);
    AddWeapon("sword", 6);
    Debug.Log ("SQL started Working!");
    //TODO: call the method and delte Rifle
    }

    // Update is called once per frame
    void Update()
    {
        // Empty update method
    }

    // DONE: TODO: CREATE METHOD FOR CreateDB()
  
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

    public void AddWeapon (string weaponName, int weaponQte)
    {
        using (var connection = new SqliteConnection (dbName))
        {
            connection.Open ();
                using (var command = connection.CreateCommand ()) 
                {
                    //SQL code goes here ... Left Code here
                    command.CommandText = "INSERT INTO weapons (name, qte) VALUES (@name, @qte);";// Adds the SQL code as the argument to add a value of Rifle of 17 as the values
                    //commmand.Parameters allows you to add and Assign the parameter with the value from within Values
                    command.Parameters.AddWithValue ("@name", weaponName);
                    command.Parameters.AddWithValue ("@qte", weaponQte);
                    command.ExecuteNonQuery ();
                }
            connection.Close ();
        }
    }

    public void DeleteWeapon (string weaponName)
    {
      using (var connection = new SqliteConnection (dbName))
        {
            connection.Open ();
                using (var command = connection.CreateCommand ()) 
                {
                    //SQL code goes here ... Left Code here
                    //TODO: DELETE FROM weapons WHERE name = @name
                    command.CommandText = ";"; 
                    command.Parameters.AddWithValue ("@name", weaponName);
                    
                }
            connection.Close( ); 
            }

    }
   
}
