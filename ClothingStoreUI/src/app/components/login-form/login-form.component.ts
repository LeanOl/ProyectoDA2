import { Component } from '@angular/core';
import { SessionService } from 'src/app/services/session.service';

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.css']
})
export class LoginFormComponent {
  
  formEmail:string = '';
  formPassword:string = '';
      constructor(private sessionService:SessionService) { }
  
      login():void {
        this.sessionService.login(this.formEmail, this.formPassword).subscribe((result) => {
          console.log(result);
        });
      }
}
