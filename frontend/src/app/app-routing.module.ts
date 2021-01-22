import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { CoursesPageComponent } from "./pages/courses-page/courses-page.component";
import { LearningPathsPageComponent } from "./pages/learning-paths-page/learning-paths-page.component";
import { LessonPageComponent } from './pages/lesson-page/lesson-page.component';

const routes: Routes = [
  { path: "courses", component: CoursesPageComponent },
  { path: "learning-paths", component: LearningPathsPageComponent },
  { path: 'lesson/:id', component: LessonPageComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
