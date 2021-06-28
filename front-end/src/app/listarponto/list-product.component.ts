import { AfterViewInit, ChangeDetectorRef, Component, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTable } from '@angular/material/table';
import { Product } from '../models/Product';
import { ProductService } from '../product.service';
import { ProductDataSource } from './list-product-datasource';

@Component({
  selector: 'app-list-product',
  templateUrl: './list-product.component.html',
  styleUrls: ['./list-product.component.css']
})
export class ListProductComponent {
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  @ViewChild(MatTable) table!: MatTable<Product>;
  dataSource: ProductDataSource = new ProductDataSource([]);

  /** Columns displayed in the table. Columns IDs can be added, removed, or reordered. */
  displayedColumns = ['name', 'value', 'imageURL'];

  constructor(
    private service: ProductService,
    private changeDetectorRefs: ChangeDetectorRef
  ) { 
    this.loadData();
  }

  loadData(): void {
    var itens: Product[] = []
    this.service.getAllProducts().subscribe(x => {
      x.forEach(element => {
        let item: Product = {id:element.id ,name:element.name, imageURL: element.imageURL, value: element.value}
        itens.push(item);
      });
      console.log(itens);
      this.dataSource.data = [...itens];
      // this.refresh();
      console.log(this.dataSource);
      this.dataSource.sort;
    });
  }
  ngOnInit(): void {
    var itens: Product[] = []
    this.service.getAllProducts().subscribe(x => {
      x.forEach(element => {
        let item: Product = {id:element.id ,name:element.name, imageURL: element.imageURL, value: element.value}
        itens.push(item);
      });
      console.log(itens);
      this.dataSource = new ProductDataSource([...itens]);
      this.dataSource.sort = this.sort;
      this.dataSource.paginator = this.paginator;
      this.table.dataSource = this.dataSource;
    });
    
  }
}
