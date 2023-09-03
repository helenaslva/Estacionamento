import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MarcarSaidaDialogComponent } from './marcar-saida-dialog.component';

describe('MarcarSaidaDialogComponent', () => {
  let component: MarcarSaidaDialogComponent;
  let fixture: ComponentFixture<MarcarSaidaDialogComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MarcarSaidaDialogComponent],
    });
    fixture = TestBed.createComponent(MarcarSaidaDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
