import {
  animate, state,
  style,
  transition, trigger
} from '@angular/animations';
import { Component, OnInit } from '@angular/core';
import { PoMenuItem } from '@po-ui/ng-components';
import { map } from 'rxjs/operators';
import { SideBarService } from './side-bar.service';

@Component({
  selector: 'app-side-bar',
  templateUrl: './side-bar.component.html',
  styleUrls: ['./side-bar.component.css'],
  animations: [
    trigger('openClose', [
      state(
        'open',
        style({
          width: '250px',
        })
      ),
      state(
        'close',
        style({
          width: '0'
        })
      ),
      transition('open <=> closed', [animate('500ms ease-out')]),
    ]),
    trigger('overlay', [
      transition(':enter', [
        style({ opacity: 0 }),
        animate('500ms', style({ opacity: 1 })),
      ]),
      transition(':leave', [
        animate('500ms', style({ opacity: 0 }))
      ])
    ])
  ],
})
export class SideBarComponent implements OnInit {
  sideBarAnimationState$ = this.service.isOpen$.pipe(map(v => v ? 'open' : 'closed'));
  isOpen$ = this.service.isOpen$;
  menus: PoMenuItem[] = [
    {
      label: 'Test'
    },
    {
      label: 'Test 2'
    }
  ];

  constructor(private service: SideBarService) {}

  ngOnInit(): void {}

  toggle(): void {
    this.service.toggle();
  }
}
