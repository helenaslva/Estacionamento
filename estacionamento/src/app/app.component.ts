import { Component } from '@angular/core';

import {
  EstacionamentoLista,
  EstacionamentoService,
  EstacionamentoInput,
  Output,
  EstacionamentoAtualizar,
} from './entidades/estacionamento.service';
import { MatDialog } from '@angular/material/dialog';
import { MarcarEntradaDialogComponent } from './marcar-entrada-dialog/marcar-entrada-dialog.component';
import { FormGroup } from '@angular/forms';
import { MarcarSaidaDialogComponent } from './marcar-saida-dialog/marcar-saida-dialog.component';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  displayedColumns: string[] = [
    'placa',
    'dataEntrada',
    'dataSaida',
    'duracao',
    'tempoCobrado',
    'valorTotal',
    'preco',
  ];
  estacionamento: EstacionamentoLista[] = [];
  output: Output[] = [];
  public atualizarSaida = [];

  constructor(
    private estaciomentoService: EstacionamentoService,
    public dialog: MatDialog,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.listarEstacionamentos();
  }

  private listarEstacionamentos() {
    this.estaciomentoService.listar().subscribe((e) => {
      this.estacionamento = e;
    });
  }

  openDialogEntrada(): void {
    const dialogRef = this.dialog.open(MarcarEntradaDialogComponent, {});

    dialogRef.afterClosed().subscribe((result) => {
      const estacionamentoInput: EstacionamentoInput = result;
      this.estaciomentoService.salvar(estacionamentoInput).subscribe((e) => {
        this.output;
        this.listarEstacionamentos();
        this.toastr.success('Entrada efetuada com sucesso');
      });
    });
  }

  openDialogSaida() {
    const dialogRef = this.dialog.open(MarcarSaidaDialogComponent, {});
    dialogRef.afterClosed().subscribe((result) => {
    if(result !== undefined){
      this.estaciomentoService
      .atualizar(result.placa, result.dataSaida)
      .subscribe((e) => {
        this.listarEstacionamentos();
        this.toastr.success('Saída efetuada com sucesso');
      },
      (err) => {
        this.toastr.error("Não foi possivel efetuar saída. Placa não encontrada")
      });
    }

    });
  }
}
