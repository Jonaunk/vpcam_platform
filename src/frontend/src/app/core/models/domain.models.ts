export interface Court {
  id: number;
  venueId: number;
  name: string;
}

export interface Venue {
  id: number;
  name: string;
  slug: string;
  imageUrl: string;
  location: string;
  courts: Court[];
}

export interface Match {
  id: number;
  courtId: number;
  courtName: string;
  status: 'Scheduled' | 'Recording' | 'Processing' | 'Ready' | 'Error';
  statusString: string;
  startTime: string;
  cdnUrl?: string; // Present when Ready
}
