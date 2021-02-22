import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'; 
import { Observable } from 'rxjs';
import { Files }      from 'src/app/models/files-model'
import { Subject }    from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ShowresultService {

  constructor(private http:HttpClient) { }

  formData:ShowresultService;

  readonly APIUrl = "https://localhost:44356/api";

  // getting outputs
  getDepList():Observable<Files[]>{
    return this.http.get<Files[]>(this.APIUrl + '/showfiles');
  }

  private _listners = new Subject<any>();
  listen():Observable<any>{
    return this._listners.asObservable();
  }
}
