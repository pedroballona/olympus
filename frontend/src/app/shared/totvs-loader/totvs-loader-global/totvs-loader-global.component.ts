import { ChangeDetectionStrategy, Component, Input } from '@angular/core';
import { LoaderService } from '../loader/loader.service';

@Component({
  selector: 'app-totvs-loader-global',
  templateUrl: './totvs-loader-global.component.html',
  styleUrls: ['./totvs-loader-global.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class TotvsLoaderGlobalComponent{
  @Input() menuInitialized = false;

  isLoading$ = this.loaderService.isLoading.asObservable();

  constructor(private loaderService: LoaderService) { }

}
