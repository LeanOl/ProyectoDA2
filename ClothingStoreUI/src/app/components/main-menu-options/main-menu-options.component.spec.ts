import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MainMenuOptionsComponent } from './main-menu-options.component';

describe('MainMenuOptionsComponent', () => {
  let component: MainMenuOptionsComponent;
  let fixture: ComponentFixture<MainMenuOptionsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MainMenuOptionsComponent]
    });
    fixture = TestBed.createComponent(MainMenuOptionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
