import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DocumentUploadFileComponent } from './document-upload-file.component';

describe('DocumentUploadFileComponent', () => {
  let component: DocumentUploadFileComponent;
  let fixture: ComponentFixture<DocumentUploadFileComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DocumentUploadFileComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DocumentUploadFileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
