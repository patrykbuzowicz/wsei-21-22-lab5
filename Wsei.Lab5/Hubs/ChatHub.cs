using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using Wsei.Lab5.Entities;
using Wsei.Lab5.Services;

namespace Wsei.Lab5.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        private IChatMessagesRepository _repository;

        public ChatHub(IChatMessagesRepository repository)
        {
            _repository = repository;
        }

        public override async Task OnConnectedAsync()
        {
            var user = Context.User.Identity.Name;

            await Clients.Caller.SendAsync("OnMessageSent", "admin", "Hello, " + user);
        }

        public async Task SendMessage(string message)
        {
            var user = Context.User.Identity.Name;

            await Clients.All.SendAsync("OnMessageSent", user, message);

            var messageEntity = new ChatMessageEntity
            {
                Username = user,
                Content = message,
            };
            _repository.Add(messageEntity);
        }
    }
}
