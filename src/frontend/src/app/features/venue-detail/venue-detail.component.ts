import { Component, OnInit, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, RouterModule, Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { Match, Venue } from '../../core/models/domain.models';
import { environment } from '../../../environments/environment';

@Component({
  selector: 'app-venue-detail',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterModule],
  templateUrl: './venue-detail.component.html',
  styles: [`
    :host {
      display: block;
      min-height: 100vh;
      background-color: #0f172a;
    }
  `]
})
export class VenueDetailComponent implements OnInit {
  venueId = signal<number>(0);
  venueName = signal<string>('');
  selectedDate = signal<string>(new Date().toISOString().split('T')[0]);
  matches = signal<Match[]>([]);
  loading = signal<boolean>(false);
  error = signal<string | null>(null);

  constructor(
    private route: ActivatedRoute, 
    private router: Router,
    private http: HttpClient
  ) {}

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      const slug = params.get('slug');
      if (slug) {
        this.resolveVenueSlug(slug);
      } else {
        this.router.navigate(['/']);
      }
    });
  }

  resolveVenueSlug(slug: string): void {
    this.loading.set(true);
    // Workaround for MVP: Fetch all to find by slug
    this.http.get<Venue[]>(`${environment.apiUrl}/venues`)
      .subscribe({
        next: (venues) => {
          const venue = venues.find(v => v.slug === slug);
          if (venue) {
            this.venueId.set(venue.id);
            this.venueName.set(venue.name);
            this.loadMatches();
          } else {
            this.error.set('Complejo no encontrado');
            this.loading.set(false);
          }
        },
        error: (err) => {
          console.error(err);
          this.error.set('Error de conexión');
          this.loading.set(false);
        }
      });
  }

  loadMatches(): void {
    this.loading.set(true);
    const date = this.selectedDate();
    const vId = this.venueId();
    
    this.http.get<Match[]>(`${environment.apiUrl}/matches?venueId=${vId}&date=${date}`)
      .subscribe({
        next: (data) => {
          this.matches.set(data);
          this.loading.set(false);
        },
        error: (err) => {
          console.error(err);
          this.loading.set(false);
        }
      });
  }

  onDateChange(event: any): void {
    this.selectedDate.set(event.target.value);
    this.loadMatches();
  }
}
