using DziennikElektroniczny.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DziennikElektroniczny.ViewModels
{
    public class ClassroomsView
    {
        public int Id { get; set; }
        public string Building { get; set; }
        public string Floor { get; set; }
        public string Destination { get; set; }

        public ClassroomsView(ClassRoom  classRoom)
        {
            Id = classRoom.ClassRoomId;
            Building = classRoom.Building;
            Floor = classRoom.Floor;
            Destination = classRoom.Destination;
        }
    }
}
