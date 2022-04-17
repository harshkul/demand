import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HTTP_INTERCEPTORS, HttpClientModule } from "@angular/common/http";

import { TokenInterceptor } from "../app/core/interceptors/token.interceptor";
import { JwtService } from "../app/core/services/jwt.service";
import { AuthenticateService } from "../app/core/services/authenticate.service";

/*google social*/
import { environment } from '../environments/environment';
import { AdminModule } from './admin/admin.module';
/*end google login*/



@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    AdminModule
  ],
  providers: [
    JwtService,
    AuthenticateService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptor,
      multi: true
    },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
