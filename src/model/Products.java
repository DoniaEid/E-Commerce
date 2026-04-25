
package model;

import java.util.Date;


public class Products {
    private int id;
    private Date created_AT;
    private String name;
    private double price;
    private int stock;
    private String description;
    private int category_id;

    public Products() {
    }

    public Products(int id, int category_id, String name, String description,double price, Date created_at) {
        this.id = id;
        this.name = name;
        this.price = price;
        this.stock = stock;
        this.description = description;
        this.category_id = category_id;
    }
    public Products(int id, int category_id, String name, String description,double price) {

        this.id = id;
        this.created_AT = created_AT;
        this.name = name;
        this.price = price;
        this.stock = stock;
        this.description = description;
        this.category_id = category_id;
    }

    public int getId() {
        return id;
    }

    public Date getCreated_AT() {
        return created_AT;
    }

    public String getName() {
        return name;
    }

    public double getPrice() {
        return price;
    }

    public int getStock() {
        return stock;
    }

    public String getDescription() {
        return description;
    }

    public int getCategory_id() {
        return category_id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public void setCreated_AT(Date created_AT) {
        this.created_AT = created_AT;
    }

    public void setName(String name) {
        this.name = name;
    }

    public void setPrice(double price) {
        this.price = price;
    }

    public void setStock(int stock) {
        this.stock = stock;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public void setCategory_id(int category_id) {
        this.category_id = category_id;
    }
    
    
    
}
