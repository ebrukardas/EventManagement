import { Injectable } from '@angular/core';

import {HttpClient} from '@angular/common/http'; 
import {Files} from 'src/app/models/files-model';


@Injectable({
  providedIn: 'root'
})
export class ReadinputService {

  constructor(private http:HttpClient) { }
  
  formData:ReadinputService;

  readonly APIUrl = "https://localhost:44356/api";

  addPath(file:Files){
    //console.log(file);
    return this.http.post(this.APIUrl+'/input',file);
  }

  updatePath(dep:Files){
    return this.http.put(this.APIUrl+'/input/', dep);
  }

  deletePath(id:number){
    return this.http.delete(this.APIUrl+'/input/' + id);
  }
  
}
