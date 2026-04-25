package repository;

import java.sql.*;
import java.util.*;
import model.USER;

public class UserRepository extends database.DatabaseManager {

    public void addUser(USER u) {
        try {
            query = "INSERT INTO users (id, name, email,password, role) VALUES (?, ?, ?, ? ,?)";
            s.setInt(1, u.getId());
            s.setString(2, u.getName());
            s.setString(3, u.getEmail());
            s.setString(4, u.getPassword());
            s.setString(5, u.getRole().name());
            s.execute(query);

        } catch (SQLException e) {
            System.out.println(e.getMessage());
        }
    }

    public void removeUser(USER u) {
        try {
            query = "delete from users where id=?";
            s.setInt(1, u.getId());
            s.execute(query);

        } catch (SQLException e) {
            System.out.println(e.getMessage());
        }
    }

    public USER find(String email) {
        USER o;
        try {
            query = "  select *from users where email=? ";
            s.setString(1, email);
            r = s.executeQuery();
            if (r.next()) {  
               o=new USER(r.getInt("id"),r.getString("name"), r.getString("email"), r.getString("password"), USER.Role.valueOf(r.getString("role")));     
               return o;
            }           
        } 
        catch (SQLException e) {
            System.out.println(e.getMessage());   
        }
          return null;
    }
    public List<USER> findall() {
        List<USER> d = new ArrayList<>();

        try {
            query = "SELECT * FROM users";
            r = s.executeQuery();
            while (r.next()) {
                d.add(new USER(r.getInt("id"),r.getString("name"), r.getString("email"), r.getString("password"), USER.Role.valueOf(r.getString("role"))));
            }
            return d;
        } catch (SQLException e) {
            System.out.println(e.getMessage());

        }
        return d;
    }

    
}
