
package e_commeric;

import java.sql.*;


public class E_commeric extends DatabaseManager {

    public static void main(String[] args) {
        try{
        query = "CREATE TABLE IF NOT EXISTS User (" +
                "Id INT AUTO_INCREMENT, " +
                "Name VARCHAR(100) NOT NULL, " +
                "Email VARCHAR(200) CHECK (Email LIKE '%@gmail.com'), " +
                "Password VARCHAR(100) NOT NULL, " +
                "Address VARCHAR(100), " +
                "Role VARCHAR(100), " +
                "CONSTRAINT pk_user PRIMARY KEY (Id)" +
                ")";
          s.execute(query);
        }
           catch (Exception e) {
            System.out.println("Connection Error: " + e.getMessage());
        }

    }
    
}
