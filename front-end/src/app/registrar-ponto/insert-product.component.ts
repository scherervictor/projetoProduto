import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, ReactiveFormsModule } from '@angular/forms'
import { Product, ProductInsert } from '../models/Product';
import { ProductService } from '../product.service';

@Component({
  selector: 'app-insert-product',
  templateUrl: './insert-product.component.html',
  styleUrls: ['./insert-product.component.css']
})
export class InsertProductComponent implements OnInit {
  
  productForm = new FormGroup({
    id: new FormControl(''),
    name: new FormControl(''),
    value: new FormControl(''),
    imageURL: new FormControl(''),
  });

  constructor(
    private productService: ProductService
  ) { }

  onSubmit(): void {
    const product:ProductInsert = {
      name: this.productForm.value.name,
      value: this.productForm.value.value,
      imageURL: this.productForm.value.imageURL,
    };
    
    this.productService.insertProduct(product).subscribe();
  }

  ngOnInit(): void {
  }
}
