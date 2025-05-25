import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../environment/environment';

@Injectable({
  providedIn: 'root'
})
export class PrecoService{

 constructor(protected http: HttpClient) {
     this.http = http;
   }

public adicionarPreco(entity: precoInput): Observable<Output>{
  return this.http.post<Output>(
        `${environment.urlBackend}/preco`,
        entity
      );
}

 public listar(): Observable<precoOutput[]> {
    return this.http.get<precoOutput[]>(
      `${environment.urlBackend}/preco`
    );
  }
}
export interface precoOutput {
  valor: number;
  dataValidadeInicial: string;
  dataValidadeFinal: string;
}

export interface precoInput {
  valor: number;
  dataValidadeInicial: string;
  dataValidadeFinal: string;
}

export interface Output {
  isSuccess: boolean;
  message: string;
}
