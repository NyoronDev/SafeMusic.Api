import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Song } from './song.interface';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MusicService {

  constructor(
    private  httpClient: HttpClient
  ) { }

  search(searchText: string): Observable<Song[]> {
    console.log(searchText);
    return of([
      {
        artist: 'Lisandro',
        name: 'El Boludo',
        // tslint:disable-next-line:max-line-length
        image: 'https://cdn.memegenerator.es/imagenes/memes/full/2/63/2635159.jpg',
        id: '1'
      },
      {
        artist: 'Juan',
        name: 'Space',
        // tslint:disable-next-line:max-line-length
        image: 'https://st2.depositphotos.com/7209366/10104/v/600/depositphotos_101042980-stock-video-europe-from-space-sunrise-earth.jpg',
        id: '2'
      },
    ]);
  }

  addToPlaylist(songId: string) {
    console.log('ID: ' + songId);
  }
}
