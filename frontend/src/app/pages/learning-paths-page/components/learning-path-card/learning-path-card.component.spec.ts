import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LearningPathCardComponent } from './learning-path-card.component';

describe('LearningPathCardComponent', () => {
  let component: LearningPathCardComponent;
  let fixture: ComponentFixture<LearningPathCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LearningPathCardComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LearningPathCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
