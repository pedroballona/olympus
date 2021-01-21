import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-search-bar',
  templateUrl: './search-bar.component.html',
  styleUrls: ['./search-bar.component.css'],
})
export class SearchBarComponent implements OnInit {
  filter = '';

  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  search(): void {
    if (this.filter && this.filter.length > 0) {
      this.router.navigate(['courses'], {queryParams: {
        filter: this.filter
      }});
      this.filter = '';
    }
  }

}
