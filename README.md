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

Afterward replace Program.cs for the file available in this repo.


