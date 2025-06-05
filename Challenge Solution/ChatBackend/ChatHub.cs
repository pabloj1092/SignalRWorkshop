using Microsoft.AspNetCore.SignalR;

namespace ChatBackend;

public class ChatHub : Hub
{
    public async Task SendMessage(string user, string message)
    {
        // Broadcast to all clients
        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }
    
    public async Task SendMessageGroup(string roomName, string user, string message)
    {
        await Clients.Groups(roomName).SendAsync("ReceiveMessage", user, message);
    }
    
    public async Task JoinRoom(string roomName)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, roomName);
    }
}