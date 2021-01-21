import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { Course, SimpleCourse } from '../../models/course.model';
import { TotvsPage } from '../../models/totvspage.model';

@Injectable({
  providedIn: 'root',
})
export class CoursesService {
  constructor(private http: HttpClient) {}

  getAllCourses(page: number): Observable<TotvsPage<SimpleCourse>> {
    return this.http.get<TotvsPage<SimpleCourse>>(
      environment.backendUrl + 'courses',
      {
        params: {
          page: page + '',
        },
      }
    );
  }

  getCourse(id: string): Observable<Course> {
    return this.http.get<Course>(`${environment.backendUrl}courses/${id}`);
  }
}
