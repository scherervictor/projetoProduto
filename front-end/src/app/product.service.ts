import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { catchError, map, tap } from 'rxjs/operators';
import { Product, ProductInsert } from './models/Product';
import { Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private getAllUrl = 'api/product/list';
  private insertUrl = 'api/product/insert';
  httpOptions = {
    headers: new HttpHeaders({ 'Accept': ['application/json', 'text/plain', '*/*'], 'Content-Type': 'application/json' })
  };

  insertProduct(product: ProductInsert): Observable<ProductInsert> {
    return this.http.post<ProductInsert>(this.insertUrl, product)
      .pipe(
        catchError(this.handleError)
      );
  };

  getAllProducts() : Observable<Product[]> {
    return this.http.get<Product[]>(this.getAllUrl).pipe(map((result:any)=>result.data));
  };

  private handleError(error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {
      console.error('Erro ocorreu:', error.error.message);
    } else {
      console.error(
        `Backend retornou code ${error.status}, ` +
        `body foi: ${error.error}`);
    }
    return throwError(
      'Algo de errado aconteceu.');
  }
  
  constructor(
    private http: HttpClient
  ) { }

}
