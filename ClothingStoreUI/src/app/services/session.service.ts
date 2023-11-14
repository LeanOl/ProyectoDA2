import { Injectable } from '@angular/core';
import { Observable, map ,catchError, of} from 'rxjs';
import { HttpClient,HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { LoginResponse } from '../models/login-response.model';

@Injectable({
  providedIn: 'root'
})
export class SessionService {

  private sessionUrl = environment.apiUrl + environment.sessionsEndpoint;

  constructor(private httpClient:HttpClient) {
  }

  login(email: string, password: string): Observable<boolean> {
    return this.postLogin(email, password).pipe(
      map((loginResponse) => {
        this.setSessionUser(loginResponse);
        return true;
      }),
      catchError((error) => {
        return of(false);
      })
    );
  }

  logout(): void {
    if (this.isLogged()) {
      this.postLogout().subscribe((ok) => {
        if (ok) {
          localStorage.removeItem('token');
          localStorage.removeItem('email');
          localStorage.removeItem('role');
          localStorage.removeItem('cart');
        }
      });
    }
  }

  isLogged(): boolean {
    return localStorage.getItem('token') !== null;
  }

  getRole(): string {
    return localStorage.getItem('role') || '';
  }
  getEmail(): string {
    return localStorage.getItem('email') || '';
  }

  private postLogin(email: string, password: string): Observable<LoginResponse> {
    return this.httpClient.post<LoginResponse>(this.sessionUrl, { email, password });
  }

  private setSessionUser(loginResponse:LoginResponse): void {
    if (loginResponse.token === undefined ||
       loginResponse.email === undefined ||
        loginResponse.role === undefined) {
      return;
    }
    localStorage.setItem('token', loginResponse.token);
    localStorage.setItem('email', loginResponse.email);
    localStorage.setItem('role', loginResponse.role.toLowerCase());
    localStorage.setItem('cart', JSON.stringify(loginResponse.cart));
  }

  private postLogout(): Observable<boolean> {
    return this.httpClient.delete(this.sessionUrl, { headers: this.getHttpLogoutHeaders(),observe: 'response' }).pipe(
      map((response) => {
        return response.status === 200;
      }),
      catchError((error) => {
        return of(false);
      })
    );
  }

  private getHttpLogoutHeaders(): HttpHeaders {

    let token = localStorage.getItem('token') || '';
    let headers = new HttpHeaders({

      Authorization:token
    });
    return headers;
  }

  



}
