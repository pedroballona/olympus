import { Location } from '@angular/common';
import {
  ChangeDetectionStrategy,
  Component,
  OnDestroy,
  OnInit
} from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subject } from 'rxjs';
import { distinctUntilChanged, map, takeUntil } from 'rxjs/operators';
import { LoaderService } from '../../shared/totvs-loader/loader/loader.service';
import { LessonPageStateService } from './lesson-page-state.service';

@Component({
  selector: 'app-lesson-page',
  templateUrl: './lesson-page.component.html',
  styleUrls: ['./lesson-page.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush,
  providers: [LessonPageStateService],
})
export class LessonPageComponent implements OnInit, OnDestroy {
  state$ = this.stateService.state$;
  destroySubject = new Subject<void>();

  constructor(
    private stateService: LessonPageStateService,
    private loaderService: LoaderService,
    private activatedRoute: ActivatedRoute,
    private location: Location
  ) {}

  ngOnInit(): void {
    this.activateLoader();
    this.activatedRoute.params.subscribe(
      async params => {
        const id: string = params.id;
        await this.stateService.setCourseId(id);
      }
    );
  }

  private activateLoader(): void {
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

  ngOnDestroy(): void {
    this.destroySubject.next();
  }

  goBack(): void {
    this.location.back();
  }
}
