import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { MatDialogRef} from '@angular/material/dialog';
import { MatRadioChange } from '@angular/material/radio';


// MatDialogActions
export class Type{
  name:string;
  value:string;
}
export const TYPE: Type[]=[
  {
    name:'Mixed',
    value:'Mixed'
  },
  {
    name:'Synthetic',
    value:'Synthetic'
  }
] ;

@Component({
  selector: 'app-read-path',
  templateUrl: './read-path.component.html',
  styleUrls: ['./read-path.component.css']
})
export class ReadPathComponent implements OnInit {

  path:string;
  files:string[];

  radioSel:any;
  type:string;
  radioSelectedString:string;
  itemsList: Type[] = TYPE;

  constructor(public dialogbox:MatDialogRef<ReadPathComponent>//, public service:EventService
    ) { 
      this.itemsList = TYPE;
      this.type = "Mixed";
      this.getSelecteditem();
    }

  getSelecteditem(){
    this.radioSel = TYPE.find(Item => Item.value === this.type);
    this.radioSelectedString = JSON.stringify(this.radioSel);
    //console.log("Radio button answer is: ", this.radioSelectedString, "\n\n");
  }
  onItemChange(item){
    this.getSelecteditem();
  }

  onKey(event){
    this.path = event.target.value;
  }

  ngOnInit(): void {
  }

  onClose(){
    this.dialogbox.close();
    //this.service.filter('Register click');
  }

  onSubmit(event:any){

    console.log("Path: ", event.target.path.value);
    console.log("Button: ", this.radioSelectedString);
    //console.log("Button: ", this.radioSel);
    console.log("\n\n");
    /**/
      
  }

}
