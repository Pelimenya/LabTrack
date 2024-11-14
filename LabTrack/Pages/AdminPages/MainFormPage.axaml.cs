using System;
using System.Collections.ObjectModel;
using System.Linq;
using Avalonia.Controls;
using LabTrack.Context;
using LabTrack.Entites;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LabTrack.Pages.AdminPages
{
    public partial class MainFormPage : UserControl
    {
        private readonly MedicalContext _context;

        // Коллекции для привязки данных в интерфейсе
        public ObservableCollection<PatientDoctorAppointment> TodaysAppointments { get; set; }
        public ObservableCollection<MedicalRecord> RecentMedicalRecords { get; set; }
        public ObservableCollection<ISeries> DoctorActivityData { get; set; }

        public MainFormPage()
        {
            InitializeComponent();
            
            // Инициализация данных
            _context = App.ServiceProvider.GetService<MedicalContext>();
            TodaysAppointments = new ObservableCollection<PatientDoctorAppointment>();
            RecentMedicalRecords = new ObservableCollection<MedicalRecord>();
            DoctorActivityData = new ObservableCollection<ISeries>();

            LoadData();
            DataContext = this;
        }

        private void LoadData()
        {
            var today = DateOnly.FromDateTime(DateTime.Today);
            var lastMonth = DateOnly.FromDateTime(DateTime.Today.AddDays(-30));

            // Загружаем сегодняшние записи
            TodaysAppointments = new ObservableCollection<PatientDoctorAppointment>(
                _context.PatientDoctorAppointments
                    .Include(a => a.IdPatientNavigation)
                    .Include(a => a.IdDoctorNavigation)
                    .Where(a => a.AppointmentDate == today)
                    .ToList());

            // Загружаем последние медицинские записи
            RecentMedicalRecords = new ObservableCollection<MedicalRecord>(
                _context.MedicalRecords
                    .Include(r => r.IdPatientNavigation)
                    .Include(r => r.IdDoctorNavigation)
                    .OrderByDescending(r => r.IdMedicalRecord)
                    .Take(10)
                    .ToList());

            // Загружаем данные для графика активности врачей
            var activityData = _context.PatientDoctorAppointments
                .Include(a => a.IdDoctorNavigation)
                .Where(a => a.AppointmentDate >= lastMonth)
                .GroupBy(a => a.IdDoctorNavigation.FirstName + " " + a.IdDoctorNavigation.LastName)
                .Select(g => new { DoctorName = g.Key, AppointmentCount = g.Count() })
                .ToList();

            // Добавляем данные активности для графика
            DoctorActivityData.Clear();
            if (activityData.Any())
            {
                DoctorActivityData.Add(new ColumnSeries<int>
                {
                    Values = activityData.Select(d => d.AppointmentCount).ToArray(),
                    Name = "Число записей"
                });

                // Устанавливаем метки оси X
                var labels = activityData.Select(d => d.DoctorName).ToArray();
                ActivityChart.XAxes = new[]
                {
                    new Axis { Labels = labels }
                };
            }
        }
    }
}