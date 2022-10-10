import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS, HttpClient } from '@angular/common/http';

import { NgbNavModule, NgbAccordionModule, NgbTooltipModule, NgbModule, NgbDropdownModule, NgbCollapseModule } from '@ng-bootstrap/ng-bootstrap';
import { CarouselModule } from 'ngx-owl-carousel-o';
import { ScrollToModule } from '@nicky-lenaers/ngx-scroll-to';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { DocumentUploadFileComponent } from './Documents/Screen/document-upload-file/document-upload-file.component';
import { ReactiveFormsModule,FormsModule } from '@angular/forms';
import { NgSelectModule } from '@ng-select/ng-select';
import { CommonModule } from '@angular/common';
import { UIModule } from 'src/ui.module';
import { DocumentUploadFileViewComponent } from './Documents/Screen/document-upload-file-view/document-upload-file-view.component';

@NgModule({
  declarations: [
    AppComponent,
    DocumentUploadFileComponent,
    DocumentUploadFileViewComponent
  ],
  imports: [
    UIModule,
    ReactiveFormsModule,
    FormsModule,
    CommonModule,
    NgbDropdownModule,
    NgbTooltipModule,
    NgbNavModule,
    NgbAccordionModule,
    NgbCollapseModule,
    HttpClientModule,
    NgSelectModule,
    BrowserModule,
    AppRoutingModule,
    CarouselModule,
    NgbAccordionModule,
    NgbNavModule,
    NgbTooltipModule,
    ScrollToModule.forRoot(),
    NgbModule
  ],
  bootstrap: [AppComponent],
  providers: [

  ],
})
export class AppModule { }
