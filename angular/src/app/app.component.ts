import { Component }                  from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { ReadPathComponent }          from 'src/app/entry/read-path/read-path.component';
import { ShowFilesComponent }         from 'src/app/entry/show-files/show-files.component';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'angular';

  constructor(private dialog:MatDialog){ }

  // upload the file for beginning
  uploadFile(){
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = "150%";
    this.dialog.open(ReadPathComponent,dialogConfig);
  }

  // show result screen after analysis
  showResultScreen(){
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = "150%";

    this.dialog.open(ShowFilesComponent,dialogConfig);

  }

}
