import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MainMenuOptionsComponent } from './components/main-menu-options/main-menu-options.component';
import { LoginFormComponent } from './components/login-form/login-form.component';
import { ProductItemComponent } from './components/product/product-item/product-item.component';
import { ProductListComponent } from './components/product/product-list/product-list.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { ProductDetailComponent } from './components/product/product-detail/product-detail.component';
import { AdminMenuComponent } from './components/menu/admin-menu/admin-menu.component';
import { MainMenuComponent } from './components/menu/main-menu/main-menu.component';
import { NotLoggedMenuComponent } from './components/menu/not-logged-menu/not-logged-menu.component';
import { UserMenuComponent } from './components/menu/user-menu/user-menu.component';
import { UserItemComponent } from './components/user/user-item/user-item.component';
import { UserListComponent } from './components/user/user-list/user-list.component';

@NgModule({
  declarations: [
    AppComponent,
    MainMenuOptionsComponent,
    LoginFormComponent,
    ProductItemComponent,
    ProductListComponent,
    ProductDetailComponent,
    AdminMenuComponent,
    MainMenuComponent,
    NotLoggedMenuComponent,
    UserMenuComponent,
    UserItemComponent,
    UserListComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
