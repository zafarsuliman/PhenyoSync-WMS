import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StocktakerDashboard } from './stocktaker-dashboard';

describe('StocktakerDashboard', () => {
  let component: StocktakerDashboard;
  let fixture: ComponentFixture<StocktakerDashboard>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [StocktakerDashboard]
    })
    .compileComponents();

    fixture = TestBed.createComponent(StocktakerDashboard);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
