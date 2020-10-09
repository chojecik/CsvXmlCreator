import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { FormModel } from '../models/form-model';
import { ResponseModel } from '../models/response-model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TextService {
  response: string;
  url: string = "api/text";
  constructor(private http: HttpClient) { }

  postText(model: FormModel): Observable<ResponseModel> {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };

    return this.http.post<ResponseModel>(this.url + "/create", model, httpOptions).pipe();
  }

  downloadFile(model: FormModel): Observable<any> {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Accept': 'application/json'
    });

    return this.http.post<ResponseModel>(this.url + "/download", model, { headers: headers, responseType: 'blob' as 'json' }).pipe();
  }
}
