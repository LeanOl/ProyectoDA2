import { Injectable } from '@angular/core';
import { Observable, map ,catchError, of} from 'rxjs';
import { HttpClient,HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { LoginResponse } from '../models/login-response.model';

@Injectable({
  providedIn: 'root'
})
export class SessionService {

  private sessionUrl = environment.apiUrl + environment.sessionEndpoint;

  constructor(private httpClient:HttpClient) { 
  }

  login(email: string, password: string): Observable<boolean> {
    return this.postLogin(email, password).pipe(
      map((response) => {
        if (response.ok) {
          this.setSessionUser(response);
          return true;
        } else {
          return false;
        }
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

  private setSessionUser(loginResponse:LoginResponse): void {
    if (loginResponse.token === undefined ||
       loginResponse.email === undefined ||
        loginResponse.role === undefined) {
      return;
    }
    localStorage.setItem('token', loginResponse.token);
    localStorage.setItem('email', loginResponse.email);
    localStorage.setItem('role', loginResponse.role);
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
