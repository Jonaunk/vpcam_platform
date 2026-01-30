# VPCAM ARCHITECTURE (Cloud-Only MVP)

## 1. Overview
Platform for managing soccer match recordings.
Integration Strategy: **Cloud-to-Cloud**. We consume media via Dahua Open Platform API URLs.
Identity Strategy: **Federated**. We use AppendIdentity for AuthN, but maintain a local Users table for AuthZ and business logic.

## 2. Core Components

### A. Backend API (.NET 8)
- **Role**: Entry point and Orchestrator.
- **Auth**: Validates JWT Bearer tokens issued by AppendIdentity.
- **Sync**: Exposes `/api/users/sync` to create/update local user records based on the JWT claims.
- **Webhooks**: Receives `recordUpload` events from Dahua Cloud.
- **Database**: SQL Server (Stores Users, Matches, Complexes).

### B. Worker Service (.NET 8)
- **Role**: Heavy Processing (Background).
- **Trigger**: Consumes messages from RabbitMQ.
- **Task**: 
  1. Download video file from external URL (Dahua).
  2. Transcode/Remux to HLS (using Xabe.FFmpeg).
  3. Upload to Cloudflare R2 (S3 Protocol).
  4. Update DB Status.

### C. Frontend (Angular 19)
- **Auth**: Logs in against AppendIdentity API directly.
- **Sync**: Immediately calls VPCAM `/api/users/sync` after login.
- **Playback**: HLS Video Player (Video.js).

## 3. Data Schema (Simplified)

### Users (Local Table)
- `Id` (Guid): PK.
- `ExternalIdentityId` (Guid): FK to AppendIdentity Subject.
- `Email`: Copied for local search.
- `CurrentRoleId`: Assigned role in VPCAM context.

### Matches
- `Id` (Int): PK.
- `Status`: PENDING, PROCESSING, READY, ERROR.
- `CdnUrl`: The R2 public URL (HLS .m3u8).
- `DahuaUrl`: Original source URL.

## 4. Constraints
- NO RTSP connections.
- NO VPNs.
- NO Password storage in VPCAM.