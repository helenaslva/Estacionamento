
import { Component } from '@angular/core';
import { DialogData } from './../marcar-entrada-dialog/marcar-entrada-dialog.component';
import { Inject } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import {
  precoOutput,
  PrecoService,
  Output
} from '../entidades/preco.service';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-preco-listagem',
  templateUrl: './preco-listagem.component.html',
  styleUrls: ['./preco-listagem.component.css']
})
export class PrecoListagemComponent {
  dataSource = new MatTableDataSource<precoOutput>();
  displayedColumns: string[] = [
    'valor',
    'dataInicial',
    'dataFinal',
  ];

   precos: precoOutput[] = [];
   output: Output[] = [];

 constructor(
     private fb: FormBuilder,
     private precoService: PrecoService,
     public dialogRef: MatDialogRef<PrecoListagemComponent>,
     @Inject(MAT_DIALOG_DATA) public data: DialogData
   ) {}

   ngOnInit(): void {
    console.log("Aqui vai")
    this.listarPrecos();

  }

  listarPrecos() {
    this.precoService.listar().subscribe({
      next: (dados) => {
        console.log('Dados recebidos do backend:', dados); // <- VERIFICAR AQUI
        this.dataSource.data = dados;
      },
      error: (erro) => {
        console.error('Erro ao buscar preços:', erro);
      }
    });
  }

  voltar(){
    this.dialogRef.close();
  }
}
