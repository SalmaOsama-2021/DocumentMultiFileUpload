import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DocumentUploadFileViewComponent } from './document-upload-file-view.component';

describe('DocumentUploadFileViewComponent', () => {
  let component: DocumentUploadFileViewComponent;
  let fixture: ComponentFixture<DocumentUploadFileViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DocumentUploadFileViewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DocumentUploadFileViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
