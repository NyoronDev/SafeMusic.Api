import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Song } from './song.interface';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class MusicService {

  spotifyToken = '';

  constructor(
    private  httpClient: HttpClient
  ) { }

  search(searchText: string): Observable<Song[]> {
    return this.httpClient.get<Song[]>(`${environment.apiUrl}search/${searchText}`);
  }

  addToPlaylist(songId: string): Observable<any> {
    return this.httpClient.post(`${environment.apiUrl}search`, { 'track-id': songId, 'token': this.spotifyToken });
  }
}
