import { Component, OnInit }  from '@angular/core';
import { MatDialogRef }       from '@angular/material/dialog';
import { ReadinputService }   from 'src/app/services/readinput.service';
import { MatSnackBar }        from '@angular/material/snack-bar';

export class Type{
  name:string;
  value:string;
}

// input data for path and type
export class Input{
  path:string;
  type:string;
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
  radioSel:any;
  type:string;
  itemsList: Type[] = TYPE;

  constructor(public dialogbox:MatDialogRef<ReadPathComponent>
    , public service:ReadinputService
    , public snackBar:MatSnackBar

    ) { 
      this.itemsList = TYPE;
      this.type = "Mixed";
      this.getSelecteditem();
    }

  getSelecteditem(){
    this.radioSel = TYPE.find(Item => Item.value === this.type);
  }
  
  onItemChange(item){
    this.getSelecteditem();
  }

  onKey(event){
    this.path = event.target.value;
  }

  ngOnInit(): void {
  }


  onSubmit(event:any){

    //console.log("Path: ", event.target.path.value);
    //console.log("Button: ", this.radioSel.value);
    let inp: Input = new Input();

    inp.path = event.target.path.value;
    inp.type = this.radioSel.value;

    this.service.addPath(inp).subscribe(res=>
      {
        this.snackBar.open(res.toString(),'',{
          duration:5000,
          verticalPosition:'top'
        });
        alert(res);
      });

    this.onClose();
  }

  
  onClose(){
    this.dialogbox.close();
  }

}
