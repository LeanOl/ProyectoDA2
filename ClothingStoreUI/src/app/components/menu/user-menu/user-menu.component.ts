import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { SessionService } from 'src/app/services/session.service';

@Component({
  selector: 'app-user-menu',
  templateUrl: './user-menu.component.html',
  styleUrls: ['./user-menu.component.css']
})
export class UserMenuComponent {
  constructor(private sessionService: SessionService,private router:Router) {}

  getEmail(): string {
    return this.sessionService.getEmail();
  }

  viewPurchases(): void {
    this.router.navigate(['/purchases',this.sessionService.getUserId()]);
  }

}
