import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { BackgroundSlideshowComponent } from './background-slideshow/background-slideshow.component';
import { SearchBarComponent } from './search-bar/search-bar.component';
import { TopNavbarComponent } from './top-navbar/top-navbar.component';

@NgModule({
  declarations: [SearchBarComponent, TopNavbarComponent, BackgroundSlideshowComponent],
  imports: [
    CommonModule,
    RouterModule
  ],
  exports: [SearchBarComponent, TopNavbarComponent, BackgroundSlideshowComponent]
})
export class SharedModule { }
