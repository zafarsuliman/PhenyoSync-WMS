import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WarehouseManagerHomeComponent } from './warehouse-manager-home';

describe('WarehouseManagerHome', () => {
  let component: WarehouseManagerHomeComponent;
  let fixture: ComponentFixture<WarehouseManagerHomeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [WarehouseManagerHomeComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(WarehouseManagerHomeComponent);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
