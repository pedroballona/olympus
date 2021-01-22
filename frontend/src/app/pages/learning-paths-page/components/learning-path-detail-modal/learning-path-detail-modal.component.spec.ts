import { ComponentFixture, TestBed } from "@angular/core/testing";

import { LearningPathDetailModalComponent } from "./learning-path-detail-modal.component";

describe("LearningPathDetailModalComponent", () => {
  let component: LearningPathDetailModalComponent;
  let fixture: ComponentFixture<LearningPathDetailModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [LearningPathDetailModalComponent],
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LearningPathDetailModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
