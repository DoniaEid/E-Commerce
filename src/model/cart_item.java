
package model;

import java.util.Date;


public class cart_item {
    private int id;
    private Date added_at;
    private int product_id ;
    private int quantity ;
    private int user_id;

    public cart_item() {
    }

    public cart_item(int id, Date added_at, int product_id, int quantity, int user_id) {
        this.id = id;
        this.added_at = added_at;
        this.product_id = product_id;
        this.quantity = quantity;
        this.user_id = user_id;
    }
        public cart_item(int id, int product_id, int quantity, int user_id) {
        this.id = id;
        this.product_id = product_id;
        this.quantity = quantity;
        this.user_id = user_id;
    }
}
