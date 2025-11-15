using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MauiAppHotel.Models
{
    public class Eventos : INotifyPropertyChanged
    {
        private string _nome;
        private int _participantes;
        private DateTime _checkIn;
        private DateTime _checkOut;
        private double _custoPorParticipante = 100.0; // opcional

        public event PropertyChangedEventHandler PropertyChanged;

        public string Nome
        {
            get => _nome;
            set => SetField(ref _nome, value);
        }

        public int Participantes
        {
            get => _participantes;
            set
            {
                if (value < 0) value = 0;
                if (SetField(ref _participantes, value))
                    OnPropertyChanged(nameof(CustoTotal));
            }
        }

        public DateTime CheckIn
        {
            get => _checkIn;
            set
            {
                if (SetField(ref _checkIn, value))
                {
                    // garante pelo menos 1 dia de evento
                    if (CheckOut <= _checkIn)
                        CheckOut = _checkIn.AddDays(1);

                    OnPropertyChanged(nameof(DuracaoDias));
                    OnPropertyChanged(nameof(CustoTotal));
                }
            }
        }

        public DateTime CheckOut
        {
            get => _checkOut;
            set
            {
                var min = CheckIn.AddDays(1);
                if (value < min) value = min;
                if (SetField(ref _checkOut, value))
                {
                    OnPropertyChanged(nameof(DuracaoDias));
                    OnPropertyChanged(nameof(CustoTotal));
                }
            }
        }

        public double CustoPorParticipante
        {
            get => _custoPorParticipante;
            set
            {
                if (value < 0) value = 0;
                if (SetField(ref _custoPorParticipante, value))
                    OnPropertyChanged(nameof(CustoTotal));
            }
        }

        // Duração em dias (inteiro)
        public int DuracaoDias => Math.Max(0, (CheckOut.Date - CheckIn.Date).Days);

        // Cálculo do custo total (participantes * dias * custo por pessoa)
        public double CustoTotal => Math.Round(Participantes * DuracaoDias * CustoPorParticipante, 2);

        // helpers INotify
        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propName = "")
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propName);
            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
