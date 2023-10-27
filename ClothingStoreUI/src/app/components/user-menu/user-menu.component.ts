import { Component } from '@angular/core';
import { SessionService } from 'src/app/services/session.service';

@Component({
  selector: 'app-user-menu',
  templateUrl: './user-menu.component.html',
  styleUrls: ['./user-menu.component.css']
})
export class UserMenuComponent {
  constructor(private sessionService: SessionService) {}

  getEmail(): string {
    return this.sessionService.getEmail();
  }
  
}
