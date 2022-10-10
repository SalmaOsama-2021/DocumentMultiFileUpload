import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import {NgbTypeaheadModule,NgbPaginationModule, NgbCollapseModule, NgbDatepickerModule, NgbTimepickerModule, NgbDropdownModule } from '@ng-bootstrap/ng-bootstrap';
import { Ng2SmartTableModule } from 'ng2-smart-table';

//import { ExportAsModule } from 'ngx-export-as';
@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    FormsModule,
    NgbCollapseModule,
    NgbDatepickerModule,
    NgbTimepickerModule,
    NgbDropdownModule,
    Ng2SmartTableModule,
    NgbPaginationModule,
    NgbTypeaheadModule,
   // ExportAsModule
  ],
  exports: []
})
export class UIModule { }
