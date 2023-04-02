import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NameDiagramComponent } from './name-diagram.component';

describe('NameDiagramComponent', () => {
  let component: NameDiagramComponent;
  let fixture: ComponentFixture<NameDiagramComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NameDiagramComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NameDiagramComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
