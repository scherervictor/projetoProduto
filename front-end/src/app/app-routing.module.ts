import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListProductComponent } from './listarponto/list-product.component';
import { InsertProductComponent } from './registrar-ponto/insert-product.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

const routes: Routes = [
  { path: 'listProducts', component: ListProductComponent },
  { path: 'insertProduct', component: InsertProductComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes),
            FormsModule,
            ReactiveFormsModule],
  exports: [RouterModule]
})
export class AppRoutingModule { }
