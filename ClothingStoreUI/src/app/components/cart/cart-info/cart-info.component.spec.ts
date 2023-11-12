import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CartInfoComponent } from './cart-info.component';

describe('CartInfoComponent', () => {
  let component: CartInfoComponent;
  let fixture: ComponentFixture<CartInfoComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CartInfoComponent]
    });
    fixture = TestBed.createComponent(CartInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
