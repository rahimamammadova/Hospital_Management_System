using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMS_BLL.Dtos;
using HMS_DAL.Models;

namespace HMS_BLL.Mapper
{
    public class CustomProfile : Profile
    {
        public CustomProfile()
        {

            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Person,PersonDto>().ReverseMap();
            CreateMap<Hospital, HospitalDto>().ReverseMap();
            CreateMap<Nurse, NurseDto>().ReverseMap();
            CreateMap<Appointment, AppointmentDto>().ReverseMap();
            CreateMap<Doctor, DoctorDto>().ReverseMap();
            CreateMap<Patient, PatientDto>().ReverseMap();
            CreateMap<Medicine, MedicineDto>().ReverseMap();


        }

    }
}
