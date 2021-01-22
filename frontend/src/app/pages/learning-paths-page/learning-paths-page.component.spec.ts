import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LearningPathsPageComponent } from './learning-paths-page.component';

describe('LearningPathsPageComponent', () => {
  let component: LearningPathsPageComponent;
  let fixture: ComponentFixture<LearningPathsPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LearningPathsPageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LearningPathsPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
