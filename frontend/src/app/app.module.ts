import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { TranslateLoader, TranslateModule } from '@ngx-translate/core';
import { PoModule } from '@po-ui/ng-components';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CoursesPageComponent } from './pages/courses-page/courses-page.component';
import { SharedModule } from './shared/shared.module';
import { AppTranslationLoader } from './shared/translation-loader/translation-loader';


@NgModule({
  declarations: [
    AppComponent,
    CoursesPageComponent
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
    })
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
