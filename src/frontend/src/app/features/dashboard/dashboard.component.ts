import { Component, inject, signal } from '@angular/core';
import { CommonModule } from '@angular/common'; // Still needed for some pipes if used, but we use control flow
import { HttpClient } from '@angular/common/http';
import { DatePipe } from '@angular/common'; 

interface MatchSummary {
  id: number;
  status: string;
  startTime: string;
}

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [CommonModule, DatePipe],
  template: `
    <div class="dashboard-container">
      <h1>Matches</h1>
      
      <div class="matches-grid">
        @for (match of matches(); track match.id) {
          <div class="match-card">
            <h3>Match #{{ match.id }}</h3>
            <span class="status" [class]="match.status.toLowerCase()">{{ match.status }}</span>
            <p>{{ match.startTime | date:'short' }}</p>
            
            @if (match.status === 'READY') {
              <button (click)="play(match.id)">Watch Replay</button>
            }
          </div>
        } @empty {
          <p>No matches found.</p>
        }
      </div>
    </div>
  `,
  styles: [`
    .dashboard-container { padding: 20px; }
    .matches-grid {
      display: grid;
      grid-template-columns: repeat(auto-fill, minmax(250px, 1fr));
      gap: 20px;
    }
    .match-card {
      border: 1px solid #ddd;
      padding: 15px;
      border-radius: 8px;
    }
    .status {
      font-weight: bold;
      &.ready { color: green; }
      &.pending { color: orange; }
    }
  `]
})
export class DashboardComponent {
  private http = inject(HttpClient);
  matches = signal<MatchSummary[]>([]);

  constructor() {
    this.loadMatches();
  }

  loadMatches() {
    this.http.get<MatchSummary[]>('/api/matches').subscribe(data => {
      this.matches.set(data);
    });
  }

  play(id: number) {
    // Navigate to player
    console.log('Play', id);
  }
}
