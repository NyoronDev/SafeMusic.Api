import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { MusicService } from './music.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Song } from './song.interface';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'safemusic';
  musicForm: FormGroup;
  result: Song[] = [];
  @ViewChild('content', null) modal: ElementRef;
  message: string;

  constructor(
    private musicService: MusicService,
    private formBuilder: FormBuilder,
    private modalService: NgbModal
     ) { }

  ngOnInit() {
    if (window.location.href.indexOf('access_token') > 0 && window.location.href.split('access_token=').length > 0) {
      this.musicService.spotifyToken = window.location.href.split('access_token=')[1].split('&token_type')[0];
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
    this.musicService.search(this.musicForm.value.search)
      .subscribe(
        result => this.result = result
      );
  }

  onAddToPlaylist(songId: string) {
    this.musicService.addToPlaylist(songId)
      .subscribe(
        result => {
          this.result = [];
          this.message = 'The song has been aded to the playlist, enjoy!';
          this.modalService.open(this.modal, {ariaLabelledBy: 'modal-basic-title'});
        },
        err => {
          this.message = 'The song was unable to be added, sorry!';
          this.modalService.open(this.modal, {ariaLabelledBy: 'modal-basic-title'});
        }
      );
  }
}
