import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Song } from './song.interface';
import { Observable, of } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class MusicService {

  constructor(
    private  httpClient: HttpClient
  ) { }

  search(searchText: string): Observable<Song[]> {
    console.log(searchText);

    return this.httpClient.get<Song[]>(environment.apiUrl + 'search/' + searchText);
  }

  addToPlaylist(songId: string) {
    console.log('ID: ' + songId);
  }
}
