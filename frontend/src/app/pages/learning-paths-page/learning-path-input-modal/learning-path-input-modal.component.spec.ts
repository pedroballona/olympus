import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LearningPathInputModalComponent } from './learning-path-input-modal.component';

describe('LearningPathInputModalComponent', () => {
  let component: LearningPathInputModalComponent;
  let fixture: ComponentFixture<LearningPathInputModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LearningPathInputModalComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LearningPathInputModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
