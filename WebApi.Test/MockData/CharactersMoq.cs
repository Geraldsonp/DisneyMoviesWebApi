using System.Collections.Generic;
using DisneyMovies.Core.Entities;

namespace WebApi.Test.MockData;

public static class CharactersMoq
{
    public static List<Character> GetCharacters()
    {
        return  new()
        {
            new Character()
            {
                Id = 1, Name = "Multi-layered",
                ImgUrl =
                    "natoque penatibus et magnis dis parturient montes nascetur ridiculus mus etiam vel augue vestibulum rutrum rutrum",
                Age = 88,
                Weight = 11,
                History = "ultrices posuere cubilia curae mauris viverra diam"
            },
            new Character()
            {
                Id = 2, Name = "paradigm",
                ImgUrl =
                    "natoque penatibus et magnis dis parturient montes nascetur ridiculus mus etiam vel augue vestibulum rutrum rutrum",
                Age = 88,
                Weight = 11,
                History = "ultrices posuere cubilia curae mauris viverra diam"
            },
            new Character()
            {
                Id = 3, Name = "Digitized",
                ImgUrl =
                    "natoque penatibus et magnis dis parturient montes nascetur ridiculus mus etiam vel augue vestibulum rutrum rutrum",
                Age = 88,
                Weight = 11,
                History = "ultrices posuere cubilia curae mauris viverra diam"
            }};
    } 
    
}