import { Component, OnInit } from '@angular/core';
import { map } from 'rxjs/operators';
import { SearchToggleService } from '../search-toggle.service';
import { SideBarService } from '../side-bar/side-bar.service';

@Component({
  selector: 'app-top-navbar',
  templateUrl: './top-navbar.component.html',
  styleUrls: ['./top-navbar.component.css'],
})
export class TopNavbarComponent implements OnInit {
  showSearch$ = this.searchService.searchDisabled$.pipe(map(v => !v));

  constructor(private searchService: SearchToggleService, private sideBarService: SideBarService) { }

  ngOnInit(): void {
  }

  toggleSearch(): void {
    this.searchService.toggleSearch();
  }

  toggleSideBar(): void {
    this.sideBarService.toggle();
  }
}
