using System;
using System.Net;
using Frank.Libraries.IRC;

namespace Frank.Apps.IrcTerminalClient;

class Program
{
    static void Main(string[] args)
    {
        var irc = new IRC(1024);

        var ipAddress = IPAddress.Parse("127.0.0.1");
        var port = 6666;
        var result = irc.Connect(ipAddress, port);
        Console.WriteLine(result);
        irc.Message.ServerReplyEvent += (sender, reply) => Console.WriteLine(reply.Message);

        irc.Login("apophis.ch", new Nick() { Nickname = "frank" });

        irc.Command.SendInfo("apophis.ch");
        irc.Command.SendStats(ServerStat.l);
        irc.Command.SendConnect(ipAddress.ToString());


        var channels = irc.Channels.ToArray();

        Console.WriteLine(channels);
        Console.ReadLine();
    }
}