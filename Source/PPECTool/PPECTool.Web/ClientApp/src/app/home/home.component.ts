import { Component, OnInit } from '@angular/core';
import { SampleserviceService } from '../services/sampleservice.service';
import { SampleModel } from '../model/SampleModel';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  public mydata=[];
  SampleDataModel: SampleModel=new SampleModel();
  constructor(private _sampleData:SampleserviceService){}
  ngOnInit(){
    this.getMyData();
  }

  async getMyData() {
     this._sampleData.getSampleData()
             .subscribe(data=>this.mydata=data);
             
    //this._sampleData.getSampleData().subscribe((data: {}) => {
      //console.log(data);
      //this.mydata = data;
    //});
  }
  SaveInfo(){
   this._sampleData.saveSampleInfo(this.SampleDataModel);
   this.getMyData();
  }

}
