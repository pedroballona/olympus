import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { LearningPath } from "src/app/models/learning-path.model";
import { environment } from "../../../environments/environment";
import { TotvsPage } from "../../models/totvspage.model";

@Injectable({
  providedIn: "root",
})
export class LearningPathsService {
  constructor(private http: HttpClient) {}

  getAllLearningPaths(
    page: number,
    filter = ""
  ): Observable<TotvsPage<LearningPath>> {
    return this.http.get<TotvsPage<LearningPath>>(
      environment.backendUrl + "learning-path",
      {
        params: {
          page: page + "",
          filter,
        },
      }
    );
  }

  getLearningPath(id: string): Observable<LearningPath> {
    return this.http.get<LearningPath>(
      `${environment.backendUrl}learning-path/${id}`
    );
  }

  inputLearningPath(learningPath: LearningPath) {
    const learningPathToSend = {
      ...learningPath,
      employeeRoles: learningPath.employeeRoles.map((x) => +x),
    };

    return this.http.post(
      `${environment.backendUrl}learning-path`,
      learningPathToSend
    );
  }
}
