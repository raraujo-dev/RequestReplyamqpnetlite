# RequestReplyamqpnetlite
How to implement Request Reply using AMQ .NET client


Using this example to connect with AMQ broker or Artemis in order to use ReplyTo property


Run the follow command

dotnet new console --name Example

Inside the Example directory, add the follow ItemGroup tag into <Project> tag pointing to AMQP.dll available for download in this repo.

<ItemGroup>
  <Reference Include="AMQP">
          <HintPath>/home/raraujo/ferramentas/amq-dotnetcore/bin/netstandard2.0/AMQP.dll</HintPath>
  </Reference>
</ItemGroup>

Afterward replace Program.cs for the file available in this repo

Do the same steps in order to create another .net core project to receive the message and display the RepluTo variable.

Follow the code that will need to input inside Program.cs file:

```
    using System;
    using Amqp;

namespace hello_world
{
    class Program
    {
        static void Main(string[] args)
        {


           string    url = (args.Length > 0) ? args[0] :
                "amqp://guest:guest@127.0.0.1:5672";
            string source = (args.Length > 1) ? args[1] : "response";

            Address      peerAddr = new Address(url);
            Connection connection = new Connection(peerAddr);
            Session       session = new Session(connection);
            ReceiverLink receiver = new ReceiverLink(session, "recv-1", source);

            Message msg = receiver.Receive();
            Console.WriteLine("Received: " + msg.Properties.ReplyTo.ToString());

            receiver.Close();
            session.Close();
            connection.Close();




        }
    }
}

```

