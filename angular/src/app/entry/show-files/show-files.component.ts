import { Component, OnInit } from '@angular/core';
import {MatTableDataSource} from '@angular/material/table';


@Component({
  selector: 'app-show-files',
  templateUrl: './show-files.component.html',
  styleUrls: ['./show-files.component.css']
})
export class ShowFilesComponent implements OnInit {

  //listData : MatTableDataSource<any>;
  //displayedColumns : string[] = ['Options', 'filename']
  
  files:string[];

  constructor() { }

  ngOnInit(): void {
  }

}
