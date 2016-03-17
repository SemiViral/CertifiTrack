using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertifiTrack
{
    class DeathCertificate
    {
        public DateTime _DateOfDeath;
        public string _FuneralNumber;
        public string _Name;
        public string _Location;
        public string _Doctor;
        public bool _isApproved;
        public bool _isElectronic;
        public bool _toDoctor;
        public bool _fromDoctor;
        public bool _toState;
        public bool _fromState;
        public string _Notes;


        public DeathCertificate(double dateOfDeath, object funeralNum, object name, object location, object doctor, object isElectronic, object isApproved, object toDr, object fromDr, object toState, object fromState, object notes)
        {
            _DateOfDeath = DateTime.FromOADate(dateOfDeath);

            if (funeralNum != null)
            {
                _FuneralNumber = funeralNum.ToString();
            }
            
            if (name != null)
            {
                _Name = name.ToString();
            }
            
            if (location != null)
            {
                _Location = location.ToString();
            }
            
            if (doctor != null)
            {
                _Doctor = doctor.ToString();
            }

            if ((isElectronic != null) && (isElectronic.ToString().ToUpper() == "E"))
            {
                _isElectronic = true;
            }
            else
            {
                _isElectronic = false;
            }
            
            if ((isApproved != null) && (isApproved.ToString().ToUpper() == "Y"))
            {
                _isApproved = true;
            }
            else
            {
                _isApproved = false;
            }

            if ((toDr != null) && (toDr.ToString().ToUpper() == "X"))
            {
                _toDoctor = true;
            }
            else
            {
                _toDoctor = false;
            }

            if ((fromDr != null) && (fromDr.ToString().ToUpper() == "X"))
            {
                _fromDoctor = true;
            }
            else
            {
                _fromDoctor = false;
            }

            if ((toState != null) && (toState.ToString().ToUpper() == "X"))
            {
                _toState = true;
            }
            else
            {
                _toState = false;
            }

            if ((fromState != null) && (fromState.ToString().ToUpper() == "X"))
            {
                _fromState = true;
            }
            else
            {
                _fromState = false;
            }

            if (notes != null)
            {
                _Notes = notes.ToString();
            }
        }
    }
}
