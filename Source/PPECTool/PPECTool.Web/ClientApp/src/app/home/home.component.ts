import { Component, OnInit } from '@angular/core';
import { SampleserviceService } from '../services/sampleservice.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  public mydata=[];
  constructor(private _sampleData:SampleserviceService){}
  ngOnInit(){
    this.getMyData();
  }

  getMyData() {
     this._sampleData.getSampleData()
             .subscribe(data=>this.mydata=data);
             
    //this._sampleData.getSampleData().subscribe((data: {}) => {
      //console.log(data);
      //this.mydata = data;
    //});
  }

}
