
import { Injectable } from '@angular/core';
import { HttpClient, HttpEvent } from '@angular/common/http';
import { environment } from 'src/environments/environment';

import { Observable } from 'rxjs';
import { finalize } from 'rxjs/operators';
import { documentsDto } from '../Models/documentsDto';

@Injectable({
  providedIn: 'root'
})
export class ApiInvokerServiceService {

 public baseurl: string = "https://localhost:44331";
  public controller: any;
  public action: any;
  public model: any;


  constructor(private http: HttpClient) { }
  PostRequest(controller: string, action: string,model:any): Observable<any> {

    return this.http.post<any>(this.baseurl + '/' + controller + '/' + action, model)
  }

}
