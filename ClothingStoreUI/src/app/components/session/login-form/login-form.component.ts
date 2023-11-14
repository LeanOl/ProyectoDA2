import { Component } from '@angular/core';
import { SessionService } from 'src/app/services/session.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.css']
})
export class LoginFormComponent {
  
  formEmail:string = '';
  formPassword:string = '';
  displayError:boolean = false;
      constructor(private sessionService:SessionService, private router:Router) { }
  
      login():void {
        this.sessionService.login(this.formEmail, this.formPassword).subscribe((result) => {
          if (result){
            this.router.navigate(['/']);
          }else{
            this.displayError = true;
          }
        });
      }
}
