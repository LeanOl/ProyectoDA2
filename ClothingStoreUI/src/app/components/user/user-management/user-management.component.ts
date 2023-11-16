import { Component } from '@angular/core';
import { UserRequest } from 'src/app/models/user-req.model';
import { User } from 'src/app/models/user.model';
import { SessionService } from 'src/app/services/session.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-user-management',
  templateUrl: './user-management.component.html',
  styleUrls: ['./user-management.component.css'],
})
export class UserManagementComponent {
  user: UserRequest;
  message?: string;
  messageType?: string;
  editingEmail: boolean = false;
  editingDeliveryAddress: boolean = false;
  editingRole: boolean = false;
  editingPassword: boolean = false;
  showUser: boolean = true;
  newEmail: string = '';
  newDeliveryAddress: string = '';
  newRole: string = '';
  newPassword: string = '';
  constructor(private userService: UserService,private sessionService:SessionService) {
    this.user = {
      id: 'Default',
      email: 'Default',
      role: 'Default',
      deliveryAddress: 'Default',
    };
  }

  ngOnInit(): void {
    this.user = this.userService.getUserToManage();
  }

  updateUser(): void {
    let userToUpdate: UserRequest = {
      id: this.user.id,
      email: this.editingEmail ? this.newEmail : this.user.email,
      role: this.editingRole ? this.newRole : this.user.role,
      deliveryAddress: this.editingDeliveryAddress
        ? this.newDeliveryAddress
        : this.user.deliveryAddress,
      password: this.editingPassword ? this.newPassword : undefined,
    };

    this.userService.updateUser(userToUpdate).subscribe({
      next: (user) => {
        this.user = user;
        this.showMessage('User updated successfully', 'success');
      },
      error: (error) => {
        console.error(error);
        this.showMessage('Error updating user', 'error');
      },
    });
  }
  deleteUser(): void {
    if (confirm('Are you sure you want to delete this user?')) {
      this.userService.deleteUser(this.user.id).subscribe({
        next: () => {
          this.showMessage('User deleted successfully', 'success');
          this.showUser = false;
        },
        error: (error) => {
          console.error(error);
          this.showMessage('Error deleting user', 'error');
        },
      });
    }
  }

  showMessage(message: string, type: string): void {
    this.message = message;
    this.messageType = type;
    setTimeout(() => {
      this.message = undefined;
      this.messageType = undefined;
    }, 3000);
  }

  startEdit(field: string) {
    switch (field) {
      case 'email':
        this.editingEmail = true;
        break;
      case 'deliveryAddress':
        this.editingDeliveryAddress = true;
        break;
      case 'role':
        this.editingRole = true;
        break;
      case 'password':
        this.editingPassword = true;
        break;
      default:
        break;
    }
  }

  cancelEdit(field: string) {
    switch (field) {
      case 'email':
        this.editingEmail = false;
        this.newEmail = '';
        break;
      case 'deliveryAddress':
        this.editingDeliveryAddress = false;
        this.newDeliveryAddress = '';
        break;
      case 'role':
        this.editingRole = false;
        this.newRole = '';
        break;
      case 'password':
        this.editingPassword = false;
        this.newPassword = '';
        break;
      default:
        break;
    }
  }

  isAdmin(): boolean {
    return this.sessionService.getRole() === 'admin';
  }
}
