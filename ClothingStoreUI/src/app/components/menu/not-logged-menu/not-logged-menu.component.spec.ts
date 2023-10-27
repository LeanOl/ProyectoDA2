import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NotLoggedMenuComponent } from './not-logged-menu.component';

describe('NotLoggedMenuComponent', () => {
  let component: NotLoggedMenuComponent;
  let fixture: ComponentFixture<NotLoggedMenuComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [NotLoggedMenuComponent]
    });
    fixture = TestBed.createComponent(NotLoggedMenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
