import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CourseDetailModalComponent } from './course-detail-modal.component';

describe('CourseDetailModalComponent', () => {
  let component: CourseDetailModalComponent;
  let fixture: ComponentFixture<CourseDetailModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CourseDetailModalComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CourseDetailModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
