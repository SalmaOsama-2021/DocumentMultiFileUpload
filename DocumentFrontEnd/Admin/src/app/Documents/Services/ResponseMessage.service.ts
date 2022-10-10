import { Injectable } from '@angular/core';
import Swal from 'sweetalert2';
@Injectable({
    providedIn: 'root'
  })
export class ResponseMessage{
showsuccessmessage(msg)
{
    Swal.fire('Good job!', msg, 'success');
}
showerrormessage(msg)
{
  
    Swal.fire('Try again!', msg, 'error');
  
}
}