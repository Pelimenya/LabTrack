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

        // Свойства для привязки данных
        public ObservableCollection<PatientDoctorAppointment> TodaysAppointments { get; set; }
        public ObservableCollection<MedicalRecord> RecentMedicalRecords { get; set; }
        
        // Данные активности врачей
        public ObservableCollection<ISeries> DoctorActivityData { get; set; }

        public MainFormPage()
        {
            InitializeComponent();

            // Получение контекста данных
            _context = App.ServiceProvider.GetService<MedicalContext>();

            // Инициализация коллекций
            TodaysAppointments = new ObservableCollection<PatientDoctorAppointment>();
            RecentMedicalRecords = new ObservableCollection<MedicalRecord>();
            DoctorActivityData = new ObservableCollection<ISeries>();

            // Загрузка данных
            LoadData();

            // Установка контекста данных
            DataContext = this;
        }

        private void LoadData()
        {
            // Текущая дата
            var today = DateOnly.FromDateTime(DateTime.Today);

            // Загрузка всех записей на текущий день
            TodaysAppointments = new ObservableCollection<PatientDoctorAppointment>(
                _context.PatientDoctorAppointments
                    .Include(a => a.IdPatientNavigation)
                    .Include(a => a.IdDoctorNavigation)
                    .Where(a => a.AppointmentDate == today)
                    .ToList());

            // Загрузка последних 10 медицинских записей всех пациентов
            RecentMedicalRecords = new ObservableCollection<MedicalRecord>(
                _context.MedicalRecords
                    .Include(r => r.IdPatientNavigation)
                    .Include(r => r.IdDoctorNavigation)
                    .OrderByDescending(r => r.IdMedicalRecord)
                    .Take(10)
                    .ToList());

            // Загрузка активности врачей за последние 30 дней
            LoadDoctorActivityData();
        }

        private void LoadDoctorActivityData()
        {
            var lastMonth = DateOnly.FromDateTime(DateTime.Today.AddDays(-30));

            // Группируем записи по врачам и считаем количество записей за последние 30 дней
            var activityData = _context.PatientDoctorAppointments
                .Include(a => a.IdDoctorNavigation)
                .Where(a => a.AppointmentDate >= lastMonth)
                .GroupBy(a => a.IdDoctorNavigation.FirstName + " " + a.IdDoctorNavigation.LastName)
                .Select(g => new
                {
                    DoctorName = g.Key,
                    AppointmentCount = g.Count()
                })
                .ToList();

            // Создаем серии данных для графика
            DoctorActivityData.Clear();
            DoctorActivityData.Add(new ColumnSeries<int>
            {
                Values = activityData.Select(d => d.AppointmentCount).ToArray(),
                Name = "Число записей"
            });
            
            // Настройка осей (имена врачей по оси X)
            ActivityChart.XAxes = new[]
            {
                new Axis
                {
                    Labels = activityData.Select(d => d.DoctorName).ToArray()
                }
            };
        }
    }
}
