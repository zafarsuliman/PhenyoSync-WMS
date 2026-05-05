import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PackerDashboard } from './packer-dashboard';

describe('PackerDashboard', () => {
  let component: PackerDashboard;
  let fixture: ComponentFixture<PackerDashboard>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PackerDashboard]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PackerDashboard);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
