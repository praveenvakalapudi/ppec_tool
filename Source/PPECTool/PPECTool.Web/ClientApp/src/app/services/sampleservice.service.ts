import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { Observable } from 'rxjs';
import { ISample } from '../model/SampleModel';


@Injectable()
export class SampleserviceService {

  constructor(private http:HttpClient) { }    
  getSampleData(): Observable<ISample[]>{
     ///let obs=this.http.get("https://localhost:44399/api/sample/1");
    //obs.subscribe((response) => console.log(response));
    // return obs;
    return this.http.get<ISample[]>("https://localhost:44399/api/sample/1");
    //return [{"Id":1, "Name":"Sample1","Email":"Sample@sample.com","Mobile":"12344556"}];
  }
}
