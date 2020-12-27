import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { map } from 'rxjs/operators';
import { SearchToggleService } from '../search-toggle.service';

@Component({
  selector: 'app-top-navbar',
  templateUrl: './top-navbar.component.html',
  styleUrls: ['./top-navbar.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class TopNavbarComponent implements OnInit {
  showSearch$ = this.searchService.searchDisabled$.pipe(map(v => !v));

  constructor(private searchService: SearchToggleService) { }

  ngOnInit(): void {
  }

  toggleSearch(): void {
    this.searchService.toggleSearch();
  }
}
