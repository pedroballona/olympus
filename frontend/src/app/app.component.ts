import {
  animate,
  state,
  style,
  transition,
  trigger
} from '@angular/animations';
import { Component } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';
import { filter, map } from 'rxjs/operators';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  animations: [
    trigger('openClose', [
      state(
        'closed',
        style({
          top: '0',
        })
      ),
      state(
        'open',
        style({
          top: '100vh',
        })
      ),
      transition('open <=> closed', [animate('1s ease-out')]),
    ]),
  ],
})
export class AppComponent {
  title = 'olympus-ui';
  animationState$ = this.router.events.pipe(
    filter((event) => event instanceof NavigationEnd),
    map((event) => {
      const castedEvent = event as NavigationEnd;
      return castedEvent.url === '/' ? 'open' : 'closed';
    })
  );

  constructor(private router: Router) {}
}
