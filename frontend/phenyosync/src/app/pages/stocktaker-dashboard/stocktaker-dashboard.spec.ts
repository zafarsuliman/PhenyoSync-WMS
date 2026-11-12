import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StocktakerDashboardComponent } from './stocktaker-dashboard';

describe('StocktakerDashboard', () => {
  let component: StocktakerDashboardComponent;
  let fixture: ComponentFixture<StocktakerDashboardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [StocktakerDashboardComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(StocktakerDashboardComponent);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
