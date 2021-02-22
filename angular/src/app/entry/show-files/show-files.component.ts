import { Component, OnInit }  from '@angular/core';
import { MatDialogRef}        from '@angular/material/dialog';
import { NgxSpinnerService }  from "ngx-spinner";  
import { ShowresultService }  from 'src/app/services/showresult.service';
import * as CanvasJS          from 'src/app/canvasjs.min';

@Component({
  selector: 'app-show-files',
  templateUrl: './show-files.component.html',
  styleUrls: ['./show-files.component.css']
})
export class ShowFilesComponent implements OnInit {



  constructor(public dialogbox:MatDialogRef<ShowFilesComponent>
    , public service:ShowresultService
    , private SpinnerService: NgxSpinnerService
    ) { 
      this.service.listen().subscribe((m:any)=>{
        console.log(m);
        this.ngOnInit();
      })
    }
  
  ngOnInit(): void {

    this.SpinnerService.show();

    this.service.getDepList().subscribe(data => {
      /*
      console.log(data[0]);
      console.log(data[1]);
      console.log(data[2]);
      console.log(data[3]);
      console.log(data[4]);
      console.log(data[5]);
      */
     // draw graphic for the output that getting from database of the analysis 
      let chart = new CanvasJS.Chart("chartContainer", {
        animationEnabled: true,
        exportEnabled: true,
        title: {
          text: "RESULTS"
        },
        data: [{
          type: "column",
          dataPoints: [
            { y: data[0], label: "Kural 1" },
            { y: data[1], label: "Kural 2" },
            { y: data[2], label: "Kural 3" },
            { y: data[3], label: "Kural 4" },
            { y: data[4], label: "Kural 5" },
            { y: data[5], label: "Kural 6" }
          ]
        }]
      });
      this.SpinnerService.hide();
      chart.render();

    });
      
  }

  onClose(){
    this.dialogbox.close();
  }

}
