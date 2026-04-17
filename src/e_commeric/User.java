package e_commeric;

import java.sql.*;

public class User extends DatabaseManager{

    private int id;
    private String name;
    private String email;
    private String password;
    private String address;
    private String role;

    public User() {
    }

    public User(int id, String name, String email, String password, String address, String role) {
        this.id = id;
        this.name = name;
        this.password = password;
        this.role = role;
        this.email = email;
        this.address = address;
    }

    public int getId() {
        return id;
    }

    public String getName() {
        return name;
    }

    public String getEmail() {
        return email;
    }

    public String getPassword() {
        return password;
    }

    public String getAddress() {
        return address;
    }

    public String getRole() {
        return role;
    }

    public void setId(int id) {
        this.id = id;
    }

    public void setName(String name) {
        this.name = name;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    public void setAddress(String address) {
        this.address = address;
    }

    public void setRole(String role) {
        this.role = role;
    }

    public static void login(String em, String pass) throws SQLException {
        query = "select count(*) from user where email='" + em + "' and password='" + pass + "'";        r = s.executeQuery(query);
        if (r.next()) {
            System.out.println("Welcome back!");
        } else {
            System.out.println("Invalid email or password. Please try again.");
        }
    }

    public static void register(User u) throws SQLException {
        query = "Insert into User"
                + " values(u.getId(),u.getName(),u.getEmail(),u.getPassword(),u. getAddress(),u.Role())";
        s.execute(query);
        System.out.println("Welcome to in E-Quest");
    }

}
