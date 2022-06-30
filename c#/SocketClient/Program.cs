using System.Net;
using System.Net.Sockets;
using System.Text;

public class SocketClient
{
    static void Main(string[] args)
    {
        var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        var connect = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5000);
        socket.Connect(connect);
        var enviar_info = new byte[100];
        var data = "";
        while(data != "Chau")
        {
            Console.WriteLine("Cliente:");

            data = Console.ReadLine();

            enviar_info = Encoding.Default.GetBytes(data);

            socket.Send(enviar_info);

            byte[] recibir_info = new byte[100]; //cantidad de bytes
            int array_size = 0;

            array_size = socket.Receive(recibir_info,0, recibir_info.Length, 0); //guardamos el n° de bytes que nos envia el cliente
            Array.Resize(ref recibir_info, array_size);
            var mensajeServidor = Encoding.Default.GetString(recibir_info); //lo convertimos en un string a los bytes
            Console.WriteLine("Servidor: {0}", mensajeServidor);
        }
    }
}