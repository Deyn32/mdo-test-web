import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { Router, RouterModule, Routes} from '@angular/router';

import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';

import { CalendarModule } from 'primeng/calendar';
import { CheckboxModule } from 'primeng/checkbox';
import { InputTextModule } from 'primeng/inputtext';
import { InputMaskModule } from 'primeng/inputmask';
import { InputTextareaModule } from 'primeng/inputtextarea';
import { TagModule } from 'primeng/tag';
import { ButtonModule } from 'primeng/button';
import { PasswordModule } from 'primeng/password';
import { DataViewModule } from 'primeng/dataview';
import { StyleClassModule } from 'primeng/styleclass';
import { MessagesModule } from 'primeng/messages';
import { MenuModule } from 'primeng/menu';
import { ToastModule } from 'primeng/toast';
import { TabMenuModule } from 'primeng/tabmenu';
import { TableModule } from 'primeng/table';
import { SplitterModule } from 'primeng/splitter';
import { ToolbarModule } from 'primeng/toolbar';
import { DropdownModule } from 'primeng/dropdown';
import { DialogModule } from 'primeng/dialog';
import { CardModule } from 'primeng/card';
import { FieldsetModule } from 'primeng/fieldset';

import { AuthInterceptor } from '../intercepts/auth-interceptor';

const routes: Routes = [
  { path: '', component: LoginComponent, pathMatch: 'full'}
]

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    BrowserAnimationsModule,
    DropdownModule,
    HttpClientModule,
    CalendarModule,
    CheckboxModule,
    CardModule,
    FieldsetModule,
    InputTextModule,
    InputMaskModule,
    InputTextareaModule,
    DialogModule,
    TagModule,
    ButtonModule,
    PasswordModule,
    DataViewModule,
    StyleClassModule,
    MessagesModule,
    TabMenuModule,
    TableModule,
    SplitterModule,
    ToolbarModule,
    MenuModule,
    ToastModule,
    FormsModule,
    RouterModule.forRoot(routes)
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useFactory: function (router: Router) {
        return new AuthInterceptor(router);
      },
      multi: true,
      deps: [Router]
    }],
  bootstrap: [AppComponent]
})
export class AppModule {

  constructor(private router: Router) { }
}
