import { Injectable } from '@angular/core';

import {HttpClient} from '@angular/common/http'; 
import {Files} from 'src/app/models/files-model';
import {Observable} from 'rxjs';

import {Subject} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ReadinputService {

  constructor(private http:HttpClient) { }
  /*
  formData:ReadinputService;

  readonly APIUrl = "https://localhost:44356/api";

  addPath(file:Files){
    console.log(file);
    console.log(this.APIUrl + '/Department');

    return this.http.post(this.APIUrl+'/Department',file);
  }

  updateDepartment(dep:Files){
    return this.http.put(this.APIUrl+'/department/', dep);
  }
  */
}
