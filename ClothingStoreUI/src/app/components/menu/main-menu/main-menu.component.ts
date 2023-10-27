import { Component } from '@angular/core';
import { SessionService } from 'src/app/services/session.service';

@Component({
  selector: 'app-main-menu',
  templateUrl: './main-menu.component.html',
  styleUrls: ['./main-menu.component.css']
})
export class MainMenuComponent {
  
    constructor(private sessionService:SessionService) { }
  
    isLogged():boolean {
      return this.sessionService.isLogged();
    }
    isRoleAdmin():boolean {
      return this.sessionService.getRole() === 'admin';
    }
    isRoleUser():boolean {
      return this.sessionService.getRole() === 'user';
    }
}
