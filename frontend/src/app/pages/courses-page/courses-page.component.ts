import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { CoursesPageStateService } from './couses-page-state.service';

@Component({
  selector: 'app-courses-page',
  templateUrl: './courses-page.component.html',
  styleUrls: ['./courses-page.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush,
  providers: [CoursesPageStateService]
})
export class CoursesPageComponent implements OnInit {
  state$ = this.stateService.state$;

  constructor(private stateService: CoursesPageStateService) { }

  async ngOnInit(): Promise<void> {
    await this.stateService.initialize();
  }

  onNextClicked(): Promise<void> {
    return this.stateService.goToNextPage();
  }

}
