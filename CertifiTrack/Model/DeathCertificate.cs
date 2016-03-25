#region

using System;
using System.Diagnostics;

#endregion

namespace CertifiTrack.Model {
    public class DeathCertificate {
        public DeathCertificate(double dateOfDeath, object funeralNum, object name, object location, object doctor,
            object isElectronic, object isApproved, object toDr, object fromDr, object toState, object fromState,
            object notes) {
            DateOfDeath = DateTime.FromOADate(dateOfDeath);
            RepresentableDate = DateOfDeath.ToShortDateString();

            if (funeralNum != null) FuneralNumber = funeralNum.ToString();

            if (name != null) Name = name.ToString();

            if (location != null) Location = location.ToString();

            if (doctor != null) Doctor = doctor.ToString();

            if (isElectronic != null &&
                isElectronic.ToString().ToUpper().Equals("E")) {
                IsElectronic = true;
                DcType = "Electronic";
            } else {
                IsElectronic = false;
                DcType = "Paper";
            }

            if ((isApproved != null) &&
                isApproved.ToString().ToUpper().Equals("Y")) IsApproved = true;
            else IsApproved = false;

            if (toDr != null &&
                toDr.ToString().ToUpper().Equals("X")) ToDoctor = true;
            else ToDoctor = false;

            if (fromDr != null &&
                fromDr.ToString().ToUpper().Equals("X")) FromDoctor = true;
            else FromDoctor = false;

            if (toState != null &&
                toState.ToString().ToUpper().Equals("X")) ToState = true;
            else ToState = false;

            if (fromState != null &&
                fromState.ToString().ToUpper().Equals("X")) FromState = true;
            else FromState = false;

            IsOld = DateOfDeath.AddDays(21) <= DateTime.Now;

            switch (Location) {
                case "S":
                    LocationSwitch = 0;
                    break;
                case "V":
                    LocationSwitch = 1;
                    break;
                case "W":
                    LocationSwitch = 2;
                    break;
            }

            if (notes != null) Notes = notes.ToString();

            Debug.WriteLine($"{RepresentableDate} Certificate added of name {Name}; IsOld: {IsOld}", "Information");
        }

        public DateTime DateOfDeath { get; }
        public string RepresentableDate { get; }
        public string FuneralNumber { get; }
        public string Name { get; }
        public string Location { get; }
        public string Doctor { get; }
        public string DcType { get; }
        public bool IsApproved { get; set; }
        public bool IsElectronic { get; }
        public bool ToDoctor { get; }
        public bool FromDoctor { get; }
        public bool ToState { get; }
        public bool FromState { get; }
        public bool IsOld { get; }
        public string Notes { get; }
        public int LocationSwitch { get; }
    }
}