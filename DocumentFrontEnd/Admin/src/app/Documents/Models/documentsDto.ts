import { document_filesDto } from "./document_filesDto"

export interface documentsDto{
   iD:number,
   name :string,
   date:Date,
   created:Date,
   due_date:Date
   priorityId :number,
   document_files:document_filesDto[]
}