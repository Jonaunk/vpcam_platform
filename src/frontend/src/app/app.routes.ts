import { Routes } from '@angular/router';
import { DashboardComponent } from './features/dashboard/dashboard.component';
import { PlayerComponent } from './features/player/player.component';
import { HomeComponent } from './features/home/home.component';
import { VenueDetailComponent } from './features/venue-detail/venue-detail.component';

export const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'dashboard', redirectTo: '', pathMatch: 'full' }, // Redirect legacy dashboard to home
  { path: 'venue/:slug', component: VenueDetailComponent },
  { path: 'player/:id', component: PlayerComponent },
  // { path: 'login', component: LoginComponent } 
];
