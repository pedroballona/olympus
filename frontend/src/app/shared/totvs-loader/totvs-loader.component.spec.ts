import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { TotvsLoaderComponent } from './totvs-loader.component';


describe('TotvsLoaderComponent', () => {
  let component: TotvsLoaderComponent;
  let fixture: ComponentFixture<TotvsLoaderComponent>;

  beforeEach(waitForAsync(() => {
    void TestBed.configureTestingModule({
      declarations: [ TotvsLoaderComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TotvsLoaderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    void expect(component).toBeTruthy();
  });
});
