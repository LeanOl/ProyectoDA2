import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UserRegister } from 'src/app/models/user-register.model';
import { User } from 'src/app/models/user.model';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-register-form',
  templateUrl: './register-form.component.html',
  styleUrls: ['./register-form.component.css']
})
export class RegisterFormComponent {
  errorMessage: string = '';
  displayError: boolean = false;
  formEmail: string = '';
  formPassword: string = '';
  formConfirmPassword: string = '';
  formDeliveryAddress: string = '';
  constructor(private userService: UserService, private router: Router) { }

  register(): void {

    if (!this.validatePassword()) {
      this.errorMessage = 'Passwords do not match';
      this.displayError = true;
      return;
    }
    const user: UserRegister = {
      email: this.formEmail,
      password: this.formPassword,
      role: 'USER',
      deliveryAddress: this.formDeliveryAddress,
    };
    this.userService.registerUser(user).subscribe(
      {
        next: (user) => {
          this.router.navigate(['/login']);
        },
        error: (error) => {
          this.errorMessage = "Error registering user";
          this.displayError = true;
        },
      }
    );


  }
  validatePassword(): boolean {
    return this.formPassword === this.formConfirmPassword;
  }
}


