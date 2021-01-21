import {
  Component,
  OnDestroy,
  OnInit
} from '@angular/core';
import { Subject } from 'rxjs';
import { distinctUntilChanged, map, takeUntil } from 'rxjs/operators';
import { LoaderService } from '../../shared/totvs-loader/loader/loader.service';
import { CoursesPageStateService } from './couses-page-state.service';

@Component({
  selector: 'app-courses-page',
  templateUrl: './courses-page.component.html',
  styleUrls: ['./courses-page.component.css'],
  providers: [CoursesPageStateService],
})
export class CoursesPageComponent implements OnInit, OnDestroy {
  state$ = this.stateService.state$;
  private destroySubject = new Subject<void>();

  constructor(
    private stateService: CoursesPageStateService,
    private loaderService: LoaderService
  ) {}

  async ngOnInit(): Promise<void> {
    await this.stateService.initialize();
    this.state$
      .pipe(
        takeUntil(this.destroySubject),
        map((state) => state.isLoading),
        distinctUntilChanged()
      )
      .subscribe((value) => {
        if (value) {
          this.loaderService.show();
        } else {
          this.loaderService.hide();
        }
      });
  }

  onNextClicked(): Promise<void> {
    return this.stateService.goToNextPage();
  }

  ngOnDestroy(): void {
    this.destroySubject.next();
  }
}
