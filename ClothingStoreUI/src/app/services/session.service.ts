import { Injectable } from '@angular/core';
import { Observable, map ,catchError, of} from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { LoginResponse } from '../models/login-response.model';

@Injectable({
  providedIn: 'root'
})
export class SessionService {

  private sessionUrl = environment.apiUrl + environment.sessionEndpoint;

  constructor(private httpClient:HttpClient) { 
  }

  private postLogin(email: string, password: string): Observable<LoginResponse> {
    return this.httpClient.post<LoginResponse>(this.sessionUrl, { email, password }).pipe(
      catchError((error) => {
        const loginResponse: LoginResponse = {
          ok: false,
          token: undefined
        };
        return of(loginResponse);
      })
    );
  }

  private setSessionToken(token:string | undefined): void {
    if (token) {
      localStorage.setItem('token', token);
    }
  }

  login(email: string, password: string): Observable<boolean> {
    return this.postLogin(email, password).pipe(
      map((response) => {
        if (response.ok) {
          this.setSessionToken(response.token);
          return true;
        } else {
          return false;
        }
      })
    );
  }

  isLogged(): boolean {
    return localStorage.getItem('token') !== null;
  }

  getRole(): string {
    return 'admin';
  }


}
