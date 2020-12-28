import {
  animate,
  state,
  style,
  transition,
  trigger
} from '@angular/animations';
import { Component, OnInit } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { filter, map } from 'rxjs/operators';
import { SearchToggleService } from './shared/search-toggle.service';

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
export class AppComponent implements OnInit {
  title = 'olympus-ui';
  animationState$ = this.searchService.searchVisibility$.pipe(map(shouldShow => shouldShow ? 'open' : 'closed'));

  constructor(
    private router: Router,
    private searchService: SearchToggleService,
    translate: TranslateService
  ) {
    translate.setDefaultLang('en');
    translate.use(translate.getBrowserLang());
  }

  ngOnInit(): void {
    this.router.events
      .pipe(filter((event) => event instanceof NavigationEnd))
      .subscribe((event) => {
        const castedEvent = event as NavigationEnd;
        if (castedEvent.url === '/') {
          this.searchService.setSearchDisabled(true);
          this.searchService.showSearch();
        } else {
          this.searchService.setSearchDisabled(false);
          this.searchService.hideSearch();
        }
      });
  }
}
