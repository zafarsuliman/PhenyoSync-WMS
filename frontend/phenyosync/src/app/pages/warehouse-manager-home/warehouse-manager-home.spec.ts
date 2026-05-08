import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WarehouseManagerHome } from './warehouse-manager-home';

describe('WarehouseManagerHome', () => {
  let component: WarehouseManagerHome;
  let fixture: ComponentFixture<WarehouseManagerHome>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [WarehouseManagerHome]
    })
    .compileComponents();

    fixture = TestBed.createComponent(WarehouseManagerHome);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
