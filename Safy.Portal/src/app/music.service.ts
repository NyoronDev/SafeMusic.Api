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
  
  billboard: Song[] = [
    {
      "artist": "Aerosmith",
      "name": "Sweet Emotion",
      "image": "https://i.scdn.co/image/c34dd22b96e2fe11f75a9db24d1a6a3382832f77",
      "id": "24NwBd5vZ2CK8VOQVnqdxr",
      "album": "Toys In The Attic"
    },
    {
      "artist": "Metallica",
      "name": "Nothing Else Matters",
      "image": "https://i.scdn.co/image/deb44798f4a2fff65c62bf4ca2c9b0ebb4a7f5f2",
      "id": "10igKaIKsSB6ZnWxPxPvKO",
      "album": "Metallica"
    },
    {
      "artist": "Rage Against The Machine",
      "name": "Killing In The Name",
      "image": "https://i.scdn.co/image/85236cc12312fac9405206c25bd38479e63a04d6",
      "id": "59WN2psjkt1tyaxjspN8fp",
      "album": "Rage Against The Machine - XX (20th Anniversary Special Edition)"
    },
    {
      "artist": "Bob Marley & The Wailers",
      "name": "Jamming",
      "image": "https://i.scdn.co/image/7511c61476f7e33f1c80560c1d1eb9cb844cfac9",
      "id": "4zn0kScuV9Oj28d4g9CQQs",
      "album": "Exodus (Deluxe Edition)"
    },
    {
      "artist": "Becky GNatti Natasha",
      "name": "Sin Pijama",
      "image": "https://i.scdn.co/image/e8a4b24f1136afdb2b905f8e3a52c51e2082b7b2",
      "id": "2ijef6ni2amuunRoKTlgww",
      "album": "Sin Pijama"
    },
    {
      "artist": "Nirvana",
      "name": "Come As You Are",
      "image": "https://i.scdn.co/image/52b8f5143396bb96c5e801b2c05f7dd51acafb5e",
      "id": "4P5KoWXOxwuobLmHXLMobV",
      "album": "Nevermind (Remastered)"
    },
    {
      "artist": "Audioslave",
      "name": "Like a Stone",
      "image": "https://i.scdn.co/image/d0cd8c42f2816b208641d030f809d155a7484756",
      "id": "3YuaBvuZqcwN3CEAyyoaei",
      "album": "Audioslave"
    },
    {
      "artist": "Post Malone",
      "name": "Wow.",
      "image": "https://i.scdn.co/image/4a09059a2a756967588647bbcb5fd5f6fd8dd434",
      "id": "6MWtB6iiXyIwun0YzU6DFP",
      "album": "Wow."
    },
    {
      "artist": "Soda Stereo",
      "name": "Persiana Americana",
      "image": "https://i.scdn.co/image/a4ad1374d33bac4f7e31286fc7804532aaf13e8b",
      "id": "7JZP7kQsuFFWOrtAI7uNiW",
      "album": "Originales - 20 Exitos"
    }
  ];

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
