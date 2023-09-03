import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MarcarEntradaDialogComponent } from './marcar-entrada-dialog.component';

describe('MarcarEntradaDialogComponent', () => {
  let component: MarcarEntradaDialogComponent;
  let fixture: ComponentFixture<MarcarEntradaDialogComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MarcarEntradaDialogComponent],
    });
    fixture = TestBed.createComponent(MarcarEntradaDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
