import { Pipe, PipeTransform } from "@angular/core";
import { CourseImageService } from "../pages/courses-page/components/course-card/course-image.service";

@Pipe({
  name: "courseImage",
})
export class CourseImagePipe implements PipeTransform {
  constructor(private service: CourseImageService) {}

  transform(name: string): string {
    return this.service.getImageUrlByName(name);
  }
}
