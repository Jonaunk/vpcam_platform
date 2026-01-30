# VPCAM v2 Pivot - Walkthrough

The platform has been pivoted to a Multi-Venue system. Here is what has been implemented:

## Backend Changes (VPCAM.Core & VPCAM.Api)
- **Entities**: Created `Venue` and `Court` entities. Updated `Match` to link to `Court` and use new Status enum.
- **Database**: `VpcamDbContext` updated with new DbSets and relationships.
- **Seeding**: `DbInitializer` configured to seed:
  - **Venue 1**: "La Fábrica" (2 Courts)
  - **Venue 2**: "Antártida Padel" (3 Courts)
- **API**:
  - `GET /api/venues`: Returns all venues.
  - `GET /api/matches`: Supports filtering by `venueId` and `date`.

## Frontend Changes (Angular)
- **Home Page**: 
  - Hero section with slogan: *"GRABAMOS TU PARTIDO. No la cuentes más, mostrala."*
  - Grid of venues fetched from API.
  - Neon Green branding (`#00ff00`) on Dark Background (`#0f172a`).
- **Venue Detail**:
  - Route `/venue/:id`.
  - Date picker to filter matches.
  - List of matches with status indicators.
- **Routing**: Updated `app.routes.ts` to set Home as default.

## Verification Steps
1. **Run Backend**: `dotnet run` in `src/backend/VPCAM.Api`.
   - *Check*: Database should be seeded on startup.
2. **Run Frontend**: `ng serve` (or `npm start`) in `src/frontend`.
   - *Check*: Browser should show "GRABAMOS TU PARTIDO" hero.
   - *Check*: Venues "La Fábrica" and "Antártida Padel" should appear.
   - *Click*: Select a venue, verify you can filter matches by date.
