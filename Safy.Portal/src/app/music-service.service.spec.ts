import { TestBed } from '@angular/core/testing';

import { MusicService } from './music.service';

describe('MusicServiceService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: MusicService = TestBed.get(MusicService);
    expect(service).toBeTruthy();
  });
});
