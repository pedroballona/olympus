import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SearchToggleService {
  private searchVisibilitySubject = new BehaviorSubject<boolean>(false);
  private searchDisabledSubject = new BehaviorSubject<boolean>(false);
  searchVisibility$ = this.searchVisibilitySubject.asObservable();
  searchDisabled$ = this.searchDisabledSubject.asObservable();

  toggleSearch(): void {
    this.searchVisibilitySubject.next(!this.searchVisibilitySubject.value);
  }

  showSearch(): void {
    this.searchVisibilitySubject.next(true);
  }

  hideSearch(): void {
    this.searchVisibilitySubject.next(false);
  }

  setSearchDisabled(value: boolean): void {
    this.searchDisabledSubject.next(value);
  }
}
