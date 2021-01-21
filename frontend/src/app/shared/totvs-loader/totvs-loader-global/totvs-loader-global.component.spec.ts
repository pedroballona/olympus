import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { TotvsLoaderGlobalComponent } from './totvs-loader-global.component';


describe('TotvsLoaderGlobalComponent', () => {
  let component: TotvsLoaderGlobalComponent;
  let fixture: ComponentFixture<TotvsLoaderGlobalComponent>;

  beforeEach(waitForAsync(() => {
    void TestBed.configureTestingModule({
      declarations: [ TotvsLoaderGlobalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TotvsLoaderGlobalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    void expect(component).toBeTruthy();
  });
});
