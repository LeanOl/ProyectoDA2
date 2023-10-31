import { Component, Input } from '@angular/core';
import { User } from 'src/app/models/user.model';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-user-item',
  templateUrl: './user-item.component.html',
  styleUrls: ['./user-item.component.css']
})
export class UserItemComponent {
  @Input() user: User;
  constructor(private userService: UserService) { 
    this.user = {
      id: 'abcd',
      email: 'Default',
      role: 'Default',
      deliveryAddress: 'Default',
    };
  }

  setUserToManage() : void {
    this.userService.setUserToManage(this.user);
  }
  

}
