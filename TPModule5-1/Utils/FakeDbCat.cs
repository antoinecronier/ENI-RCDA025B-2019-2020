using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TPModule5_1.Models;

namespace TPModule5_1.Utils
{
    public class FakeDbCat
    {
        private static FakeDbCat _instance;
        static readonly object instanceLock = new object();

        private FakeDbCat()
        {
            chats = this.GetMeuteDeChats();
        }

        public static FakeDbCat Instance
        {
            get
            {
                if (_instance == null) //Les locks prennent du temps, il est préférable de vérifier d'abord la nullité de l'instance.
                {
                    lock (instanceLock)
                    {
                        if (_instance == null) //on vérifie encore, au cas où l'instance aurait été créée entretemps.
                            _instance = new FakeDbCat();
                    }
                }
                return _instance;
            }
        }

        private List<Chat> chats;

        public List<Chat> Chats
        {
            get { return chats; }
        }

        private List<Chat> GetMeuteDeChats()
        {
            var i = 1;
            return new List<Chat>
            {
                new Chat{Id=i++,Nom = "Felix",Age = 3},
                new Chat{Id=i++,Nom = "Minette",Age = 1},
                new Chat{Id=i++,Nom = "Miss",Age = 10},
                new Chat{Id=i++,Nom = "Garfield",Age = 6},
                new Chat{Id=i++,Nom = "Chatran",Age = 4},
                new Chat{Id=i++,Nom = "Minou",Age = 2},
                new Chat{Id=i,Nom = "Bichette",Age = 12}
            };
        }
    }
}