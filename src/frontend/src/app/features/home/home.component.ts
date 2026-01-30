import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { Venue } from '../../core/models/domain.models';
import { environment } from '../../../environments/environment';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './home.component.html'
})
export class HomeComponent implements OnInit {
  venues: Venue[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.http.get<Venue[]>(`${environment.apiUrl}/venues`)
      .subscribe(data => this.venues = data);
  }
}
