using Microsoft.AspNetCore.SignalR;

namespace ServerAspnet
{
    public class ClockHub : Hub
    {
        // Este método se llama cuando un cliente se conecta
        public override async Task OnConnectedAsync()
        {
            // Comienza a enviar la hora cada segundo
            await SendTime();
        }

        // Método que envía la hora cada segundo
        private async Task SendTime()
        {
            while (true)
            {
                // Enviar la hora a todos los clientes conectados
                await Clients.All.SendAsync("ReceiveTime", DateTime.Now.ToString("HH:mm:ss"));
                await Task.Delay(1000); // Esperar 1 segundo antes de enviar la hora nuevamente
            }
        }
    }
}
