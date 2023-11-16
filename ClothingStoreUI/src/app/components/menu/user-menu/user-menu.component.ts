import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { SessionService } from 'src/app/services/session.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-user-menu',
  templateUrl: './user-menu.component.html',
  styleUrls: ['./user-menu.component.css'],
})
export class UserMenuComponent {
  constructor(
    private sessionService: SessionService,
    private router: Router,
    private userService: UserService
  ) {}

  getEmail(): string {
    return this.sessionService.getEmail();
  }

  viewPurchases(): void {
    this.router.navigate(['/purchases', this.sessionService.getUserId()]);
  }

  editProfile(): void {
    let currentUserId = this.sessionService.getUserId();
    this.userService.getUserById(currentUserId).subscribe({
      next: (user) => {
        this.userService.setUserToManage(user);
        this.router.navigate(['/users/manage']);
      },
    });
  }
}
