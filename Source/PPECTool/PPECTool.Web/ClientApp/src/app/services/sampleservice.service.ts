import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import { Observable } from 'rxjs';
import { SampleModel } from '../model/SampleModel';


@Injectable()
export class SampleserviceService {

  constructor(private http:HttpClient) { }    
  getSampleData(): Observable<SampleModel[]>{
    const headers = new HttpHeaders().set("Access-Control-Allow-Origin", "*");
     ///let obs=this.http.get("https://localhost:44399/api/sample/1");
    //obs.subscribe((response) => console.log(response));
    // return obs;
    return this.http.get<SampleModel[]>("https://localhost:44399/api/sample/1");
    //return [{"Id":1, "Name":"Sample1","Email":"Sample@sample.com","Mobile":"12344556"}];
  }

  saveSampleInfo(sample: SampleModel){
    try{
      if(sample.Id==0){
        //INSERT
        debugger;
        // this.http.post('https://localhost:44399/api/sample/',sample,{
        //   headers:new HttpHeaders({
        //     'Content-Type':'appplication/json'
        //   })
        // })
        this.http.post("https://localhost:44399/api/sample/",sample)
          .subscribe(
              data => {
                  console.log("POST Request is successful ", data);
              },
              error => {
                  console.log("Error", error);
              }
          );   
              
      }
      else{
        //UPDATE
        this.http.post("https://localhost:44399/api/sample/",sample)
        .subscribe(
            data => {
                console.log("POST Request is successful ", data);
            },
            error => {
                console.log("Error", error);
            }
        );       
      }
    }
    catch(ex){

    }
    
  }
}
