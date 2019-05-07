using System;
using Amqp;
using Amqp.Framing;


namespace hello_world
{
    class Program
    {
        static void Main(string[] args)
        {

            string    url = (args.Length > 0) ? args[0] :
                "amqp://guest:guest@127.0.0.1:5672";
            string target = (args.Length > 1) ? args[1] : "request";

            Address peerAddr = new Address(url);
            Connection connection = new Connection(peerAddr);
            Session session = new Session(connection);


            Message msg = new Message("Request Response");
            msg.Properties = new Properties();
            msg.Properties.ReplyTo = "response";


            SenderLink sender = new SenderLink(session, "send-1", target);
            sender.Send(msg);
            sender.Close();

            session.Close();
            connection.Close();

        }
    }
}

