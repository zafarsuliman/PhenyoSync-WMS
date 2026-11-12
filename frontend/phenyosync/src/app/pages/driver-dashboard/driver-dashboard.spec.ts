import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DriverDashboardComponent } from './driver-dashboard';

describe('DriverDashboard', () => {
  let component: DriverDashboardComponent;
  let fixture: ComponentFixture<DriverDashboardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DriverDashboardComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DriverDashboardComponent);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
