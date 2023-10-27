import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User } from '../models/user.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private httpClient: HttpClient) { }

  userUrl = environment.apiUrl + environment.usersEndpoint;

  getAllUsers() : Observable<User[]> { 
    return this.httpClient.get<User[]>(this.userUrl);
  }
}
