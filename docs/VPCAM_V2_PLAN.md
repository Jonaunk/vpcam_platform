# VPCAM v2 Pivot Implementation Plan

# Goal Description
Pivot the VPCAM platform to a Multi-Venue Automated Video System.
- Introduce `Venue` and `Court` entities.
- Seed real venue data.
- Expose venues via API.
- Filter matches by venue and date.
- Complete frontend overhaul (Dark mode, neon branding, venue selector).

## User Review Required
> [!IMPORTANT]
> This pivot involves wiping the existing database to seed new structure. Ensure no critical data is lost (Current environment is assumed MVP/Dev).

## Proposed Changes

### VPCAM.Core
#### [NEW] [Venue.cs](file:///wsl.localhost/Ubuntu/home/jonaunk/dev/vpcam-platform/src/backend/VPCAM.Core/Entities/Venue.cs)
- Id, Name, Slug, ImageUrl, Location, Courts collection.

#### [NEW] [Court.cs](file:///wsl.localhost/Ubuntu/home/jonaunk/dev/vpcam-platform/src/backend/VPCAM.Core/Entities/Court.cs)
- Id, VenueId, Name, NvrChannelId, RtspUrl.

#### [MODIFY] [Match.cs](file:///wsl.localhost/Ubuntu/home/jonaunk/dev/vpcam-platform/src/backend/VPCAM.Core/Entities/Match.cs)
- Add `CourtId`.
- Update `Status` enum (Scheduled, Recording, Processing, Ready).

#### [MODIFY] [VpcamDbContext.cs](file:///wsl.localhost/Ubuntu/home/jonaunk/dev/vpcam-platform/src/backend/VPCAM.Api/Infrastructure/Data/VpcamDbContext.cs)
- Add `DbSet<Venue>`, `DbSet<Court>`.
- Configure relationships.
- Add Seeder logic (OnModelCreating or separate Seeder).

#### [NEW] [DbInitializer.cs](file:///wsl.localhost/Ubuntu/home/jonaunk/dev/vpcam-platform/src/backend/VPCAM.Api/Infrastructure/Data/DbInitializer.cs)
- Class to handle seeding of "La Fábrica" and "Antártida Padel".

### VPCAM.Api
#### [NEW] [VenuesController.cs](file:///wsl.localhost/Ubuntu/home/jonaunk/dev/vpcam-platform/src/backend/VPCAM.Api/Controllers/VenuesController.cs)
- `GET /api/venues`: Returns list of venues.

#### [MODIFY] [MatchesController.cs](file:///wsl.localhost/Ubuntu/home/jonaunk/dev/vpcam-platform/src/backend/VPCAM.Api/Controllers/MatchesController.cs)
- Update `GET /api/matches` to support `?venueId=X&date=Y`.

### VPCAM.Frontend
#### [MODIFY] [tailwind.config.js](file:///wsl.localhost/Ubuntu/home/jonaunk/dev/vpcam-platform/src/frontend/tailwind.config.js)
- Add brand colors (Neon Green).

#### [MODIFY] [app.component.html](file:///wsl.localhost/Ubuntu/home/jonaunk/dev/vpcam-platform/src/frontend/src/app/app.component.html)
- Apply dark theme background (#0f172a).

#### [MODIFY] [home.component.ts](file:///wsl.localhost/Ubuntu/home/jonaunk/dev/vpcam-platform/src/frontend/src/app/features/home/home.component.ts)
- Implement Hero section "GRABAMOS TU PARTIDO".
- Implement Venue Selector.

#### [NEW] [venue-detail.component.ts](file:///wsl.localhost/Ubuntu/home/jonaunk/dev/vpcam-platform/src/frontend/src/app/features/venue-detail/venue-detail.component.ts)
- Show filtered matches for a venue and date.

## Verification Plan

### Automated Tests
- Run `dotnet build` on `VPCAM.Core`, `VPCAM.Api`, `VPCAM.Worker`.
- Run frontend build: `npm run build` (or `ng build`).

### Manual Verification
- Since this is a refactor, I will focus on ensuring the project compiles and the data seeding logic is in place.
