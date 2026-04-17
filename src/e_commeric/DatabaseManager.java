/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package e_commeric;

import java.sql.*;

public class DatabaseManager {
    protected static Connection c;
    protected static Statement s;
    protected static ResultSet r;
    protected static String query = "";

    static {
        try {
            Sec database = new Sec();
            c = database.connect();
            s = c.createStatement();
        } 
        catch (SQLException e) {
            System.out.println("Connection Error: " + e.getMessage());
        }
    }
}
