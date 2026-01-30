import { Injectable, inject, signal } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { tap, switchMap, catchError, of } from 'rxjs';

export interface User {
  id: string; // Local ID
  email: string;
  externalId: string;
}

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private http = inject(HttpClient);
  private router = inject(Router);

  // Signals
  currentUser = signal<User | null>(null);
  
  // Config
  private readonly appendIdentityUrl = 'https://appendidentity.com/api/v1/Account/Authenticate'; // Example URL, should be env var
  private readonly vpcamApiUrl = '/api'; // Proxy or absolute URL

  login(email: string, password: string) {
    return this.http.post<any>(this.appendIdentityUrl, { email, password }).pipe(
      tap(response => {
        // Assume response has token
        const token = response.token; 
        localStorage.setItem('access_token', token);
      }),
      switchMap(() => this.syncUser()),
      tap(user => {
        this.currentUser.set(user);
        this.router.navigate(['/dashboard']);
      })
    );
  }

  syncUser() {
    return this.http.post<User>(`${this.vpcamApiUrl}/users/sync`, {});
  }

  logout() {
    localStorage.removeItem('access_token');
    this.currentUser.set(null);
    this.router.navigate(['/login']);
  }

  getToken(): string | null {
    return localStorage.getItem('access_token');
  }
}
