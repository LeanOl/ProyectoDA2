import { Injectable } from '@angular/core';
import { HttpClient,HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User } from '../models/user.model';
import { UserRegister } from '../models/user-register.model';

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
    return this.httpClient.get<User[]>(this.userUrl,{headers: this.getHttpAuthorizationHeaders()});
  }

  updateUser(user: User) : Observable<User> {
    return this.httpClient.put<User>(this.userUrl + '/' + user.id, user);
  }

  deleteUser(id: string) : Observable<{}> {
    return this.httpClient.delete(this.userUrl + '/' + id);
  }

  setUserToManage(user: User) : void {
    this.userToManage = user;
  }

  getUserToManage() : User {
    return this.userToManage;
  }

   registerUser(user: UserRegister) : Observable<User> {
    return this.httpClient.post<User>(this.userUrl, user);
  }

  private getHttpAuthorizationHeaders(): HttpHeaders {
   
    let token = localStorage.getItem('token') || '';
    let headers = new HttpHeaders({
      Authorization:token
    });
    return headers;
  }
}
