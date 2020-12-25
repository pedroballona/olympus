import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';

@Component({
  selector: 'app-background-slideshow',
  templateUrl: './background-slideshow.component.html',
  styleUrls: ['./background-slideshow.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class BackgroundSlideshowComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
