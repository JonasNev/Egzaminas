import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Parcel } from '../Models/parcel';

@Injectable({
  providedIn: 'root'
})
export class ParcelService {

  private http: HttpClient;
  constructor(http: HttpClient) {
    this.http = http;
   }

   public GetParcels(): Observable<Parcel[]> {
    return this.http.get<Parcel[]>("https://localhost:44379/api/Parcel");
  }
  public AddParcel(parcel: Parcel): Observable<Parcel>{
    return this.http.post<Parcel>("https://localhost:44379/api/Parcel", parcel);
  }
  public DeleteParcel(parcel: Parcel): Observable<Parcel> {
    const url = `https://localhost:44379/api/Parcel/${parcel.id}`;
    return this.http.delete<Parcel>(url);
  }
  public UpdateParcel(parcel: Parcel) : Observable<Parcel> {
    return this.http.put<Parcel>(`https://localhost:44379/api/Parcel/${parcel.id}`, parcel)
  }
}
