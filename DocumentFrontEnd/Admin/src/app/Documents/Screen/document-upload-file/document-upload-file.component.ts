import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, MinLengthValidator, Validators } from "@angular/forms";
import { DocumentRequest } from '../../Models/DocumentRequest';
import { ResponseMessage } from '../../Services/ResponseMessage.service';
import { DocumentUploadFileService } from '../../Services/DocumentUploadFileService.service';
import { ResponseHeader } from '../../Models/response-header';
import { documentsDto } from '../../Models/documentsDto';
import { General } from '../../Models/General';
import { GeneralDto } from '../../Models/generalDto';
import { ActivatedRoute } from '@angular/router';
import { formatDate } from '@angular/common';
import { element } from 'protractor';
@Component({
  selector: 'app-document-upload-file',
  templateUrl: './document-upload-file.component.html',
  styleUrls: ['./document-upload-file.component.scss']
})
export class DocumentUploadFileComponent implements OnInit {
  frmdata = new FormGroup({});
  Priority:any[]=[];
  myFiles:any;
  myInput:boolean=false;
  public generalDto: GeneralDto;
  public responseResult:ResponseHeader;
  _ID:number;
  request:documentsDto;
  DataList:documentsDto;
  document_files:any;
  constructor( private frmBuilder: FormBuilder,private _DocumentService:DocumentUploadFileService,  private Activeroute: ActivatedRoute,private _responseMessage:ResponseMessage) { 
    this._ID = Number.parseInt(this.Activeroute.snapshot.queryParamMap.get('id'));
  }

  ngOnInit(): void {
    this.getAllPriority()
    this.restFormGroup();
    if(this._ID>0){
     this.getById();
    }
  }
  Cleardata(){
   this.restFormGroup()
  }
  // [Validators.required, Validators.min(1)]
  restFormGroup() {
    this.frmdata = this.frmBuilder.group({
        Id: new FormControl('0'),
        PriorityId: new FormControl('0'),
        Name: new FormControl('',Validators.required),
        FilePath: new FormControl(''),
        attachmentFiles:new FormControl(''),
        Date: new FormControl('',Validators.required),
        Due_date: new FormControl('',Validators.required),
        Created: new FormControl('',Validators.required),
        isEnabled: new FormControl(false),
        isDeleted: new FormControl(false),
      
    });
    this,this.document_files=[];
}
SaveAttachment(){
  debugger;
this.request={
  iD:this._ID,
  created:this.frmdata.get('Created').value,
  date:this.frmdata.get('Date').value,
  due_date:this.frmdata.get('Due_date').value,
  priorityId:this.frmdata.get('PriorityId').value,
  name:this.frmdata.get('Name').value,
  document_files:this.myFiles
}
const formData = new FormData();
formData.append('requestBody', JSON.stringify(this.request));
    this._DocumentService.AddDocumentFile(formData).subscribe(res => {
        this.responseResult = res;
        if (this.responseResult.statusCode == 200) {
            this._responseMessage.showsuccessmessage(this.responseResult.responseMessage);
            this.restFormGroup();
          
           
    
        } else {
            this._responseMessage.showerrormessage(this.responseResult.responseMessage);
        }

    })

  // }
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
  
getById(){
debugger
this.generalDto =
{
    id:this._ID
}
const formData = new FormData();
formData.append('requestBody', JSON.stringify(this.generalDto));
      this._DocumentService.getByDocumentId(formData).subscribe(res => {
        debugger;
          this.responseResult = res;
          if (this.responseResult.statusCode == 200) {
            this.DataList=this.responseResult.result;
            this.frmdata = this.frmBuilder.group({
              id: new FormControl(this.DataList.iD),
              Name: new FormControl(this.DataList.name),
              Created: new FormControl(formatDate(this.DataList.created, "yyyy-MM-dd", "en")),
              Date: new FormControl(formatDate(this.DataList.date, "yyyy-MM-dd", "en")),
              Due_date: new FormControl(formatDate(this.DataList.due_date, "yyyy-MM-dd", "en")),
              PriorityId: new FormControl(this.DataList.priorityId)
             });
            
        this.document_files=this.DataList.document_files
          } else {
              this._responseMessage.showerrormessage(this.responseResult.responseMessage);
          }
  
      })
  
    }
onFileChange(event:any) {
  debugger;
  this.myFiles = [];
  if (event.target.files.length > 0) {
      for (var i = 0; i < event.target.files.length; i++) {
          const file = event.target.files[i];
          const reader = new FileReader();
          reader.readAsDataURL(file);
          reader.onload = () => {
            if(this._ID==0){
              this.myFiles.push({
                 fileSource: reader.result,
                 documentFileName: file.name,
                  File_path: '',
                  id: 0,
                  Document_ID:this._ID,
                  isDeleted: false,
              });
              this.document_files=this.myFiles;
            }else{
              this.document_files.forEach(m=>{
                this.myFiles.push({
                  fileSource: reader.result,
                  documentFileName: file.name,
                   File_path: '',
                   id: m.id,
                   Document_ID:this._ID,
                   isDeleted: false,
               });
              })
              this.document_files=this.myFiles;
            }
          };
      }
      
      this.frmdata.patchValue({
          attachmentFiles: this.myFiles
      });
      
  }
  
}

}
