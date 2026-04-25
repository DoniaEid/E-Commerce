
package repository;

import java.sql.SQLException;
import model.USER;


public class UserRepository extends database.DatabaseManager {
    
    
    public void addUser(USER u ) throws SQLException{
        try{
             query = "INSERT INTO users (name, email, password, role) VALUES (?, ?, ?, ?)"; 
             s.execute(query); 
        }
        catch(SQLException e){
            System.out.println(e.getMessage());
        }
    }
    
    
}
