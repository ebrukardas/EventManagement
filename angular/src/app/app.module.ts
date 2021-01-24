import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';


import {MixedeventService} from 'src/app/services/mixedevent.service';
import {SyntheticeventService} from 'src/app/services/syntheticevent.service';
import {ReadinputService} from 'src/app/services/readinput.service';


import {MatRadioModule} from '@angular/material/radio'; 


import {BrowserAnimationsModule} from '@angular/platform-browser/animations'
// connect db
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {HttpClientModule} from '@angular/common/http'; 

// to show function
import { MatTableModule } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
// to add function

import {MatDialogModule} from '@angular/material/dialog';
import {FormsModule} from '@angular/forms';
// add added notification
import {MatSnackBarModule} from '@angular/material/snack-bar';

import {MatInputModule} from '@angular/material/input';
/*
import{SyntheticService} from 'src/app/services/synthetic.service';
import{MixedService} from 'src/app/services/mixed.service';
*/
import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatNativeDateModule} from '@angular/material/core';
import { EntryComponent } from './entry/entry.component';
import { ReadPathComponent } from './entry/read-path/read-path.component';
import { ShowFilesComponent } from './entry/show-files/show-files.component';
import { AnalysisComponent } from './analysis/analysis.component';
/*
import { EntryComponent } from './entry/entry.component';
import { ReadPathComponent } from './entry/read-path/read-path.component';
import { ShowFilesComponent } from './entry/show-files/show-files.component';
import { AnalysisComponent } from './analysis/analysis.component';

*/
/*
import { UploadComponent } from './upload/upload.component';
import { ShowEventsComponent } from './upload/show-events/show-events.component';
import { UploadFileComponent } from './upload/upload-file/upload-file.component';
import { AnalyseComponent } from './analyse/analyse.component';
import { ShowAnalyseComponent } from './analyse/show-analyse/show-analyse.component';
*/


@NgModule({
  declarations: [
    AppComponent,
    EntryComponent,
    ReadPathComponent,
    ShowFilesComponent,
    AnalysisComponent,
    /*
    EntryComponent,
    ReadPathComponent,
    ShowFilesComponent,
    AnalysisComponent
    */
    /*,
    UploadComponent,
    ShowEventsComponent,
    UploadFileComponent,
    AnalyseComponent,
    ShowAnalyseComponent
    */
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
    MatDatepickerModule,
    MatNativeDateModule
  ],
  providers: [MixedeventService, SyntheticeventService, ReadinputService],
  //providers: [SyntheticService, MixedService],
  bootstrap: [AppComponent]/*,
  entryComponents:[AddDepComponent,EditDepComponent,AddEmpComponent,EditEmpComponent]
  */
})
export class AppModule { }
