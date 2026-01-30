# FRONTEND SPECIFICATIONS (VPCAM)

## 1. Technology Stack
- **Framework**: Angular 21.
- **Architecture**:
  - **Standalone Components**: Mandatory (No NgModules).
  - **Change Detection**: **Zoneless** enabled (`provideExperimentalZonelessChangeDetection` or stable equivalent in v21).
  - **Control Flow**: New syntax (`@if`, `@for`, `@defer`) mandatory.
- **Language**: TypeScript 6.x (Strict Mode enabled).
- **Build System**: Application Builder (Esbuild/Vite based).

## 2. Styling Strategy
- **Format**: SCSS (Sass) Pure.
- **Methodology**:
  - **Component-Scoped**: Use `ViewEncapsulation.Emulated` (default).
  - **Architecture**: Modular SCSS (one file per component).
  - **Global**: Use `src/styles.scss` ONLY for CSS Variables (Colors, Spacing) and Reset.
- **Layout**: Native CSS Grid and Flexbox.
- **Restrictions**: NO external UI libraries (No Material, No Tailwind, No PrimeNG).

## 3. State Management & Reactivity
- **Local State**: `signal()`, `computed()`.
- **Inputs/Outputs**: Signal Inputs (`input.required()`) and `output()`.
- **Global State**: Injectable Services using Signals. No NgRx/Redux for MVP.
- **Async**: Use `rxResource` or `toSignal` for HTTP data fetching.

## 4. Integration & Auth (Federated)
- **AuthService**:
  - **Identity Provider**: Consumes `IDENTITY_CONTRACT` (AppendIdentity).
  - **Endpoint**: `POST /api/v1/Account/Authenticate`.
  - **Workflow**:
    1. Authenticate with AppendIdentity -> Receive JWT.
    2. Store JWT in LocalStorage/SessionStorage.
    3. **Immediate Sync**: Call VPCAM API `POST /api/users/sync` to ensure local user provisioning.
- **Interceptors**:
  - `AuthInterceptor` (Functional Interceptor): Injects `Authorization: Bearer <token>` header **only** for requests to the VPCAM API domain.

## 5. Key Components
- **LoginComponent**:
  - Reactive Form (Typed).
  - Connects to AuthService.
- **DashboardComponent**:
  - Displays Match List.
  - Uses CSS Grid for responsive cards.
  - Implements filters (Date, Status