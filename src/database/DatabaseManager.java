
package database;

import database.Sec;
import java.sql.*;

public class DatabaseManager {
    protected static Connection c;
    protected static PreparedStatement s;
    protected static ResultSet r;
    protected static String query = "";

    static {
        try {
            Sec database = new Sec();
            c = database.connect();
            s = c.prepareStatement(query);
        } 
        catch (SQLException e) {
            System.out.println("Connection Error: " + e.getMessage());
        }
    }
}
