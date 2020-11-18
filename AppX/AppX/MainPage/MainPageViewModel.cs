﻿using AppX.DatabaseClasses;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace AppX
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private PatientDB patient;
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string fullName { get; set; }
        public string phoneNumber { get; set; }
        public DateTime birthDate { get; set; }
        public string hobby { get; set; }
        public string photo { get; set; }
        public int age { get; set; }
        public string todaysDate { get; set; }
        public MainPageViewModel()
        {
            using (SQLiteConnection pat = new SQLiteConnection(App.FilePath))
            {
                pat.CreateTable<PatientDB>();
                patient = pat.Table<PatientDB>().FirstOrDefault();
            }

            firstName = patient.FirstName;
            lastName = patient.LastName;
            fullName = firstName + " " + lastName;
            phoneNumber = patient.PhoneNumber;
            birthDate = patient.BirthDate;
            hobby = patient.Hobby;
            photo = patient.Photo;
            age = DateTime.Now.Year - patient.BirthDate.Year;
            todaysDate = DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year;
        }

    }
}
