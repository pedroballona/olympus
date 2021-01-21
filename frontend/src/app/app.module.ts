import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { TranslateLoader, TranslateModule } from '@ngx-translate/core';
import { PoContainerModule, PoModule } from '@po-ui/ng-components';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CourseCardComponent } from './pages/courses-page/components/course-card/course-card.component';
import { CourseListComponent } from './pages/courses-page/components/course-list/course-list.component';
import { CoursesPageComponent } from './pages/courses-page/courses-page.component';
import { SharedModule } from './shared/shared.module';
import { AppTranslationLoader } from './shared/translation-loader/translation-loader';


@NgModule({
  declarations: [
    AppComponent,
    CoursesPageComponent,
    CourseCardComponent,
    CourseListComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    SharedModule,
    BrowserAnimationsModule,
    PoModule,
    TranslateModule.forRoot({
      loader: {provide: TranslateLoader, useClass: AppTranslationLoader},
      defaultLanguage: 'pt'
    }),
    PoContainerModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
