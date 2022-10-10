import { Component, OnInit, ViewChild } from '@angular/core';
import { element } from 'protractor';
import { GeneralDto } from '../../Models/generalDto';
import { ResponseHeader } from '../../Models/response-header';
import { DocumentUploadFileService } from '../../Services/DocumentUploadFileService.service';
import { ResponseMessage } from '../../Services/ResponseMessage.service';
import { DocumentUploadFileComponent } from '../document-upload-file/document-upload-file.component';

@Component({
  selector: 'app-document-upload-file-view',
  templateUrl: './document-upload-file-view.component.html',
  styleUrls: ['./document-upload-file-view.component.scss']
})
export class DocumentUploadFileViewComponent implements OnInit {

  constructor(private _DocumentService:DocumentUploadFileService,private _responseMessage:ResponseMessage) { }

  ngOnInit(): void {
    this.getAllPriority();
    this.getAllData();
  }
  public generalDto: GeneralDto;
  public responseResult:ResponseHeader;
  public DataList :any;
  public id:number;
  public PathUrl:any;
  Priority:any[]=[];
  getAllData(){

    debugger;
    this.generalDto =
    {
        id:0
    }
          this._DocumentService.GetDocumentFile(this.generalDto).subscribe(res => {
            debugger;
              this.responseResult = res;
              if (this.responseResult.statusCode == 200) {

                this.DataList=this.responseResult.result;
               this.getNamePriority(1);
                console.log("this.PathUrl=",this.PathUrl);
                  // this._responseMessage.showsuccessmessage(this.responseResult.responseMessage);
                 
                
             
          
              } else {
                  this._responseMessage.showerrormessage(this.responseResult.responseMessage);
              }
      
          })
      
        }
        UpdateData(id: any) {
          debugger;
          this.id = id;
          window.open("DocumentUploadFileAdd?id=" + id + "", '_blank');
        }
        AddData() {
          this.id = 0;
          window.open("DocumentUploadFileAdd?id=" +   this.id + "", '_blank');
        }
        DeleteData(id:any){

          this.generalDto =
          {
              id:id
          }
          const formData = new FormData();
formData.append('requestBody', JSON.stringify( this.generalDto));
                this._DocumentService.deleteDocument(formData).subscribe(res => {
                    this.responseResult = res;
                    if (this.responseResult.statusCode == 200) {
                     
                        this._responseMessage.showsuccessmessage(this.responseResult.responseMessage);
                       this.getAllData();
                      
                   
                
                    } else {
                        this._responseMessage.showerrormessage(this.responseResult.responseMessage);
                    }
            
                })
            
              }
              getAllPriority(){
                debugger;
              this.generalDto =
              {
                  id:0
              }
                    this._DocumentService.getAllPriority(this.generalDto).subscribe(res => {
                        this.responseResult = res;
                        if (this.responseResult.statusCode == 200) {
                          this.Priority=this.responseResult.result;
                            // this._responseMessage.showsuccessmessage(this.responseResult.responseMessage);
                         
                          
                       
                    
                        } else {
                            this._responseMessage.showerrormessage(this.responseResult.responseMessage);
                        }
                
                    })
                
                  }
              listname:any;
              getNamePriority(PriorityId:any){
                debugger
               this.listname= this.Priority.filter(x=>x.id==PriorityId);
               var name;
               if(this.listname.length>0)
                {
                  this.listname.forEach(element => {
                    name=element.name
                  });
              return name;
                }else{
                  name="";
                  return name;
                }
             
              }
}
