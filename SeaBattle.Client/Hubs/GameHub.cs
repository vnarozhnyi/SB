using CreateAttribute;
using Microsoft.AspNet.SignalR;
using Newtonsoft.Json;
using ORM.Models;
using SeaBattle.Client.Models;
using SeaBattle.Client.Objects;
using SeaBattle.Client.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;


namespace SeaBattle.Client.Hubs
{
    //[Encryption(className: "CreateAttribute.EncryptionService", guid)]
    public class GameHub : Hub
    {
        //private const string guid = "C4CD33D6-8AC4-4034-b273-0E236D93";
        Field field = new Field();
        HttpClient client = new HttpClient();
        private SeaBattleService seaBattleService;
        public GameHub()
        {
            this.seaBattleService = new SeaBattleService();
        }
        public static void UserLeftGame(User user)
        {
            if (user != null)
            {
                user.IsOnline = false;
            }

            bool anyUserOnline = GameInfo.Users.Any(x => x.IsOnline);
            if (!anyUserOnline)
            {
                GameInfo.GameState = GameState.FieldNotInitialized;
            }
        }

        private User GetCurrentUser()
        {
            var connectionId = Context.ConnectionId;
            var currentUser = GameInfo.Users.FirstOrDefault(x => x.ConnectionId == connectionId);

            return currentUser;
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            if (stopCalled)
            {
                User currentUser = GetCurrentUser();
                UserLeftGame(currentUser);
            }

            return null;
        }

        public async Task Connect(string username)
        {
            var currentUser = GameInfo.Users.FirstOrDefault(x => x.Username == username);
            if (currentUser == null)
            {
                currentUser = new User(username);
                GameInfo.Users.Add(currentUser);
            }

            currentUser.IsOnline = true;
            currentUser.ConnectionId = Context.ConnectionId;

            await Clients.Others.SendMessage($"User {currentUser.Username} has just logged in.");
            await Clients.Caller.SendMessage($"You successfully logged in as {currentUser.Username}");
        }

        public async Task ShootContent(string message)
        {
            await Clients.Others.SendMessage(message);
        }

        public async Task RepairContent(string message)
        {
            await Clients.Others.SendMessage(message);
        }

        public async Task AddShipContent(string message)
        {
            await Clients.Caller.SendMessage(message);
        }

        public async Task SendMessage(string message)
        {
            await this.Clients.All.SendMessage(message);
        }

        public async Task GetShoot(Shoot shoot)
        {
            var serialized = JsonConvert.SerializeObject(shoot, new EncryptionJsonConverter());
            await this.seaBattleService.GetShoot(serialized);
            await this.Clients.All.GetShoot(serialized);
        }

        public async Task GetRepair(Repair repair)
        {
            var serialized = JsonConvert.SerializeObject(repair, new EncryptionJsonConverter());
            // await this.seaBattleService.GetRepair(serialized);
            await this.Clients.All.GetRepair(serialized);
        }

        public async Task InitMap()
        {
            this.client.BaseAddress = new Uri("https://localhost:44386/");
            GameObjects.FieldMap.X = field.X = 100;
            GameObjects.FieldMap.Y = field.Y = 100;
             var serialized = JsonConvert.SerializeObject(field, new EncryptionJsonConverter());
             await this.seaBattleService.InitMap(serialized);
            await this.Clients.All.InitializeField(GameObjects.FieldMap);
        }

        public async Task AddShip(Ship ship)
        {
            if (GameInfo.Ships == null)
            {
                GameInfo.Ships = new List<Ship>();
            }
            GameInfo.Ships.Add(ship);
            var serialized = JsonConvert.SerializeObject(ship, new EncryptionJsonConverter());
            await this.Clients.Caller.AddShip(JsonConvert.SerializeObject(ship));
            await this.seaBattleService.AddShip(serialized);
        }

        public async Task Ready()
        {
            var currentUser = GameInfo.Users.FirstOrDefault(x => x.ConnectionId == this.Context.ConnectionId);
            if (currentUser != null)
            {
                currentUser.IsReady = true;

                var onlineUsers = GameInfo.Users.Where(x => x.IsOnline);
                if (onlineUsers.All(x => x.IsReady))
                {
                    await this.Clients.All.StartGame();
                }
            }
        }
    }
}