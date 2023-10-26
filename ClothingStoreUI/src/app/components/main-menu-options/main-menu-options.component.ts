import { Component } from '@angular/core';
import { SessionService } from 'src/app/services/session.service';

@Component({
  selector: 'app-main-menu-options',
  templateUrl: './main-menu-options.component.html',
  styleUrls: ['./main-menu-options.component.css']
})
export class MainMenuOptionsComponent {
    constructor (private sessionService: SessionService) {}
    isLoggedIn(): boolean {
      return this.sessionService.isLogged();
    }
    logout(): void {
      this.sessionService.logout();
    }
}
