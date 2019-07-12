import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { MusicService } from './music.service';
import { Observable } from 'rxjs';
import { Song } from './song.interface';
import { environment } from 'src/environments/environment';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'safemusic';
  musicForm: FormGroup;
  result: Song[] = [];

  constructor(
    private musicService: MusicService,
    private formBuilder: FormBuilder,
    private route: ActivatedRoute
     ) { }

  ngOnInit() {
    if (window.location.href.indexOf('access_token') > 0 && window.location.href.split('access_token=').length > 0) {
      this.musicService.spotifyToken = window.location.href.split('access_token=')[1].split('&token_type')[0];
      alert(this.musicService.spotifyToken);
    } else {
      window.location.href = environment.spotifyUrl;
    }

    this.musicForm  =  this.formBuilder.group({
      search: ['', Validators.required]
    });
  }

  get formControls() { return this.musicForm.controls; }

  search() {
    if (this.musicForm.invalid) {
      return;
    }
    this.musicService.search(this.musicForm.value.search).subscribe(
      result => this.result = result
    );
  }

  onAddToPlaylist(songId: string) {
    this.musicService.addToPlaylist(songId).subscribe();
  }
}
