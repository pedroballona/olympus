import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { BrowserModule } from "@angular/platform-browser";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { TranslateLoader, TranslateModule } from "@ngx-translate/core";
import {
  PoContainerModule,
  PoModule,
  PoWidgetModule,
} from "@po-ui/ng-components";
import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { CourseCardComponent } from "./pages/courses-page/components/course-card/course-card.component";
import { CourseDetailModalComponent } from "./pages/courses-page/components/course-detail-modal/course-detail-modal.component";
import { CourseListComponent } from "./pages/courses-page/components/course-list/course-list.component";
import { CoursesPageComponent } from "./pages/courses-page/courses-page.component";
import { SharedModule } from "./shared/shared.module";
import { AppTranslationLoader } from "./shared/translation-loader/translation-loader";
import { LearningPathsPageComponent } from "./pages/learning-paths-page/learning-paths-page.component";
import { LearningPathCardComponent } from './pages/learning-paths-page/components/learning-path-card/learning-path-card.component';
import { LearningPathListComponent } from './pages/learning-paths-page/components/learning-path-list/learning-path-list.component';
import { LearningPathDetailModalComponent } from './pages/learning-paths-page/components/learning-path-detail-modal/learning-path-detail-modal.component';
import { LessonPageComponent } from './pages/lesson-page/lesson-page.component';
import { LearningPathInputModalComponent } from './pages/learning-paths-page/learning-path-input-modal/learning-path-input-modal.component';

@NgModule({
  declarations: [
    AppComponent,
    CoursesPageComponent,
    CourseCardComponent,
    CourseListComponent,
    CourseDetailModalComponent,
    LearningPathsPageComponent,
    LearningPathCardComponent,
    LearningPathListComponent,
    LearningPathDetailModalComponent,
    LessonPageComponent,
    LearningPathInputModalComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    SharedModule,
    BrowserAnimationsModule,
    PoModule,
    TranslateModule.forRoot({
      loader: { provide: TranslateLoader, useClass: AppTranslationLoader },
      defaultLanguage: "pt",
    }),
    PoContainerModule,
    PoWidgetModule,
    FormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
  exports: [CourseDetailModalComponent],
})
export class AppModule {}
