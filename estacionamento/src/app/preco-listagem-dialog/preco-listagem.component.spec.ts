import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrecoListagemComponent } from './preco-listagem.component';

describe('PrecoListagemComponent', () => {
  let component: PrecoListagemComponent;
  let fixture: ComponentFixture<PrecoListagemComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PrecoListagemComponent]
    });
    fixture = TestBed.createComponent(PrecoListagemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
