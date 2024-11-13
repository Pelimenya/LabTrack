using System;
using LabTrack.Context;
using LabTrack.Entites;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Linq;
using Avalonia.Controls;
using Microsoft.Extensions.DependencyInjection;

namespace LabTrack.Pages.AdminPages
{
    public partial class MainFormPage : UserControl
    {
        private readonly MedicalContext _context;
        public ObservableCollection<PatientDoctorAppointment> TodaysAppointments { get; set; }
        public ObservableCollection<MedicalRecord> RecentMedicalRecords { get; set; }

        public MainFormPage()
        {
            InitializeComponent();

            // Получение контекста данных
            _context = App.ServiceProvider.GetService<MedicalContext>();

            // Инициализация коллекций перед привязкой
            TodaysAppointments = new ObservableCollection<PatientDoctorAppointment>();
            RecentMedicalRecords = new ObservableCollection<MedicalRecord>();

            // Привязка данных для интерфейса
            DataContext = this;

            // Загрузка данных
            LoadData();
        }

        private void LoadData()
        {
            // Получение сегодняшней даты
            var today = DateOnly.FromDateTime(DateTime.Today);

            // Загрузка данных о сегодняшних записях пациента к врачу
            TodaysAppointments = new ObservableCollection<PatientDoctorAppointment>(
                _context.PatientDoctorAppointments
                    .Include(a => a.IdPatientNavigation)
                    .Where(a => a.AppointmentDate == today)
                    .ToList());

            // Загрузка последних медицинских записей
            RecentMedicalRecords = new ObservableCollection<MedicalRecord>(
                _context.MedicalRecords
                    .Include(r => r.IdPatientNavigation)
                    .OrderByDescending(r => r.IdMedicalRecord)
                    .Take(10)
                    .ToList());
        }
    }
}