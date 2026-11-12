import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PackerDashboardComponent } from './packer-dashboard';

describe('PackerDashboard', () => {
  let component: PackerDashboardComponent;
  let fixture: ComponentFixture<PackerDashboardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PackerDashboardComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PackerDashboardComponent);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
