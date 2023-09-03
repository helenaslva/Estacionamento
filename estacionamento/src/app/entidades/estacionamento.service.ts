
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../environment/environment';
import { Time } from '@angular/common';

@Injectable({
  providedIn: 'root',
})
export class EstacionamentoService {
  constructor(protected http: HttpClient) {
    this.http = http;
  }

  public listar(): Observable<EstacionamentoLista[]> {
    return this.http.get<EstacionamentoLista[]>(
      `${environment.urlBackend}/estacionamento`
    );
  }

  public atualizar(placa: string, dataSaida: Date): Observable<Output> {
    return this.http.put<Output>(
      `${environment.urlBackend}/estacionamento/${placa}`,
      dataSaida
    );
  }

  public salvar(entity: EstacionamentoInput): Observable<Output> {
    return this.http.post<Output>(
      `${environment.urlBackend}/estacionamento`,
      entity
    );
  }
}

export interface EstacionamentoLista {
  id: number;
  placa: string;
  dataEntrada: Date;
  dataSaida: Date;
  duracao: Time;
  tempoCobrado: number;
  preco: number;
  valorTotal: number;
}

export interface EstacionamentoInput {
  placa: string;
  dataEntrada: Date;
}
export interface EstacionamentoAtualizar {
  placa: string
  dataSaida: Date;
}
export interface Output {
  isSuccess: boolean;
  message: string;
}
