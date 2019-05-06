
using System;
using Amqp;
using Amqp.Framing;


namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {

            string    url = (args.Length > 0) ? args[0] :
                "amqp://guest:guest@127.0.0.1:5672";
            string target = (args.Length > 1) ? args[1] : "example";
            int     count = (args.Length > 2) ? Convert.ToInt32(args[2]) : 10;

            Address peerAddr = new Address(url);
            Connection connection = new Connection(peerAddr);
            Session session = new Session(connection);


            Message msg = new Message("Request Response");
            msg.Properties = new Properties();
            msg.Properties.ReplyTo = "response";


            SenderLink sender = new SenderLink(session, "send-1", msg.Properties.ReplyTo);
            sender.Send(msg);



            sender.Close();
            session.Close();
            connection.Close();

        }
    }
}

