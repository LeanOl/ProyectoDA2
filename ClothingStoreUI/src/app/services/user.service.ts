import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User } from '../models/user.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  userUrl = environment.apiUrl + environment.usersEndpoint;
  userToManage: User;
  constructor(private httpClient: HttpClient) { 
    this.userToManage = {
      id: 'Default',
      email: 'Default',
      role: 'Default',
      deliveryAddress: 'Default',
    };
  }

  getAllUsers() : Observable<User[]> { 
    return this.httpClient.get<User[]>(this.userUrl);
  }

  updateUser(user: User) : Observable<User> {
    return this.httpClient.put<User>(this.userUrl + '/' + user.id, user);
  }

  setUserToManage(user: User) : void {
    this.userToManage = user;
  }

  getUserToManage() : User {
    return this.userToManage;
  }


}
