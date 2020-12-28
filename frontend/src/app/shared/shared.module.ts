import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule } from '@angular/router';
import { TranslateModule } from '@ngx-translate/core';
import { PoMenuModule } from '@po-ui/ng-components';
import { BackgroundSlideshowComponent } from './background-slideshow/background-slideshow.component';
import { SearchBarComponent } from './search-bar/search-bar.component';
import { SideBarComponent } from './side-bar/side-bar.component';
import { TopNavbarComponent } from './top-navbar/top-navbar.component';

@NgModule({
  declarations: [
    SearchBarComponent,
    TopNavbarComponent,
    BackgroundSlideshowComponent,
    SideBarComponent,
  ],
  imports: [
    CommonModule,
    RouterModule,
    PoMenuModule,
    BrowserAnimationsModule,
    TranslateModule.forChild(),
  ],
  exports: [
    SearchBarComponent,
    TopNavbarComponent,
    BackgroundSlideshowComponent,
    SideBarComponent,
  ],
})
export class SharedModule {}
