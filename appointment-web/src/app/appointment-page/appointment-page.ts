import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { Appointment, AppointmentService } from '../services/appointment.service';

@Component({
  selector: 'app-appointment-page',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './appointment-page.html',
  styleUrl: './appointment-page.css',
})
export class AppointmentPage {
  consultForm: FormGroup;
  scheduleForm: FormGroup;
  appointments: Appointment[] = [];
  message = '';

  constructor(
    private fb: FormBuilder,
    private appointmentService: AppointmentService,
  ) {
    this.consultForm = this.fb.group({
      plaque: ['', [Validators.required, Validators.pattern('^[A-Z]{3}[0-9]{4}$')]],
    });
    this.scheduleForm = this.fb.group({
      plaque: ['', [Validators.required, Validators.pattern('^[A-Z]{3}[0-9]{4}$')]],
      date: ['', [Validators.required]],
      time: ['', [Validators.required]],
    });
  }

  onConsult() {
    const plaque = this.consultForm.get('plaque')?.value;
    this.appointmentService.getAppointmentsByPlaque(plaque).subscribe(
      (response) => {
        console.log('Consult Response:', response);
        if (response.success && response.data && response.data.length > 0) {
          this.appointments = [...response.data];
          this.message = '';
        } else {
          this.appointments = [];
          this.message = response.message || 'No appointment found for the given plaque.';
        }
      },
      (error) => {
        console.error('Error fetching appointment:', error);
        this.message = 'An error occurred while fetching the appointment.';
      },
    );
  }

  onSchedule() {
    const plaque = this.scheduleForm.get('plaque')?.value;
    const date = this.scheduleForm.get('date')?.value;
    const time = this.scheduleForm.get('time')?.value;

    this.appointmentService
      .createAppointment({ plaque, createdHour: `${date}T${time}:00` })
      .subscribe(
        (response) => {
          console.log('Schedule Response:', response);
          if (response.success) {
            this.appointments = [response.data, ...this.appointments];
            this.message = response.message || 'Appointment scheduled successfully.';
            this.scheduleForm.reset();
          } else {
            this.message = response.message || 'Could not schedule the appointment.';
          }
        },
        (error) => {
          console.error('Error scheduling appointment:', error);
          this.message = 'An error occurred while scheduling the appointment.';
        },
      );
  }
}
