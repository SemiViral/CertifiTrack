using System;
using System.Diagnostics;

namespace CertifiTrack
{
    public class DeathCertificate
    {
        public DateTime DateOfDeath { get; }
        public string RepresentableDate { get; }
        public string FuneralNumber { get; }
        public string Name { get; }
        public string Location { get; }
        public string Doctor { get; }
        public bool IsApproved { get; }
        public bool IsElectronic { get; }
        public bool ToDoctor { get; }
        public bool FromDoctor { get; }
        public bool ToState { get; }
        public bool FromState { get; }
        public string Notes { get; }


        public DeathCertificate(double dateOfDeath, object funeralNum, object name, object location, object doctor, object isElectronic, object isApproved, object toDr, object fromDr, object toState, object fromState, object notes)
        {
            DateOfDeath = DateTime.FromOADate(dateOfDeath);
            RepresentableDate = DateOfDeath.ToShortDateString();

            if (funeralNum != null)
            {
                FuneralNumber = funeralNum.ToString();
            }
            
            if (name != null)
            {
                Name = name.ToString();
            }
            
            if (location != null)
            {
                Location = location.ToString();
            }
            
            if (doctor != null)
            {
                Doctor = doctor.ToString();
            }

            if ((isElectronic != null) && (isElectronic.ToString().ToUpper() == "E"))
            {
                IsElectronic = true;
            }
            else
            {
                IsElectronic = false;
            }
            
            if ((isApproved != null) && (isApproved.ToString().ToUpper() == "Y"))
            {
                IsApproved = true;
            }
            else
            {
                IsApproved = false;
            }

            if ((toDr != null) && (toDr.ToString().ToUpper() == "X"))
            {
                ToDoctor = true;
            }
            else
            {
                ToDoctor = false;
            }

            if ((fromDr != null) && (fromDr.ToString().ToUpper() == "X"))
            {
                FromDoctor = true;
            }
            else
            {
                FromDoctor = false;
            }

            if ((toState != null) && (toState.ToString().ToUpper() == "X"))
            {
                ToState = true;
            }
            else
            {
                ToState = false;
            }

            if ((fromState != null) && (fromState.ToString().ToUpper() == "X"))
            {
                FromState = true;
            }
            else
            {
                FromState = false;
            }

            if (notes != null)
            {
                Notes = notes.ToString();
            }

            Debug.WriteLine($"{RepresentableDate} Certificate added of name {Name}", "Information");
        }
    }
}
