using FriendStorage.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace FriendStorage.DataAccess
{
    public class FileDataService : IDataService
    {
        private const string StorageFile = "Friends.json";

        //TODO

        public IEnumerable<Friend> GetAllFriends()
        {
            return ReadFromFile();
        }

        public void Dispose()
        {
            // Usually Service-Proxies are disposable. This method is added
            // as demo-purpose to show how to use an IDisposable in the client
            // with a Func<T>. => Look for example at the
            // FriendDataProvider -class
        }

        //TODO

        private List<Friend> ReadFromFile()
        {
            if (File.Exists(StorageFile) == false)
            {
                return new List<Friend>
                {
                    new Friend
                    {
                        Id =1,
                        FirstName = "Thomas",
                        LastName ="Huber",
                        Address = new Address
                        {
                            City = "Müllheim",
                            Street = "Elmstreet",
                            StreetNumber = "12345",
                        },
                        Birthday = new DateTime(1980,10,28),
                        IsDeveloper = true,
                        Emails = new List<FriendEmail>
                        {
                            new FriendEmail
                            {
                                Email ="thomas@thomasclaudiushuber.com"
                            }
                        },
                        FriendGroupId = 1
                    },
                    new Friend{Id=2,FirstName = "Julia",LastName="Huber",Address=new Address{City="Müllheim",Street="Elmstreet",StreetNumber = "12345"},
                        Birthday = new DateTime(1982,10,10),Emails=new List<FriendEmail>{new FriendEmail{Email="julia@juhu-design.com"}},FriendGroupId = 1},
                    new Friend{Id=3,FirstName="Anna",LastName="Huber",Address=new Address{City="Müllheim",Street="Elmstreet",StreetNumber = "12345"},
                        Birthday = new DateTime(2011,05,13),Emails=new List<FriendEmail>(),FriendGroupId = 1},
                    new Friend{Id=4,FirstName="Sara",LastName="Huber",Address=new Address{City="Müllheim",Street="Elmstreet",StreetNumber = "12345"},
                        Birthday = new DateTime(2013,02,25),Emails=new List<FriendEmail>(),FriendGroupId = 1},
                    new Friend{Id=5,FirstName = "Andreas",LastName="Böhler",Address=new Address{City="Tiengen",Street="Hardstreet",StreetNumber = "5"},
                        Birthday = new DateTime(1981,01,10), IsDeveloper = true,Emails=new List<FriendEmail>{new FriendEmail{Email="andreas@strenggeheim.de"}},FriendGroupId = 2},
                    new Friend{Id=6,FirstName="Urs",LastName="Meier",Address=new Address{City="Bern",Street="Baslerstrasse",StreetNumber = "17"},
                        Birthday = new DateTime(1970,03,5), IsDeveloper = true,Emails=new List<FriendEmail>{new FriendEmail{Email="urs@strenggeheim.ch"}},FriendGroupId = 2},
                     new Friend{Id=7,FirstName="Chrissi",LastName="Heuberger",Address=new Address{City="Hillhome",Street="Freiburgerstrasse",StreetNumber = "32"},
                        Birthday = new DateTime(1987,07,16),Emails=new List<FriendEmail>{new FriendEmail{Email="chrissi@web.de"}},FriendGroupId = 2},
                     new Friend{Id=8,FirstName="Erkan",LastName="Egin",Address=new Address{City="Neuenburg",Street="Rheinweg",StreetNumber = "4"},
                        Birthday = new DateTime(1983,05,23),Emails=new List<FriendEmail>{new FriendEmail{Email="erko@web.de"}},FriendGroupId = 2},
                };
            }

            string json = File.ReadAllText(StorageFile);

            // Newtonsoft.Json
            // https://www.nuget.org/packages/Newtonsoft.Json/
            // Install-Package -Id Newtonsoft.Json -ProjectName FriendStorage.DataAccess
            // Install-Package -Id Newtonsoft.Json -ProjectName FriendStorage.UI
            return JsonConvert.DeserializeObject<List<Friend>>(json);
        }
    }
}
