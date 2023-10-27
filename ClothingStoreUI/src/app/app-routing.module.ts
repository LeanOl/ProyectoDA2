import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginFormComponent } from './components/login-form/login-form.component';
import { ProductListComponent } from './components/product/product-list/product-list.component';
import { ProductDetailComponent } from './components/product/product-detail/product-detail.component';
import { MainMenuComponent } from './components/menu/main-menu/main-menu.component';
import { UserListComponent } from './components/user/user-list/user-list.component';

const routes: Routes = [
  {path: 'login',
   component: LoginFormComponent},
  {path: 'products',
   component : ProductListComponent},
  {path: 'viewproduct',
  component: ProductDetailComponent},
  {path: 'users',
  component: UserListComponent},
  {path: '',
   component: MainMenuComponent},
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
