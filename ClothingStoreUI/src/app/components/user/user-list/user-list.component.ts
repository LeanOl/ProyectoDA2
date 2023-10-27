import { Component } from '@angular/core';
import { User } from 'src/app/models/user.model';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent {
  
    users: User[];
    constructor(private userService: UserService) {
      this.users = [];
    }

    ngOnInit(): void {
      this.userService.getAllUsers().subscribe((users) => {
        this.users = users;
      });
    }
}
