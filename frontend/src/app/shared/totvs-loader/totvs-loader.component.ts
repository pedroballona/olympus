import { Component, Input } from '@angular/core';
@Component({
  selector: 'app-totvs-loader',
  templateUrl: './totvs-loader.component.html',
  styleUrls: ['./totvs-loader.component.css'],
})
export class TotvsLoaderComponent {
  @Input() width = '300px';
  @Input() maxWidth?: string;
  @Input() minWidth?: string;
}
