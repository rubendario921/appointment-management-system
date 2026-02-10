import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

export interface Appointment {
  id: number;
  plaque: string;
  createdHour: string;
  createdDate: string;
}

export interface ApiResponse<T> {
  success: boolean;
  data: T;
  message: string;
}

export interface NewAppointment {
  plaque: string;
  createdHour: string;
}

@Injectable({
  providedIn: 'root',
})
export class AppointmentService {
  private apiUrl = 'http://localhost:5079/api/Appointment';

  constructor(private http: HttpClient) {}

  //GetAppointmentsByPlaque
  getAppointmentsByPlaque(plaque: string): Observable<ApiResponse<Appointment[]>> {
    return this.http.get<ApiResponse<Appointment[]>>(`${this.apiUrl}/history/${plaque}`);
  }

  //CreateAppointment
  createAppointment(appointment: NewAppointment): Observable<ApiResponse<Appointment>> {
    return this.http.post<ApiResponse<Appointment>>(this.apiUrl, appointment);
  }
}
