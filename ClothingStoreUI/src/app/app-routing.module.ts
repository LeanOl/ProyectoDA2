import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginFormComponent } from './components/login-form/login-form.component';
import { ProductListComponent } from './components/product-list/product-list.component';

const routes: Routes = [
  {path: 'login',
   component: LoginFormComponent},
  {path: 'products',
   component : ProductListComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
