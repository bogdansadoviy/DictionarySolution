using Dictionary.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace DictionatyProjectTests
{
    public static class DataProvider
    {
        public static List<Word> Words()
        {
            return new List<Word>()
            {
                new Word() 
                {
                    Id = 1,
                    ImagePath = "local/image1.jpeg",
                    PlText = "Pl text",
                    Transcription = "[transcription]",
                    UaText = "Ua text"
                },
                new Word() 
                {
                    Id = 2,
                    ImagePath = "local/image2.jpeg",
                    PlText = "Pl text",
                    Transcription = "[transcription]",
                    UaText = "Ua text"
                },
                new Word() 
                {
                    Id = 3,
                    ImagePath = "local/image3.jpeg",
                    PlText = "Pl text",
                    Transcription = "[transcription]",
                    UaText = "Ua text"
                },
                new Word() 
                {
                    Id = 4,
                    ImagePath = "local/image4.jpeg",
                    PlText = "Pl text",
                    Transcription = "[transcription]",
                    UaText = "Ua text"
                }
            };
        }

        public static List<IdentityUser> Users()
        {
            return new List<IdentityUser>()
            {
                new IdentityUser()
                {
                    Id = CurrentUserId().ToString(),
                    Email = "user@gmail.com"
                }
            };
        }

        public static Guid CurrentUserId()
        {
            return new Guid("5610CE14-3C22-4814-9187-20FD810973CA");
        }

        public static ClaimsPrincipal UserClaims()
        {
            return new ClaimsPrincipal(new List<ClaimsIdentity>()
            {
                new ClaimsIdentity(new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, CurrentUserId().ToString())
                })
            });
        }

        public static List<UserWordMapping> UserWordMappings()
        {
            return new List<UserWordMapping>()
            {
                new UserWordMapping()
                {
                    Id = 1,
                    UserId = CurrentUserId(),
                    WordId = 1
                },
                new UserWordMapping()
                {
                    Id = 2,
                    UserId = CurrentUserId(),
                    WordId = 2
                },
                new UserWordMapping()
                {
                    Id = 3,
                    UserId = new Guid(),
                    WordId = 3
                }
            };
        }
    }
}