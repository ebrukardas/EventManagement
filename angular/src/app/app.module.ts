import { BrowserModule }          from '@angular/platform-browser';
import { NgModule }               from '@angular/core';
import { NgxSpinnerModule }       from "ngx-spinner";  

import {MatRadioModule}           from '@angular/material/radio'; 
import {BrowserAnimationsModule}  from '@angular/platform-browser/animations'

// connect db
import { AppRoutingModule }       from './app-routing.module';
import { AppComponent }           from './app.component';
import { HttpClientModule }       from '@angular/common/http'; 

// to show function
import { MatTableModule }         from '@angular/material/table';
import { MatIconModule }          from '@angular/material/icon';
import { MatButtonModule }        from '@angular/material/button';

// to add function
import { MatDialogModule }        from '@angular/material/dialog';
import { FormsModule }            from '@angular/forms';

// add added notification
import { MatSnackBarModule }      from '@angular/material/snack-bar';
import { MatInputModule }         from '@angular/material/input';

// components
import { ReadPathComponent }      from './entry/read-path/read-path.component';
import { ShowFilesComponent }     from './entry/show-files/show-files.component';

// services
import { ReadinputService }       from 'src/app/services/readinput.service';
import { ShowresultService }      from 'src/app/services/showresult.service';

@NgModule({
  declarations: [
    AppComponent,
    ReadPathComponent,
    ShowFilesComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MatRadioModule,
    MatInputModule,
    MatTableModule,
    MatIconModule,
    MatButtonModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatDialogModule,
    FormsModule,
    MatSnackBarModule,
    NgxSpinnerModule
  ],
  providers: [ReadinputService, ShowresultService],
  bootstrap: [AppComponent]
})
export class AppModule { }
