
package model;

import java.util.Date;
enum status{pending,shipped,delivered,cancelled};
public class orders {
    private Date created_At;
    private int id ;
    private String shipping_address;
    private status Status;
    private double total_amount;
    private int user_id;

    public orders() {
    }

    public orders(Date created_At, int id, String shipping_address, status Status, double total_amount, int user_id) {
        this.created_At = created_At;
        this.id = id;
        this.shipping_address = shipping_address;
        this.Status = Status;
        this.total_amount = total_amount;
        this.user_id = user_id;
    }
    public orders(int id, String shipping_address, status Status, double total_amount, int user_id) {
        this.id = id;
        this.shipping_address = shipping_address;
        this.Status = Status;
        this.total_amount = total_amount;
        this.user_id = user_id;
    }

    public Date getCreated_At() {
        return created_At;
    }

    public int getId() {
        return id;
    }

    public String getShipping_address() {
        return shipping_address;
    }

    public status getStatus() {
        return Status;
    }

    public double getTotal_amount() {
        return total_amount;
    }

    public int getUser_id() {
        return user_id;
    }

    public void setCreated_At(Date created_At) {
        this.created_At = created_At;
    }

    public void setId(int id) {
        this.id = id;
    }

    public void setShipping_address(String shipping_address) {
        this.shipping_address = shipping_address;
    }

    public void setStatus(status Status) {
        this.Status = Status;
    }

    public void setTotal_amount(double total_amount) {
        this.total_amount = total_amount;
    }

    public void setUser_id(int user_id) {
        this.user_id = user_id;
    }
    
    
    
    
    
    
    
    
}
