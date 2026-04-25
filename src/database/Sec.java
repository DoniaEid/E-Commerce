
package database;

import java.sql.*;
public class Sec {
    private String add="jdbc:mysql://localhost:3306/e_commeric";
    private String user="root";
    private String pass="";

    public String getAdd() {
        return add;
    }

    public String getUser() {
        return user;
    }

    public String getPass() {
        return pass;
    }

    public void setAdd(String add) {
        this.add = add;
    }

    public void setUser(String user) {
        this.user = user;
    }

    public void setPass(String pass) {
        this.pass = pass;
    }
    
    public Connection connect() throws SQLException{
        Connection r=DriverManager.getConnection(add,user,pass);
        return r;
    }
    
    
}
