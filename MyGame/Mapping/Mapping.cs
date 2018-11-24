using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MyGame.ViewModels;
using GameLogic;

namespace MyGame.Mapping
{
    public static class Mapping
    {
        public static IMapper CreateMapper_Memento_to_SaveListElement()
        {
            return new MapperConfiguration(ctg =>
            {
                ctg.CreateMap<MazeMemento, SaveListElement>();
            }).CreateMapper();
        }

        public static IMapper CreateMapper_SaveListElement_to_Memento()
        {
            return new MapperConfiguration(ctg =>
            {
                ctg.CreateMap<SaveListElement, MazeMemento>().ForMember("Path", opt=>opt.MapFrom(x=>MementoCareTaker.SavePath + x.Name + ".dat"));
            }).CreateMapper();
        }

        public static IMapper CreateMapper_Player_to_PlayerViewModel()
        {
            return new MapperConfiguration(ctg => ctg.CreateMap<Player, PlayerModelView>()).CreateMapper();
        }
    }
}
