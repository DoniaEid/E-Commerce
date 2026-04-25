package Services;

import model.USER;
import repository.UserRepository;

public class UserService {
    private UserRepository u = new UserRepository();

    public USER login(String email, String password) {
        USER r = u.find(email); 
        if (r != null) {
            System.out.println("Welcome to my E-Commerce Store, " + r.getName());
            return r;
        } else {
            System.out.println("Error: Invalid email or password.");
            return null;
        }
    }

    public void register(USER us) {
        u.addUser(us);
        System.out.println("Registration successful! Welcome, " + us.getName());
    }
}