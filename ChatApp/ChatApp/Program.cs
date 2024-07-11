using ChatApp;

if (args.Length == 0)
{
    Chat.Server();
}
else
{
    Chat.Client(args[0]);
}