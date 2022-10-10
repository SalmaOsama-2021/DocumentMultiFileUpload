import { Injectable } from "@angular/core";
import { Observable } from "rxjs/internal/Observable";
import { ApiInvokerServiceService } from "./api-invoker-service.service";
@Injectable({
    providedIn: 'root'
  })
export class DocumentUploadFileService {

    constructor(private ApiService: ApiInvokerServiceService) { }
    GetDocumentFile(model: any): Observable<any> {
        return this.ApiService.PostRequest("DocumentFileUpload", "getAllDocument",model)
      }
      getAllPriority(model: any): Observable<any> {
    
        return this.ApiService.PostRequest("DocumentFileUpload", "getAllPriority", model)
      }
      getByDocumentId(model: any): Observable<any> {
        return this.ApiService.PostRequest("DocumentFileUpload", "getByDocumentId", model)
      }
      deleteDocument(model: any): Observable<any> {
        return this.ApiService.PostRequest("DocumentFileUpload", "deleteDocument", model)
      }
      AddDocumentFile(model: any): Observable<any> {
   
        return this.ApiService.PostRequest("DocumentFileUpload", "AddDocuments",model)
      }
}