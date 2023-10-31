import { Component } from '@angular/core';
import { SessionService } from 'src/app/services/session.service';

@Component({
  selector: 'app-admin-menu',
  templateUrl: './admin-menu.component.html',
  styleUrls: ['./admin-menu.component.css']
})
export class AdminMenuComponent {
  constructor(private sessionService: SessionService) {}

  getEmail(): string {
    return this.sessionService.getEmail();
  }
}
