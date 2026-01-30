# VPCAM v2 Pivot Task List

- [x] **Step 1: Domain Refactor (VPCAM.Core)**
    - [x] Create `Venue` Entity <!-- id: 1 -->
    - [x] Create `Court` Entity <!-- id: 2 -->
    - [x] Update `Match` Entity (Status, CourtId) <!-- id: 3 -->
    - [x] Update `VpcamDbContext` (DbSets, Relationships) <!-- id: 4 -->
    - [x] Create Migration `Pivot_MultiVenue` <!-- id: 5 -->
    - [x] Implement Data Seeder (Real Venues & Matches) <!-- id: 6 -->

- [x] **Step 2: API Contract Update (VPCAM.Api)**
    - [x] Create `VenuesController` (`GET /api/venues`) <!-- id: 7 -->
    - [x] Update `MatchesController` (Filter by `venueId` & `date`) <!-- id: 8 -->
    - [x] Verify Backend Build <!-- id: 9 -->

- [x] **Step 3: Frontend Overhaul (Angular)**
    - [x] Configure Tailwind (Dark Mode, Neon/Green) <!-- id: 10 -->
    - [x] Create `Venue` Service & Interfaces <!-- id: 11 -->
    - [x] Update `HomeComponent` (Hero, Venue Selector) <!-- id: 12 -->
    - [x] Create/Update `VenueDetailComponent` (Date Picker, Match List) <!-- id: 13 -->
    - [x] Refactor UI to Strict SportsReel Specs <!-- id: 15 -->
    - [ ] Verify Frontend Build <!-- id: 14 -->
