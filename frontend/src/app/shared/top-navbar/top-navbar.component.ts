import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';

@Component({
  selector: 'app-top-navbar',
  templateUrl: './top-navbar.component.html',
  styleUrls: ['./top-navbar.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class TopNavbarComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
