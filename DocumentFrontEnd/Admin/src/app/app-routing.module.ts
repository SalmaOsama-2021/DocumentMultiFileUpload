import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DocumentUploadFileViewComponent } from './Documents/Screen/document-upload-file-view/document-upload-file-view.component';
import { DocumentUploadFileComponent } from './Documents/Screen/document-upload-file/document-upload-file.component';

const routes: Routes = [
{path:"DocumentUploadFileAdd",component:DocumentUploadFileComponent},
{path:'',component:DocumentUploadFileViewComponent}
];

@NgModule({
  imports:  [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
