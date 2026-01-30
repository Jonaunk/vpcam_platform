import { Component, input, effect, ElementRef, viewChild, OnDestroy } from '@angular/core';
import videojs from 'video.js';
import Player from 'video.js/dist/types/player';

@Component({
  selector: 'app-player',
  standalone: true,
  template: `
    <div class="video-container">
      <video #target class="video-js vjs-default-skin vjs-big-play-centered" controls playsinline></video>
    </div>
  `,
  styles: [`
    .video-container {
      width: 100%;
      max-width: 800px;
      margin: 0 auto;
    }
  `]
})
export class PlayerComponent implements OnDestroy {
  // Input signal for URL
  src = input.required<string>();
  
  // ViewChild signal
  videoElement = viewChild.required<ElementRef>('target');
  
  private player: Player | undefined;

  constructor() {
    // Effect to update source when signal changes
    effect(() => {
      const url = this.src();
      if (this.player) {
         this.player.src({ src: url, type: 'application/x-mpegURL' });
      } else {
        this.initPlayer(url);
      }
    });
  }

  private initPlayer(url: string) {
    // We need to wait for view init in effect usually, or use afterNextRender. 
    // In zoneless, effects run asynchronously.
    // Need to ensure element is present. 
    // For simplicity in this skeleton, we assume element exists when effect runs.
    
    if (!this.videoElement()) return;

    this.player = videojs(this.videoElement().nativeElement, {
      fluid: true,
      sources: [{
        src: url,
        type: 'application/x-mpegURL'
      }]
    });
  }

  ngOnDestroy() {
    if (this.player) {
      this.player.dispose();
    }
  }
}
