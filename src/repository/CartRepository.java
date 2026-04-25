package repository;

import database.DatabaseManager;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;
import model.*;

public class CartRepository extends DatabaseManager {

    public void addProduct(cart_item c) {
        try {
            query = "INSERT INTO cart_item( id,user_id,  product_id, quantity) VALUES (?, ?, ?, ?)";
            s.setInt(1, c.getId());
            s.setInt(2, c.getUser_id());
            s.setInt(3, c.getProduct_id());
            s.setDouble(4, c.getQuantity());
            s.execute();
        } catch (SQLException e) {
            System.out.println(e.getMessage());
        }
    }

    public void removeitem(int id) {
        try {
            query = "delete from cart_item where id=?";
            s.setInt(1, id);
            s.execute(query);

        } catch (SQLException e) {
            System.out.println(e.getMessage());
        }
    }

    public cart_item find(String name) {
        cart_item c;
        try {
            query = "  select * from cart_item where name=? ";
            s.setString(1, name);
            r = s.executeQuery();
            if (r.next()) {
                c = new cart_item(r.getInt("id"), r.getInt("user_id"), r.getInt("product_id"), r.getInt("quantity"), r.getDate("added_at"));
                return c;
            }
        } catch (SQLException e) {
            System.out.println(e.getMessage());
        }
        return null;
    }

    public List<cart_item> findall() {
        List<cart_item> d = new ArrayList<>();
        try {
            query = "SELECT * FROM cart_item";
            r = s.executeQuery();
            while (r.next()) {
                d.add(new cart_item(r.getInt("id"), r.getInt("user_id"), r.getInt("product_id"), r.getInt("quantity"), r.getDate("added_at")));
            }
            return d;
        } catch (SQLException e) {
            System.out.println(e.getMessage());

        }
        return d;
    }

    public void updateProductPrice(int id, int quantity) {
        query = "UPDATE products SET  quantity = ? WHERE id = ?";
        try {
            s.setInt(1, id);
            s.setInt(2, quantity);
            s.execute();
            System.out.println("quantity updated!");

        } catch (SQLException e) {
            System.out.println(e.getMessage());
        }
    }

    public void removeAll(int cartId) {
        String query = "DELETE FROM cart_item WHERE cart_id = " + cartId;
        try {
            s.execute(query);
            System.out.println("Cart cleared successfully!");
        } catch (SQLException e) {
            System.out.println(e.getMessage());
        }
    }

}
